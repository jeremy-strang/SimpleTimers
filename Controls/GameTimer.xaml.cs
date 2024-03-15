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
using System.Windows.Threading;

namespace SimpleTimers.Controls
{
    /// <summary>
    /// Interaction logic for GameTimer.xaml
    /// </summary>
    public partial class GameTimer : UserControl
    {
        private DispatcherTimer timer;
        //private const double duration = 30 * 1.927; // Duration of the timer in seconds
        private DateTime startTime;
        private TimeSpan elapsedTime;

        public double Duration { get; set; }
        public string Text { get; set; }

        public GameTimer()
        {
            InitializeComponent();
            InitializeTimer();
        }


        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.1); // Timer tick interval is one second
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime = DateTime.Now - startTime;
            double totalSec = elapsedTime.TotalSeconds;
            progressBar.Value = (totalSec / Duration) * 100;
            timeText.Text = $"{(Duration - totalSec):N0} seconds remaining";

            if (progressBar.Value >= progressBar.Maximum)
            {
                timer.Stop(); // Stop the timer if the progress bar is full
                timeText.Text = ""; // Clear the text or set to some final message
                timerWrap.Visibility = Visibility.Collapsed;
            }
        }

        public void StartTimer()
        {
            timerLabel.Text = Text;
            timerWrap.Visibility = Visibility.Visible;
            progressBar.Value = 0;
            startTime = DateTime.Now;
            timer.Start();
        }
    }
}
