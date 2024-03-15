using Microsoft.Win32;
using SimpleTimers.Controls;
using SimpleTimers.Windows;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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
        private List<KeyboardBinding> bindings;
        private List<string> overlayImages;
        private OverlayWindow overlayWindow;

        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();

            GlobalKeyboardHook.SetHook(bindings);

            if (Properties.Settings.Default.EnableOverlayImages)
            {
                overlayWindow = new OverlayWindow(overlayImages);
                overlayWindow.Show();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            GlobalKeyboardHook.ReleaseHook();

            if (Properties.Settings.Default.EnableOverlayImages && overlayWindow != null)
            {
                overlayWindow.Close();
            }

            base.OnClosed(e);
        }

        private void LoadSettings()
        {
            bindings = new List<KeyboardBinding>();

            var settings = Properties.Settings.Default;


            if (Properties.Settings.Default.EnableOverlayImages)
            {
                string? prevModKey = settings.PreviousImageModifierKey != "" ? settings.PreviousImageModifierKey : null;
                string? nextModKey = settings.NextImageModifierKey != "" ? settings.NextImageModifierKey : null;

                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = prevModKey,
                    Key = Properties.Settings.Default.PreviousImageKey,
                    Callback = () => overlayWindow.PreviousImage(),
                });

                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = nextModKey,
                    Key = Properties.Settings.Default.NextImageKey,
                    Callback = () => overlayWindow.NextImage(),
                });
                overlayImages = Properties.Settings.Default.OverlayImages.Split(",").ToList();
            }

            gameTimer1.Duration = Properties.Settings.Default.Timer1Duration;
            gameTimer2.Duration = Properties.Settings.Default.Timer2Duration;
            gameTimer3.Duration = Properties.Settings.Default.Timer3Duration;
            gameTimer4.Duration = Properties.Settings.Default.Timer4Duration;
            gameTimer5.Duration = Properties.Settings.Default.Timer5Duration;
            gameTimer1.Text = Properties.Settings.Default.Timer1Label;
            gameTimer2.Text = Properties.Settings.Default.Timer2Label;
            gameTimer3.Text = Properties.Settings.Default.Timer3Label;
            gameTimer4.Text = Properties.Settings.Default.Timer4Label;
            gameTimer5.Text = Properties.Settings.Default.Timer5Label;

            if (Properties.Settings.Default.Timer1Enabled)
            {
                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = Properties.Settings.Default.Timer1ModifierKey,
                    Key = Properties.Settings.Default.Timer1Keybind,
                    Callback = () => StartTimer1(),
                });
            }

            if (Properties.Settings.Default.Timer2Enabled)
            {
                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = Properties.Settings.Default.Timer2ModifierKey,
                    Key = Properties.Settings.Default.Timer2Keybind,
                    Callback = () => StartTimer2(),
                });
            }

            if (Properties.Settings.Default.Timer3Enabled)
            {
                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = Properties.Settings.Default.Timer3ModifierKey,
                    Key = Properties.Settings.Default.Timer3Keybind,
                    Callback = () => StartTimer3(),
                });
            }

            if (Properties.Settings.Default.Timer4Enabled)
            {
                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = Properties.Settings.Default.Timer4ModifierKey,
                    Key = Properties.Settings.Default.Timer4Keybind,
                    Callback = () => StartTimer4(),
                });
            }

            if (Properties.Settings.Default.Timer5Enabled)
            {
                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = Properties.Settings.Default.Timer5ModifierKey,
                    Key = Properties.Settings.Default.Timer5Keybind,
                    Callback = () => StartTimer5(),
                });
            }

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

        public void StartTimer3()
        {
            gameTimer3.Visibility = Visibility.Visible;
            gameTimer3.StartTimer();
        }

        public void StartTimer4()
        {
            gameTimer4.Visibility = Visibility.Visible;
            gameTimer4.StartTimer();
        }

        public void StartTimer5()
        {
            gameTimer5.Visibility = Visibility.Visible;
            gameTimer5.StartTimer();
        }

        public void NextImage()
        {
            overlayWindow.NextImage();
        }

        public void PreviousImage()
        {
            overlayWindow.PreviousImage();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }



        //private void SetWindowPositionToPrimaryMonitor()
        //{
        //    // Get the primary screen's working area
        //    var primaryScreen = Screen.PrimaryScreen.WorkingArea;

        //    // Convert the screen's position from pixels to WPF units
        //    double dpiX, dpiY;
        //    var presentationSource = PresentationSource.FromVisual(this);
        //    if (presentationSource != null) // Ensure the window is connected to a presentation source
        //    {
        //        dpiX = 96.0 * presentationSource.CompositionTarget.TransformToDevice.M11;
        //        dpiY = 96.0 * presentationSource.CompositionTarget.TransformToDevice.M22;
        //    }
        //    else
        //    {
        //        dpiX = 96.0; // Default DPI; adjust if necessary for your environment
        //        dpiY = 96.0;
        //    }

        //    // Set the window's position to the primary monitor
        //    this.Left = primaryScreen.Left * 96 / dpiX;
        //    this.Top = primaryScreen.Top * 96 / dpiY;
        //    this.Width = primaryScreen.Width * 96 / dpiX;
        //    this.Height = primaryScreen.Height * 96 / dpiY;
        //}
    }
}