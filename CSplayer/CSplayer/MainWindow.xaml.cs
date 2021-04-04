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

namespace CSplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void TestStart()
        {
            mainVideo.Source = new Uri(@"D:\ДУТ\Diplom\Material\Video.avi");
        }

        private void DropPanel_Drop(object sender, DragEventArgs e)
        {
            MessageBox.Show("Oh hi Mark");
        }

        private void DropPanel_DragEnter(object sender, DragEventArgs e)
        {
            TestStart();
        }

        private void DropPanel_GotMouseCapture(object sender, MouseEventArgs e)
        {
            TestStart();
        }

        private void DropPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            TestStart();
        }

        private void addVideoButton_Click(object sender, RoutedEventArgs e)
        {
            TestStart();
        }
    }
}
