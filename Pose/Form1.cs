using System.Diagnostics;

using NAudio.Wave;

using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Pose
{
    public partial class Form1 : Form
    {
        #region Constants

        private const double MaxFps = 150.0;

        #endregion

        #region Fields

        private AudioFileReader audioFileReader;
        private IWavePlayer waveOutDevice;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _isPlaying = false;
        private bool _isPlayingForward = true;
        private double _TargetFPS = 25.0; // Default FPS - reset to video FPS in btnLoad_Click()
        private double actualFps = 25.0; // Default FPS
        private bool _VideoCameraCapture = false;

        private Stopwatch _stopwatch; // Field for overall timing
        private Stopwatch _frameReadStopwatch; // Field for frame read timing
        private Stopwatch _displayStopwatch; // Field for display timing
        private double _lastElapsedTime; // Field to track last elapsed time for FPS calculation

        //private IMediaInfo _mediaInfo;
        private VideoCapture _videoCapture;  // VideoCapture to handle video playback
        private string _videoPath;
        //private Queue<double> _frameTimes = new Queue<double>();

        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            // Disable playback buttons initially
            btnPlay.Enabled = false;
            btnPause.Enabled = false;
            btnPlayPause.Enabled = false;
            btnForward5.Enabled = false;
            btnBack5.Enabled = false;
            btnPose.Enabled = false; // Disable pose button as well
        }

        #endregion

        #region Private Methods

        private void DecreasePlaybackSpeed()
        {
            if (_videoCapture != null && _videoCapture.IsOpened())
            {
                // Increase the playback speed by raising the FPS
                double newFps = _videoCapture.Fps - 5.0;  // Decrease by 5 FPS, or adjust as needed

                if (_VideoCameraCapture) // Only supported by Video cameras
                {
                    _videoCapture.Fps = Math.Min(newFps, 60.0);  // Cap the maximum FPS to prevent excessively fast playback
                }

                _TargetFPS = Math.Min(newFps, MaxFps); // Cap at MaxFps
            }
        }

        private void DisplayFirstFrame()
        {
            if (_videoCapture != null)
            {
                UMat firstFrame = new UMat();
                _videoCapture.PosFrames = 0; // Set the video position to the first frame
                if (_videoCapture.Read(firstFrame))
                {
                    // Resize the frame to fit the PictureBox while maintaining aspect ratio
                    ResizeFrameToFitPictureBox(firstFrame);

                    // Safely update the PictureBox with the first frame
                    using (Mat matFrame = firstFrame.GetMat(AccessFlag.FAST | AccessFlag.READ))
                    {
                        picVideo.Image?.Dispose();
                        picVideo.Image = BitmapConverter.ToBitmap(matFrame);
                    }
                }
            }
        }

        private void DisplayFrame(UMat frame)
        {
            // Check if the frame is valid
            if (frame == null || frame.Empty())
            {
                return;
            }

            // Create a Mat from UMat without disposing immediately
            Mat matFrame = new Mat();
            frame.CopyTo(matFrame);

            // Update the PictureBox on the UI thread
            _ = picVideo.BeginInvoke((MethodInvoker)(() =>
            {
                try
                {
                    // Dispose of the current image to free up resources
                    picVideo.Image?.Dispose();

                    // Convert Mat to Bitmap
                    picVideo.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matFrame);
                }
                catch (Exception ex)
                {
                    // Log or handle exceptions as needed
                    Debug.WriteLine($"[ERROR] Exception in DisplayFrame: {ex.Message}");
                }
                finally
                {
                    // Ensure matFrame is disposed of after conversion
                    matFrame.Dispose();
                }
            }));
        }

        private void DrawSkeleton(Mat frame, List<OpenCvSharp.Point[]> keypoints)
        {
            foreach (OpenCvSharp.Point[] pointPair in keypoints)
            {
                Cv2.Line(frame, pointPair[0], pointPair[1], Scalar.Lime, 2); // Draws a line between two points
            }
        }

        private void IncreasePlaybackSpeed()
        {
            if (_videoCapture != null && _videoCapture.IsOpened())
            {
                // Increase the playback speed by raising the FPS
                double newFps = _videoCapture.Fps + 5.0;  // Increase by 5 FPS, or adjust as needed

                if (_VideoCameraCapture) // Only supported by Video cameras
                {
                    _videoCapture.Fps = Math.Min(newFps, 60.0);  // Cap the maximum FPS to prevent excessively fast playback
                }

                _TargetFPS = Math.Min(newFps, MaxFps); // Cap at MaxFps
            }
        }

        private void InitializeAudioPlayback()
        {
            if (!string.IsNullOrEmpty(_videoPath))
            {
                waveOutDevice = new WaveOutEvent();
                audioFileReader = new AudioFileReader(_videoPath);
                waveOutDevice.Init(audioFileReader);
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                IncreasePlaybackSpeed(); // Scroll up increases frame rate
            }
            else if (e.Delta < 0)
            {
                DecreasePlaybackSpeed(); // Scroll down decreases frame rate
            }

            base.OnMouseWheel(e);
        }

        //private void PlaySingleFrame()
        //{
        //    if (_videoCapture != null)
        //    {
        //        try
        //        {
        //            UMat frame = new UMat();

        //            if (_videoCapture.Read(frame))
        //            {
        //                try
        //                {
        //                    // Convert UMat to Mat for display
        //                    using (Mat matFrame = frame.GetMat(AccessFlag.FAST | AccessFlag.READ))
        //                    {
        //                        picVideo.Image?.Dispose();
        //                        picVideo.Image = BitmapConverter.ToBitmap(matFrame);
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    Debug.WriteLine($"[ERROR] Exception during frame conversion or display: {ex.Message}");
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine($"[ERROR] Exception in PlaySingleFrame: {ex.Message}");
        //        }
        //    }
        //}

        private void PlaySingleFrame()
        {
            if (_videoCapture != null)
            {
                using (UMat frame = new UMat())
                {
                    if (_videoCapture.Read(frame))
                    {
                        // Convert UMat to Mat for display
                        using (Mat matFrame = frame.GetMat(AccessFlag.FAST | AccessFlag.READ))
                        {
                            try
                            {
                                Bitmap newImage = BitmapConverter.ToBitmap(matFrame);

                                _ = picVideo.Invoke((MethodInvoker)(() =>
                                {
                                    picVideo.Image?.Dispose(); // Dispose the old image
                                    picVideo.Image = newImage; // Assign the new image
                                }));
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"[ERROR] Exception while setting PictureBox image: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }

        private void UpdatePlayPauseButton(bool isPlaying)
        {
            if (btnPlayPause.InvokeRequired)
            {
                // If this method is called from a thread other than the UI thread, use Invoke to marshal the call to the UI thread.
                btnPlayPause.Invoke(new Action(() => UpdatePlayPauseButton(isPlaying)));
            }
            else
            {
                // This code runs on the UI thread, so it's safe to update the UI components directly.
                btnPlayPause.Text = isPlaying ? "Pause" : "Play";
            }
        }

        //private async Task PlayVideoAsync(CancellationToken cancellationToken)
        //{
        //    if (_videoCapture == null || !_videoCapture.IsOpened())
        //    {
        //        return;
        //    }

        //    using (UMat frame = new UMat())
        //    {
        //        Stopwatch stopwatch = Stopwatch.StartNew();
        //        int frameCount = 0;

        //        while (_isPlaying && !cancellationToken.IsCancellationRequested)
        //        {
        //            // Start stopwatch for frame read
        //            Stopwatch frameReadStopwatch = Stopwatch.StartNew();

        //            double targetFrameIntervalMs = 1000.0 / _TargetFPS; // Maximum interval between frames in milliseconds

        //            bool frameReadSuccess = _isPlayingForward ? ReadNextFrame(frame) : ReadPreviousFrame(frame);
        //            frameReadStopwatch.Stop();
        //            double frameReadTimeMs = frameReadStopwatch.Elapsed.TotalMilliseconds;

        //            if (frameReadSuccess)
        //            {
        //                frameCount++;
        //                double elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;

        //                // Calculate actual FPS
        //                double actualFps = frameCount / (elapsedMilliseconds / 1000.0);

        //                // Measure the time taken to display the frame and sync the audio
        //                Stopwatch displayStopwatch = Stopwatch.StartNew();
        //                DisplayFrame(frame);
        //                SyncAudio();
        //                displayStopwatch.Stop();
        //                double displayTimeMs = displayStopwatch.Elapsed.TotalMilliseconds;

        //                // Calculate total overhead time
        //                double totalOverheadTimeMs = frameReadTimeMs + displayTimeMs;

        //                // Calculate FPS difference
        //                double fpsDifference = _TargetFPS - actualFps;

        //                // Calculate the needed delay to maintain the target FPS
        //                double delayAdjustment = fpsDifference * (1000.0 / _TargetFPS); // Convert FPS difference to milliseconds

        //                // Calculate the new delay considering all overheads and the FPS difference
        //                double delayMs = targetFrameIntervalMs - totalOverheadTimeMs - delayAdjustment;

        //                // Subtract the frame read time from the delay to compensate
        //                delayMs -= frameReadTimeMs;

        //                // Cap the delay to a maximum of targetFrameIntervalMs (40 ms for 25 FPS)
        //                delayMs = Math.Min(Math.Max(delayMs, 1), targetFrameIntervalMs);

        //                int delay = (int)delayMs; // Convert to an integer for delay function

        //                // Debugging output including current frame rate, calculated delay, and difference
        //                Debug.WriteLine($"[DEBUG] Target FPS: {_TargetFPS:F2} | Actual FPS: {actualFps:F2} | FPS Difference: {fpsDifference:F2} | Frame Read Time: {frameReadTimeMs:F2} ms | Display Time: {displayTimeMs:F2} ms | Calculated Delay: {delay} ms");

        //                // Await delay until the next frame
        //                await Task.Delay(delay, cancellationToken);
        //            }
        //            else
        //            {
        //                _isPlaying = false;
        //            }
        //        }
        //    }

        //    picVideo.Image?.Dispose();
        //}

        private async Task PlayVideoAsync(CancellationToken cancellationToken)
        {
            if (_videoCapture == null || !_videoCapture.IsOpened())
            {
                return;
            }

            using (UMat frame = new UMat())
            {
                _stopwatch = new Stopwatch();
                _frameReadStopwatch = new Stopwatch();
                _displayStopwatch = new Stopwatch();
                _lastElapsedTime = 0;  // Initialize last elapsed time

                _stopwatch.Start();
                int frameCount = 0;
                double totalElapsedTime = 0; // Initialize totalElapsedTime for correct calculation

                while (_isPlaying && !cancellationToken.IsCancellationRequested)
                {
                    _frameReadStopwatch.Restart();

                    // Convert target frame interval to microseconds
                    double targetFrameIntervalUs = 1000.0 / _TargetFPS * 1000.0;

                    bool frameReadSuccess = _isPlayingForward ? ReadNextFrame(frame) : ReadPreviousFrame(frame);
                    _frameReadStopwatch.Stop();
                    double frameReadTimeUs = _frameReadStopwatch.ElapsedTicks * (1000000.0 / Stopwatch.Frequency);

                    if (frameReadSuccess)
                    {
                        double currentFramePosition = _videoCapture.Get(VideoCaptureProperties.PosFrames);
                        frameCount++;

                        // Correctly calculate the total elapsed time in microseconds
                        totalElapsedTime = _stopwatch.Elapsed.TotalMilliseconds * 1000.0;

                        // Prevent division by zero by checking if totalElapsedTime is greater than zero
                        if (totalElapsedTime > 0)
                        {
                            // Calculate actual FPS based on total elapsed time and frame count
                            actualFps = frameCount / (totalElapsedTime / 1000000.0); // In frames per second
                        }
                        else
                        {
                            actualFps = _TargetFPS; // Default to target FPS if elapsed time is zero
                        }

                        _lastElapsedTime = totalElapsedTime; // Update the last elapsed time in microseconds

                        _displayStopwatch.Restart();
                        DisplayFrame(frame);
                        SyncAudio();
                        _displayStopwatch.Stop();
                        double displayTimeUs = _displayStopwatch.ElapsedTicks * (1000000.0 / Stopwatch.Frequency);

                        double totalOverheadTimeUs = frameReadTimeUs + displayTimeUs;

                        double fpsDifference = _TargetFPS - actualFps;

                        // Calculate delay using a weighted average to smooth out fluctuations
                        double delayAdjustmentUs = fpsDifference * (1000000.0 / _TargetFPS); // Convert FPS difference to microseconds

                        double delayUs = targetFrameIntervalUs - totalOverheadTimeUs - delayAdjustmentUs;

                        // Make sure delay is within valid range
                        delayUs = Math.Min(Math.Max(delayUs, 1), targetFrameIntervalUs);

                        // Store the initial delay for debug output before any adjustments
                        double initialDelayUs = delayUs;

                        if (delayUs >= 1000)
                        {
                            // For delays >= 1ms, use Task.Delay for the millisecond part
                            int delayMs = (int)(delayUs / 1000);
                            await Task.Delay(delayMs, cancellationToken);

                            // Calculate the remaining microseconds after the Task.Delay
                            delayUs -= delayMs * 1000;
                        }

                        // For remaining microsecond delay, use SpinWait
                        if (delayUs > 0)
                        {
                            long targetTicks = Stopwatch.GetTimestamp() + (long)(delayUs * Stopwatch.Frequency / 1_000_000.0);
                            while (Stopwatch.GetTimestamp() < targetTicks)
                            {
                                Thread.SpinWait(1);
                            }
                        }

                        // Recalculate actual FPS after the complete delay
                        totalElapsedTime = _stopwatch.Elapsed.TotalMilliseconds * 1000.0;
                        if (totalElapsedTime > 0)
                        {
                            actualFps = frameCount / (totalElapsedTime / 1000000.0); // In frames per second
                        }

                        // Calculate the extra wait time in microseconds to precisely sync FPS
                        double extraWaitTimeUs = (1000000.0 / _TargetFPS) - (totalElapsedTime / frameCount);

                        if (extraWaitTimeUs is > 0 and < 1000)
                        {
                            // Only use SpinWait for microsecond precision if it is necessary and less than 1 millisecond
                            long targetTicks = Stopwatch.GetTimestamp() + (long)(extraWaitTimeUs * Stopwatch.Frequency / 1_000_000.0);
                            while (Stopwatch.GetTimestamp() < targetTicks)
                            {
                                Thread.SpinWait(1);
                            }
                        }

                        // Update debug output after all delays and recalculations
                        Debug.WriteLine($"[DEBUG] Target FPS: {_TargetFPS:F2} | Actual FPS: {actualFps:F2} | FPS Difference: {fpsDifference:F2} | Frame Read Time: {frameReadTimeUs:F2} 탎 | Display Time: {displayTimeUs:F2} 탎 | Initial Calculated Delay: {initialDelayUs:F2} 탎 | Final Calculated Delay: {delayUs:F2} 탎 | Extra Wait Time: {extraWaitTimeUs:F2} 탎 | Current Frame: {currentFramePosition}");
                    }
                    else
                    {
                        _isPlaying = false;
                        UpdatePlayPauseButtonText("Play");

                        if (_isPlayingForward)
                        {
                            _videoCapture.PosFrames = (int)(_videoCapture.Get(VideoCaptureProperties.FrameCount) - 1);
                        }
                        else
                        {
                            _videoCapture.PosFrames = 0;
                        }

                        if (_videoCapture.PosFrames < _videoCapture.Get(VideoCaptureProperties.FrameCount))
                        {
                            PlaySingleFrame();
                        }
                        else
                        {
                            _ = picVideo.Invoke((MethodInvoker)(() =>
                            {
                                picVideo.Image?.Dispose();
                                picVideo.Image = null;
                            }));
                        }
                    }
                }
            }

            picVideo.Image?.Dispose();
        }

        private void UpdatePlayPauseButtonText(string text)
        {
            if (btnPlayPause.InvokeRequired)
            {
                _ = btnPlayPause.Invoke((MethodInvoker)(() => btnPlayPause.Text = text));
            }
            else
            {
                btnPlayPause.Text = text;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Space:
                case Keys.MediaPlayPause:  // Media Play/Pause key
                    TogglePlayPause();
                    return true;
                case Keys.Right:
                case Keys.MediaNextTrack:  // Media Next Track key
                    SkipForward(1);  // Skip forward by 1 second
                    return true;
                case Keys.Left:
                case Keys.MediaPreviousTrack:  // Media Previous Track key
                    SkipBackward(1);  // Skip backward by 1 second
                    return true;
                case Keys.PageUp:
                    IncreasePlaybackSpeed();
                    return true;
                case Keys.PageDown:
                    DecreasePlaybackSpeed();
                    return true;
                case Keys.Add:  // Numeric keypad +
                case Keys.Oemplus | Keys.Shift:  // Main keyboard +
                    IncreasePlaybackSpeed();
                    return true;
                case Keys.Subtract:  // Numeric keypad -
                case Keys.OemMinus:  // Main keyboard -
                    DecreasePlaybackSpeed();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool ReadNextFrame(UMat frame)
        {
            if (_videoCapture == null)
            {
                return false;
            }

            // Read the next frame in the sequence
            return _videoCapture.Read(frame);
        }

        private bool ReadPreviousFrame(UMat frame)
        {
            if (_videoCapture == null)
            {
                return false;
            }

            // Get the current frame position
            double currentFrame = _videoCapture.Get(VideoCaptureProperties.PosFrames);

            // Check if it's possible to move back to the previous frame
            if (currentFrame > 1) // Ensure there is a frame to go back to
            {
                // Move to the previous frame
                _ = _videoCapture.Set(VideoCaptureProperties.PosFrames, currentFrame - 2);

                // Read the frame after moving the position
                return _videoCapture.Read(frame);
            }
            else
            {
                return false; // At the beginning of the video
            }
        }

        private void ResizeFrameToFitPictureBox(UMat frame)
        {
            try
            {
                if (frame.Empty())
                {
                    // Handle the case where the frame is empty
                    Debug.WriteLine("Warning: The frame is empty and cannot be resized.");
                    return;
                }

                int pictureBoxWidth = picVideo.Width;
                int pictureBoxHeight = picVideo.Height;

                // Check if resizing is necessary
                if (pictureBoxWidth <= 0 || pictureBoxHeight <= 0)
                {
                    Debug.WriteLine("Warning: Invalid PictureBox dimensions.");
                    return;
                }

                double aspectRatio = (double)frame.Width / frame.Height;

                int newWidth = pictureBoxWidth;
                int newHeight = (int)(pictureBoxWidth / aspectRatio);

                // Calculate new dimensions while maintaining aspect ratio
                if (newHeight > pictureBoxHeight)
                {
                    newHeight = pictureBoxHeight;
                    newWidth = (int)(pictureBoxHeight * aspectRatio);
                }

                // Perform resizing directly without additional checks
                Cv2.Resize(frame, frame, new OpenCvSharp.Size(newWidth, newHeight), interpolation: InterpolationFlags.Linear);
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging purposes
                Debug.WriteLine($"Error in ResizeFrameToFitPictureBox: {ex.Message}");
            }
        }

        private void SetPlaybackButtonsEnabled(bool enabled)
        {
            btnPlayPause.Enabled = enabled;
            btnForward5.Enabled = enabled;
            btnBack5.Enabled = enabled;
            btnPose.Enabled = enabled;
        }

        private void SkipForward(double seconds)
        {
            if (_videoCapture != null)
            {
                // Calculate the number of frames to skip based on the actual playback FPS
                int framesToSkip = (int)(seconds * actualFps);

                // Update the frame position by adding the calculated frames to skip
                _videoCapture.PosFrames = (int)Math.Min(_videoCapture.PosFrames + framesToSkip, _videoCapture.Get(VideoCaptureProperties.FrameCount) - 1);

                // Reset timing to ensure accurate FPS calculation after skipping
                ResetTiming();

                // Only display a single frame if playback is currently paused
                if (!_isPlaying)
                {
                    PlaySingleFrame();  // Display the new frame after skipping
                }
            }
        }

        private void SkipBackward(double seconds)
        {
            if (_videoCapture != null)
            {
                // Calculate the number of frames to skip based on the actual playback FPS
                int framesToSkip = (int)(seconds * actualFps);

                // Ensure the frame position does not go below 0
                _videoCapture.PosFrames = Math.Max(0, _videoCapture.PosFrames - framesToSkip);

                // Reset timing to ensure accurate FPS calculation after skipping
                ResetTiming();

                // Only display a single frame if playback is currently paused
                if (!_isPlaying)
                {
                    PlaySingleFrame();  // Display the new frame after skipping
                }
            }
        }

        private void ResetTiming()
        {
            _stopwatch?.Restart(); // Restart the stopwatch to measure time from this point

            _lastElapsedTime = 0; // Reset the last elapsed time to start fresh timing
        }

        private void SyncAudio()
        {
            if (audioFileReader != null && waveOutDevice != null)
            {
                double currentVideoTime = _videoCapture.PosMsec / 1000.0; // Convert milliseconds to seconds

                if (Math.Abs(audioFileReader.CurrentTime.TotalSeconds - currentVideoTime) > 0.05) // Use a smaller threshold
                {
                    audioFileReader.CurrentTime = TimeSpan.FromSeconds(currentVideoTime);
                }

                if (_isPlaying && _isPlayingForward)
                {
                    if (waveOutDevice.PlaybackState != PlaybackState.Playing)
                    {
                        waveOutDevice.Play();
                    }
                }
                else
                {
                    if (waveOutDevice.PlaybackState == PlaybackState.Playing)
                    {
                        waveOutDevice.Pause();
                    }
                }
            }
        }

        private void SyncAudioToCurrentVideoPosition()
        {
            if (audioFileReader != null)
            {
                double currentVideoTime = _videoCapture.PosMsec / 1000.0; // Convert milliseconds to seconds
                audioFileReader.CurrentTime = TimeSpan.FromSeconds(currentVideoTime);
            }
        }

        private void TogglePlayPause()
        {
            if (btnPlayPause.InvokeRequired)
            {
                btnPlayPause.Invoke(new Action(TogglePlayPause));
            }
            else
            {
                btnPlayPause_Click(null, null); // Trigger the play/pause toggle
            }
        }

        #endregion

        #region Event Handlers

        private void btnBack5_Click(object sender, EventArgs e)
        {
            SkipBackward(5);  // Skip backward by 5 seconds
        }

        private void btnBeginning_Click(object sender, EventArgs e)
        {
            if (_videoCapture != null && _videoCapture.IsOpened())
            {
                // Set the video to the first frame (frame 0)
                _videoCapture.PosFrames = 0;

                // Sync audio to the start of the video
                SyncAudioToCurrentVideoPosition();

                if (_isPlaying)
                {
                    // Continue playing in the current direction
                    if (_isPlayingForward)
                    {
                        _isPlayingForward = true; // Play forward from the beginning
                    }
                    else
                    {
                        _isPlayingForward = false; // Play backward from the beginning
                    }
                }
                else
                {
                    // If not playing, show the first frame
                    PlaySingleFrame();
                }
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (_videoCapture != null && _videoCapture.IsOpened())
            {
                // Set the video to the last frame
                double lastFrame = _videoCapture.Get(VideoCaptureProperties.FrameCount) - 1;
                _videoCapture.PosFrames = (int)lastFrame;

                // Sync audio to the end of the video
                SyncAudioToCurrentVideoPosition();

                if (_isPlaying)
                {
                    if (_isPlayingForward)
                    {
                        _isPlayingForward = true; // Ensure it plays forward from the last frame
                    }
                    else
                    {
                        _isPlayingForward = false; // Ensure it plays backward from the last frame
                    }
                }
                else
                {
                    PlaySingleFrame();
                }
            }
        }

        private void btnForward5_Click(object sender, EventArgs e)
        {
            SkipForward(5);  // Skip forward by 5 seconds
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Set the environment variable to use GPU1 (NVIDIA)
            Environment.SetEnvironmentVariable("CUDA_VISIBLE_DEVICES", "1");

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mkv";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _videoPath = openFileDialog.FileName;
                    _videoCapture = new VideoCapture(_videoPath, VideoCaptureAPIs.ANY);

                    if (!_videoCapture.IsOpened())
                    {
                        _ = MessageBox.Show("Failed to open video file.");
                        return;
                    }

                    _TargetFPS = _videoCapture.Fps;
                    SetPlaybackButtonsEnabled(true);

                    // Display the first frame
                    DisplayFirstFrame();
                }
            }
        }

        //private async void btnPlayPause_Click(object sender, EventArgs e)
        //{
        //    if (_isPlaying)
        //    {
        //        _isPlaying = false;
        //        UpdatePlayPauseButton(false); // Update the button text to "Play"
        //        _cancellationTokenSource?.Cancel();  // Cancel the playback task
        //        waveOutDevice?.Pause(); // Pause audio
        //    }
        //    else
        //    {
        //        _isPlaying = true;
        //        UpdatePlayPauseButton(true); // Update the button text to "Pause"
        //        _cancellationTokenSource = new CancellationTokenSource();

        //        if (_videoCapture == null || !_videoCapture.IsOpened())
        //        {
        //            _ = MessageBox.Show("Video is not loaded.");
        //            return;
        //        }

        //        if (waveOutDevice == null || audioFileReader == null)
        //        {
        //            try
        //            {
        //                InitializeAudioPlayback();
        //            }
        //            catch (Exception ex)
        //            {
        //                Debug.WriteLine($"[ERROR] Exception in btnPlayPause_Click (InitializeAudioPlayback): {ex.Message}");
        //            }
        //        }

        //        try
        //        {
        //            waveOutDevice?.Play(); // Start or resume audio playback
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine($"[ERROR] Exception in btnPlayPause_Click (waveOutDevice?.Play()): {ex.Message}");
        //        }

        //        try
        //        {
        //            await Task.Run(() => PlayVideoAsync(_cancellationTokenSource.Token));  // Run playback in a separate task
        //        }
        //        catch (OperationCanceledException)
        //        {
        //            // Handle cancellation here if necessary
        //        }
        //    }
        //}

        private async void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (_isPlaying)
            {
                // Pausing the playback
                _isPlaying = false;
                UpdatePlayPauseButtonText("Play");

                // Cancel the playback task
                _cancellationTokenSource?.Cancel();

                // Pause audio playback
                waveOutDevice?.Pause();
            }
            else
            {
                // Starting or resuming playback
                _isPlaying = true;
                UpdatePlayPauseButtonText("Pause");
                _cancellationTokenSource = new CancellationTokenSource();

                if (_videoCapture == null || !_videoCapture.IsOpened())
                {
                    _ = MessageBox.Show("Video is not loaded.");
                    return;
                }

                if (waveOutDevice == null || audioFileReader == null)
                {
                    try
                    {
                        InitializeAudioPlayback();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[ERROR] Exception in btnPlayPause_Click (InitializeAudioPlayback): {ex.Message}");
                    }
                }

                try
                {
                    // Start or resume audio playback
                    if (waveOutDevice.PlaybackState != PlaybackState.Playing)
                    {
                        waveOutDevice.Play();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[ERROR] Exception in btnPlayPause_Click (waveOutDevice?.Play()): {ex.Message}");
                }

                try
                {
                    // Run playback in a separate task
                    await Task.Run(() => PlayVideoAsync(_cancellationTokenSource.Token));
                }
                catch (OperationCanceledException)
                {
                    // Handle cancellation here if necessary
                }
            }
        }

        private void btnPose_Click(object sender, EventArgs e)
        {
            if (_videoCapture == null || !_videoCapture.IsOpened())
            {
                _ = MessageBox.Show("Video not loaded.");
                return;
            }

            using (UMat frame = new UMat())
            {
                if (!_videoCapture.Read(frame))
                {
                    _ = MessageBox.Show("Could not read frame.");
                    return;
                }

                // Analyze the frame by creating a separate Mat instance for the analyzer
                using (Mat analysisMat = frame.GetMat(AccessFlag.FAST | AccessFlag.READ))
                {
                    JudoMatchAnalyzer analyzer = new JudoMatchAnalyzer(analysisMat);
                    analyzer.AnalyzeFrame();
                } // Ensure analysisMat is disposed of before frame

                // Display the processed frame
                using (Mat matFrame = frame.GetMat(AccessFlag.FAST | AccessFlag.READ))
                {
                    picVideo.Image?.Dispose();
                    picVideo.Image = BitmapConverter.ToBitmap(matFrame);
                } // Ensure matFrame is disposed of before frame
            }
        }

        private Rect DetectMatArea(UMat frame)
        {
            // Convert to grayscale and apply edge detection
            UMat grayFrame = new UMat();
            Cv2.CvtColor(frame, grayFrame, ColorConversionCodes.BGR2GRAY);
            Cv2.GaussianBlur(grayFrame, grayFrame, new OpenCvSharp.Size(5, 5), 1.5);
            UMat edges = new UMat();
            Cv2.Canny(grayFrame, edges, 50, 150);

            // Find contours in the edge-detected image
            Cv2.FindContours(edges, out OpenCvSharp.Point[][] contours, out _, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            // Find the largest rectangular contour (assumed to be the mat)
            Rect largestRect = new Rect();
            double maxArea = 0;

            foreach (OpenCvSharp.Point[] contour in contours)
            {
                OpenCvSharp.Point[] approx = Cv2.ApproxPolyDP(contour, 0.02 * Cv2.ArcLength(contour, true), true);
                if (approx.Length == 4) // Rectangle has 4 sides
                {
                    double area = Cv2.ContourArea(contour);
                    if (area > maxArea)
                    {
                        maxArea = area;
                        largestRect = Cv2.BoundingRect(approx);
                    }
                }
            }

            return largestRect;
        }

        private List<OpenCvSharp.Point[]> DetectPlayers(UMat frame)
        {
            // Convert the frame to the HSV color space
            UMat hsvFrame = new UMat();
            Cv2.CvtColor(frame, hsvFrame, ColorConversionCodes.BGR2HSV);

            // Define color ranges for detecting blue and white
            Scalar lowerBlue = new Scalar(100, 150, 0);
            Scalar upperBlue = new Scalar(140, 255, 255);
            Scalar lowerWhite = new Scalar(0, 0, 200);
            Scalar upperWhite = new Scalar(180, 55, 255);

            // Threshold the frame to find blue and white regions
            UMat blueMask = new UMat();
            Cv2.InRange(hsvFrame, lowerBlue, upperBlue, blueMask);

            UMat whiteMask = new UMat();
            Cv2.InRange(hsvFrame, lowerWhite, upperWhite, whiteMask);

            // Combine the masks if both players could be wearing white
            UMat combinedMask = new UMat();
            Cv2.Add(blueMask, whiteMask, combinedMask);

            // Find contours in the thresholded image
            Cv2.FindContours(combinedMask, out OpenCvSharp.Point[][] contours, out _, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            // Filter contours by size to identify potential players
            List<OpenCvSharp.Point[]> playerContours = [];
            foreach (OpenCvSharp.Point[] contour in contours)
            {
                if (Cv2.ContourArea(contour) > 1000) // Adjust the contour area threshold as needed
                {
                    playerContours.Add(contour);
                }
            }

            return playerContours;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop playback
            _isPlaying = false;

            // Stop and dispose of audio resources
            try
            {
                if (waveOutDevice != null)
                {
                    waveOutDevice.Stop();
                    waveOutDevice.Dispose();
                    waveOutDevice = null;
                }

                if (audioFileReader != null)
                {
                    if (!audioFileReader.CanSeek)
                    {
                        Debug.WriteLine("[DEBUG] audioFileReader is not seekable, skipping dispose.");
                    }
                    else
                    {
                        audioFileReader.Dispose();
                        audioFileReader = null;
                    }
                }
            }
            catch (ObjectDisposedException ex)
            {
                Debug.WriteLine($"[ERROR] Object already disposed: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"[ERROR] Invalid operation while disposing resources: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] Unexpected error during form closing: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _ = this.Focus(); // Ensures the form has focus initially
            _ = picVideo.Focus(); // Focus the PictureBox to capture mouse events
        }

        private void picVideo_MouseClick(object sender, MouseEventArgs e)
        {
            TogglePlayPause();
        }

        #endregion

        private void tmrFormRefresh_Tick(object sender, EventArgs e)
        {
            this.Invalidate(); // This will redraw the form and its controls
        }
    }
}
