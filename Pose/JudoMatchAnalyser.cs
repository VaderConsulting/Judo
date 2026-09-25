using OpenCvSharp;

public class JudoMatchAnalyzer
{
    private Mat _frame;
    private Scalar _yellowLower = new Scalar(200, 147, 17); // Adjust these HSV ranges
    private Scalar _yellowUpper = new Scalar(213, 158.13);
    private Scalar _blueLower = new Scalar(19, 12, 24);
    private Scalar _blueUpper = new Scalar(32, 35, 55);
    private Scalar _whiteLower = new Scalar(107, 90, 63);
    private Scalar _whiteUpper = new Scalar(184, 167, 112);

    public JudoMatchAnalyzer(Mat frame)
    {
        _frame = frame;

        // Define RGB colors
        OpenCvSharp.Scalar yellowRgb = new OpenCvSharp.Scalar(0, 255, 255); // Yellow in BGR (since OpenCV uses BGR)
        OpenCvSharp.Scalar blueRgb = new OpenCvSharp.Scalar(255, 0, 0);     // Blue in BGR
        OpenCvSharp.Scalar whiteRgb = new OpenCvSharp.Scalar(255, 255, 255); // White in BGR

        // Convert RGB to HSV
        OpenCvSharp.Scalar yellowHsv = ConvertRgbToHsv(yellowRgb);
        OpenCvSharp.Scalar blueHsv = ConvertRgbToHsv(blueRgb);
        OpenCvSharp.Scalar whiteHsv = ConvertRgbToHsv(whiteRgb);

        // Define Scalar ranges for OpenCV
        _yellowLower = new OpenCvSharp.Scalar(yellowHsv.Val0 - 10, 100, 100);
        _yellowUpper = new OpenCvSharp.Scalar(yellowHsv.Val0 + 10, 255, 255);

        _blueLower = new OpenCvSharp.Scalar(blueHsv.Val0 - 10, 150, 0);
        _blueUpper = new OpenCvSharp.Scalar(blueHsv.Val0 + 10, 255, 255);

        _whiteLower = new OpenCvSharp.Scalar(whiteHsv.Val0 - 10, 0, 200);
        _whiteUpper = new OpenCvSharp.Scalar(whiteHsv.Val0 + 10, 30, 255);
    }

    private OpenCvSharp.Scalar ConvertRgbToHsv(OpenCvSharp.Scalar rgbColor)
    {
        using (Mat rgbMat = new OpenCvSharp.Mat(1, 1, OpenCvSharp.MatType.CV_8UC3, rgbColor))
        using (Mat hsvMat = new OpenCvSharp.Mat())
        {
            Cv2.CvtColor(rgbMat, hsvMat, OpenCvSharp.ColorConversionCodes.BGR2HSV);
            Vec3b hsvVec = hsvMat.At<OpenCvSharp.Vec3b>(0, 0);
            return new OpenCvSharp.Scalar(hsvVec.Item0, hsvVec.Item1, hsvVec.Item2);
        }
    }

    public void AnalyzeFrame()
    {
        // Convert the frame to HSV color space for better color segmentation
        Mat hsv = new Mat();
        Cv2.CvtColor(_frame, hsv, ColorConversionCodes.BGR2HSV);

        // Detect the mat area (yellow)
        Mat matMask = new Mat();
        Cv2.InRange(hsv, _yellowLower, _yellowUpper, matMask);

        // Find contours of the mat area
        Cv2.FindContours(matMask, out OpenCvSharp.Point[][] matContours, out _, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

        // Assuming the largest contour is the mat area
        Rect matRect = new Rect();
        double maxArea = 0;
        foreach (OpenCvSharp.Point[] contour in matContours)
        {
            double area = Cv2.ContourArea(contour);
            if (area > maxArea)
            {
                maxArea = area;
                matRect = Cv2.BoundingRect(contour);
            }
        }

        // Draw the mat area on the original frame
        Cv2.Rectangle(_frame, matRect, Scalar.Red, 2);

        // Detect players across the entire frame using blue and white color ranges
        Mat blueMask = new Mat();
        Cv2.InRange(hsv, _blueLower, _blueUpper, blueMask);

        Mat whiteMask = new Mat();
        Cv2.InRange(hsv, _whiteLower, _whiteUpper, whiteMask);

        Mat playersMask = new Mat();
        Cv2.BitwiseOr(blueMask, whiteMask, playersMask);

        // Find contours for the players
        Cv2.FindContours(playersMask, out OpenCvSharp.Point[][] playerContours, out _, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

        foreach (OpenCvSharp.Point[] contour in playerContours)
        {
            // Assuming players are the largest contours, draw bounding boxes
            Rect playerRect = Cv2.BoundingRect(contour);
            Cv2.Rectangle(_frame, playerRect, Scalar.Green, 2);

            // Check if the player is inside or outside the mat area
            if (matRect.Contains(new OpenCvSharp.Point(playerRect.X + (playerRect.Width / 2), playerRect.Y + (playerRect.Height / 2))))
            {
                Cv2.PutText(_frame, "Inside Mat", new OpenCvSharp.Point(playerRect.X, playerRect.Y - 10), HersheyFonts.HersheySimplex, 0.5, Scalar.White, 2);
            }
            else
            {
                Cv2.PutText(_frame, "Outside Mat", new OpenCvSharp.Point(playerRect.X, playerRect.Y - 10), HersheyFonts.HersheySimplex, 0.5, Scalar.White, 2);
            }
        }

        // Optionally show the result
        Cv2.ImShow("Detected Players and Mat", _frame);
        _ = Cv2.WaitKey(0);
    }
}
