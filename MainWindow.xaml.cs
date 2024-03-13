using System.Text;
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

namespace SimpleTimers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private DispatcherTimer timer;
        //private const double duration = 30 * 1.927; // Duration of the timer in seconds
        //private DateTime startTime;
        //private TimeSpan elapsedTime;

        public MainWindow()
        {
            InitializeComponent();
            //InitializeTimer();
            GlobalKeyboardHook.SetHook();
        }

        protected override void OnClosed(EventArgs e)
        {
            GlobalKeyboardHook.ReleaseHook();
            base.OnClosed(e);
        }

        public void StartTimer1()
        {
            gameTimer1.Visibility = Visibility.Visible;
            gameTimer1.StartTimer();
        }

        public void StartTimer2()
        {
            gameTimer2.Visibility = Visibility.Visible;
            gameTimer2.StartTimer();
        }
    }
}