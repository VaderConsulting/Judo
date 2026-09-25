using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Media_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PlayVideo();
        }

        private void PlayVideo()
        {
            //second monitor full screen  
            System.Drawing.Rectangle area = System.Windows.Forms.Screen.AllScreens[0].WorkingArea;
            Window w = new Window();
            Grid g = new Grid();
            Rectangle r = new Rectangle();
            DrawingBrush b = new DrawingBrush();
            VideoDrawing d = new VideoDrawing();

            this.Closed += (sender, e) => 
            
{
                w.Close();
            };

            w.ShowInTaskbar = false;
            w.Topmost = true;
            w.WindowStyle = WindowStyle.None;
            w.Loaded += (sender, e) => { w.WindowState = WindowState.Maximized; };
            w.Left = area.Left;
            w.Top = area.Top;
            w.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            w.Content = g;
            g.Children.Add(r);
            r.Fill = b;
            b.Drawing = d;
            d.Player = VideoPlayer;
            d.Rect = new System.Windows.Rect(0, 0, 640, 480);
            w.Show();
            // 
            //TransformGroup group = new TransformGroup();
            //group.Children.Add(new RotateTransform(180));
            //group.Children.Add(new TranslateTransform(w.Width, w.Height));
            //w.RenderTransform = group;
            //
            VideoPlayer.Open(new Uri(@"C:\Users\YourUser\Videos\20171028_160504.mp4", UriKind.Absolute));
            VideoPlayer.MediaOpened += (sender, e) => {
                //set aspect ratio 
                double ratio = Math.Min(240d / VideoPlayer.NaturalVideoHeight, 320d / VideoPlayer.NaturalVideoWidth);

                VideoDisplay.Height = VideoPlayer.NaturalVideoHeight * ratio;
                VideoDisplay.Width = VideoPlayer.NaturalVideoWidth * ratio;
                
                ratio = Math.Min(w.ActualHeight / VideoPlayer.NaturalVideoHeight,
                         w.ActualWidth / VideoPlayer.NaturalVideoWidth);
                r.Height = VideoPlayer.NaturalVideoHeight * ratio;
                r.Width = VideoPlayer.NaturalVideoWidth * ratio;
            };
            VideoPlayer.Play();
        }

    }
}
