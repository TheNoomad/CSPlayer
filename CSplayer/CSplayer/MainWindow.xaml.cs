using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using System.IO;

namespace CSplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timerVideoTime = new DispatcherTimer();
        bool isPlaying = false;
        List<string> playList = new List<string>();
        string currentVideoName;
        int currentVideoNumber;
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

            if (mainVideo.Source != null)
            {
                if (mainVideo.NaturalDuration.HasTimeSpan)
                    videoTime.Content = String.Format("{0} / {1}", mainVideo.Position.ToString(@"mm\:ss"), mainVideo.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
            else
                videoTime.Content = "No file selected...";
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
            ofg.Multiselect = true;
            if (ofg.ShowDialog() == true)
            {
                foreach (string item in ofg.FileNames)
                    { 
                        playList.Add(item);
                    }
                VideoLoad(playList[0], 0);
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

        public void VideoLoad(string video, int position)
        {
            mainVideo.Source = new Uri(video);
            currentVideoName = video;
            currentVideoNumber = position;
            SetVideoName();
            CheckVideoState();
        }
        public void ChangeVideo(string video, int position)
        {
            mainVideo.Source = new Uri(video);
            currentVideoName = video;
            currentVideoNumber = position;
            SetVideoName();
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
            if (isPlaying)
                mainVideo.Volume = (double)volumeSlide.Value;
        }

        private void previousVideoButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                if (currentVideoNumber == 0)
                {
                    ChangeVideo(playList[playList.Count-1], playList.Count-1);
                }
                else
                {
                    ChangeVideo(playList[currentVideoNumber - 1], currentVideoNumber - 1);
                }
                mainVideo.Play();
            }
        }

        private void nextVideoButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                if (currentVideoNumber + 1 != playList.Count)
                {
                    ChangeVideo(playList[currentVideoNumber + 1], currentVideoNumber + 1);
                }
                else
                {
                    ChangeVideo(playList[0], 0);
                }
                mainVideo.Play();
            }
        }
        public void SetVideoName()
        {
            nameOfTheVideoLabel.Content = Path.GetFileName(currentVideoName);
        }
    }
}
