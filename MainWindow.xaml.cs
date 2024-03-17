using Microsoft.Win32;
using SimpleTimers.Controls;
using SimpleTimers.Windows;
using System.Drawing;
using System.IO;
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
        private SettingsWindow settingsWindow;

        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();

            GlobalKeyboardHook.SetHook(bindings);

            overlayWindow = new OverlayWindow(overlayImages, Properties.Settings.Default.ShowOverlayImageNumber);
            overlayWindow.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            GlobalKeyboardHook.ReleaseHook();

            overlayWindow.Close();

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
                string? overlayToggleModKey = settings.OverlayToggleModifierKey != "" ? settings.OverlayToggleModifierKey : null;

                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = prevModKey,
                    Key = settings.PreviousImageKey,
                    Callback = () => overlayWindow.PreviousImage(),
                });

                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = nextModKey,
                    Key = settings.NextImageKey,
                    Callback = () => overlayWindow.NextImage(),
                });

                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = overlayToggleModKey,
                    Key = settings.OverlayToggleKey,
                    Callback = () => overlayWindow.ToggleImage(),
                });
                overlayImages = settings.OverlayImages.Split(",").Where(x => !String.IsNullOrEmpty(x) && File.Exists(x)).ToList();
            }

            if (settings.Timer1Enabled)
            {
                string? modKey1 = settings.Timer1ModifierKey != "" ? settings.Timer1ModifierKey : null;
                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = modKey1,
                    Key = settings.Timer1Keybind,
                    Callback = () => overlayWindow.StartTimer1(),
                    PassThrough = settings.Timer1PassThrough,
                });
            }

            if (settings.Timer2Enabled)
            {
                string? modKey2 = settings.Timer2ModifierKey != "" ? settings.Timer2ModifierKey : null;
                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = modKey2,
                    Key = settings.Timer2Keybind,
                    Callback = () => overlayWindow.StartTimer2(),
                    PassThrough = settings.Timer2PassThrough,
                });
            }

            if (settings.Timer3Enabled)
            {
                string? modKey3 = settings.Timer3ModifierKey != "" ? settings.Timer3ModifierKey : null;
                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = modKey3,
                    Key = settings.Timer3Keybind,
                    Callback = () => overlayWindow.StartTimer3(),
                    PassThrough = settings.Timer3PassThrough,
                });
            }

            if (settings.Timer4Enabled)
            {
                string? modKey4 = settings.Timer4ModifierKey != "" ? settings.Timer4ModifierKey : null;
                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = modKey4,
                    Key = settings.Timer4Keybind,
                    Callback = () => overlayWindow.StartTimer4(),
                    PassThrough = settings.Timer4PassThrough,
                });
            }

            if (settings.Timer5Enabled)
            {
                string? modKey5 = settings.Timer5ModifierKey != "" ? settings.Timer5ModifierKey : null;
                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = modKey5,
                    Key = settings.Timer5Keybind,
                    Callback = () => overlayWindow.StartTimer5(),
                    PassThrough = settings.Timer5PassThrough,
                });
            }

            if (settings.Timer6Enabled)
            {
                string? modKey6 = settings.Timer6ModifierKey != "" ? settings.Timer6ModifierKey : null;
                bindings.Add(new KeyboardBinding
                {
                    ModifierKey = modKey6,
                    Key = settings.Timer6Keybind,
                    Callback = () => overlayWindow.StartTimer6(),
                    PassThrough = settings.Timer6PassThrough,
                });
            }
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
            settingsWindow = new SettingsWindow();
            GlobalKeyboardHook.ReleaseHook();
            if (overlayWindow != null)
            {
                overlayWindow.Close();
            }
            settingsWindow.ShowDialog();
            LoadSettings();
            GlobalKeyboardHook.SetHook(bindings);
            if (Properties.Settings.Default.EnableOverlayImages)
            {
                overlayWindow = new OverlayWindow(overlayImages, Properties.Settings.Default.ShowOverlayImageNumber);
                overlayWindow.Show();
            }
        }
    }
}