using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ThreadPractice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread musicThread;

        public MainWindow()
        {
            InitializeComponent();

            musicThread = new Thread(StartMusic)
            {
                IsBackground = true
            };
            musicThread.Start();
            
        }

        private void StartMusic()
        {
            var player = new MediaPlayer();
            player.Open(new Uri("music.mp3", UriKind.Relative));
            player.Volume = 1;
            player.Play();
        }

        private void SaveText()
        {
            using (var stream = new StreamWriter("1.txt"))
            {
                stream.WriteLine(textBox.Text);
            }
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            SaveText();
            Close();
        }
    }
}
