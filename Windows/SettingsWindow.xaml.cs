using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleTimers.Windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }
        private void overlayImageOpacityTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void overlayImageOpacityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Remove any non-numeric characters that might have been pasted or inserted.
            int caretIndex = textBox.CaretIndex;
            textBox.Text = Regex.Replace(textBox.Text, "[^0-9.]", "");
            textBox.CaretIndex = caretIndex; // Restore the caret position.
        }

        // Use this handler to prevent non-numeric paste operations
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = IsTextAllowed(Clipboard.GetText());
            e.Handled = true;
        }

        // If pasting is allowed, paste the text
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Paste operation is allowed by CanExecute
        }

        // Function to check if the text is numeric or a single decimal point
        private static bool IsTextAllowed(string text)
        {
            // This regex allows numeric input and decimal points
            return Regex.IsMatch(text, "^[0-9]*(?:\\.[0-9]*)?$");
        }
    }
}
