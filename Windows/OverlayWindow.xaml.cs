using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleTimers.Windows
{
    /// <summary>
    /// Interaction logic for OverlayWindow.xaml
    /// </summary>
    public partial class OverlayWindow : Window
    {
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TRANSPARENT = 0x00000020;
        private const int WS_EX_LAYERED = 0x00080000;

        private int _imageIndex = 0;
        private bool _isVisible = true;
        private bool _showOverlayImageNumber = true;

        private List<string> _imageList;

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_EXSTYLE,
                GetWindowLong(hwnd, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED);
        }

        public OverlayWindow(List<string> imageList, bool showOverlayImageNumber)
        {
            _imageList = imageList;
            _showOverlayImageNumber = showOverlayImageNumber;
            InitializeComponent();
            Loaded += new RoutedEventHandler(Window_Loaded);

            ShowImage();
        }

        public void NextImage()
        {
            _imageIndex++;
            if (_imageIndex >= _imageList.Count)
            {
                _imageIndex = _imageList.Count - 1;
            }

            ShowImage();
        }

        public void PreviousImage()
        {
            _imageIndex--;
            if (_imageIndex < 0)
            {
                _imageIndex = 0;
            }

            ShowImage();
        }

        private void ShowImage()
        {
            if (_imageList.Count > 0 && _imageIndex < _imageList.Count && _imageIndex >= 0)
            {
                try
                {

                    imageDisplay.Source = new BitmapImage(new Uri(_imageList[_imageIndex]));
                    errorLabel.Visibility = Visibility.Hidden;
                }
                catch (Exception e)
                {
                    errorLabel.Text = "Error loading image " + _imageList[_imageIndex] + ": " + e.Message;
                    errorLabel.Visibility = Visibility.Visible;
                }
                imageNumberLabel.Content = (_imageIndex + 1).ToString();
            }
            imageDisplay.Visibility = Visibility.Visible;
            imageNumberLabel.Visibility = _showOverlayImageNumber ? Visibility.Visible : Visibility.Hidden;
        }

        public void HideImage()
        {
            imageDisplay.Visibility = Visibility.Hidden;
            imageNumberLabel.Visibility = Visibility.Hidden;
        }

        public void ToggleImage()
        {
            _isVisible = !_isVisible;
            if (_isVisible)
            {
                ShowImage();
            }
            else
            {
                HideImage();
            }
        }

        private void OnBrowseButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp;*.gif)|*.png;*.jpeg;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                imageDisplay.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
