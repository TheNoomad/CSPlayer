using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Threading;

namespace CSplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timerVideoTime = new DispatcherTimer();
        bool isPlaying = false;
        public MainWindow()
        {
            InitializeComponent();
            SetMediaElementDefault();

        }
        public void TimerStart()
        {
            timerVideoTime = new DispatcherTimer();
            timerVideoTime.Interval = TimeSpan.FromSeconds(0.1);
            timerVideoTime.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ShowPosition();
        }
        public void SetMediaElementDefault()
        {
            mainVideo.UnloadedBehavior = System.Windows.Controls.MediaState.Manual;
            mainVideo.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            TimerStart();
        }
        private void addVideoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog()
            {
                Filter = "(mp3,wav,mp4,mov,wmv,mpg)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg;*.avi|all files|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            if (ofg.ShowDialog() == true)
            {
                VideoLoad(ofg.FileName);
            }
        }
        public void CheckVideoState()
        {
            if (mainVideo.Source != null)
            {
                if (!isPlaying)
                {
                    mainVideo.Play();
                    isPlaying = true;
                }
                else if (isPlaying)
                {
                    mainVideo.Pause();
                    isPlaying = false;
                }
                timerVideoTime.IsEnabled = isPlaying;
            }
        }

        public void VideoLoad(string video)
        {
            mainVideo.Source = new Uri(video);
            CheckVideoState();
        }
        public void ShowPosition()
        {
            videoBar.Value = mainVideo.Position.TotalSeconds;
            //txtPosition.Text =
            //    minionPlayer.Position.TotalSeconds.ToString("0.0");
        }
        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            CheckVideoState();
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            CheckVideoState();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying == true)
            {
                mainVideo.Stop();
                isPlaying = false;
                mainVideo.Position = default;
            }
        }
        // початкові параметри для слайдерів (відеобар, звукбар)
        private void mainVideo_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (mainVideo.NaturalDuration.HasTimeSpan)
            {
                videoBar.Minimum = 0;
                videoBar.Maximum = mainVideo.NaturalDuration.TimeSpan.TotalSeconds;
                videoBar.Visibility = Visibility.Visible;
            }

            mainVideo.Volume = (double)volumeSlide.Value;
        }

        private void videoBar_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            TimeSpan timespan = TimeSpan.FromSeconds(videoBar.Value);
            mainVideo.Position = timespan;
            ShowPosition();
            mainVideo.Play();
            isPlaying = true;
        }

        private void videoBar_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (isPlaying)
            {
                mainVideo.Pause();
                isPlaying = false;
            }
        }

        private void volumeSlide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(isPlaying)
                mainVideo.Volume = (double)volumeSlide.Value;

        }
    }
}
