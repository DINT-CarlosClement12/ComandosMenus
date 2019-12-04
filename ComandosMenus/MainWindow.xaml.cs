using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace ComandosMenus
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string clipboard;

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 1000),
                IsEnabled = true
            };
            timer.Tick += IntervalElapsed;
            timer.Start();
        }

        private void IntervalElapsed(object sender, EventArgs e)
        {
            HourTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        #region COMMANDS

        private void FileCommands_Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void FileCommands_Exit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void FileCommands_New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBoxItem itm = new ListBoxItem
            {
                Content = "Añadido: " + HourTextBlock.Text
            };

            ItemsListBox.Items.Add(itm);
        }

        private void FileCommands_New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ItemsListBox != null)
                e.CanExecute = ItemsListBox.Items.Count <= 10;
            else
                e.CanExecute = true;
        }

        private void FileCommands_Copy_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            clipboard = ((ListBoxItem)ItemsListBox.SelectedItem).Content.ToString();
        }

        private void FileCommands_Copy_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ItemsListBox != null)
                e.CanExecute = ItemsListBox.SelectedItem != null;
            else
                e.CanExecute = true;
        }

        private void FileCommands_Paste_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBoxItem itm = new ListBoxItem
            {
                Content = clipboard
            };

            clipboard = null;

            ItemsListBox.Items.Add(itm);
        }

        private void FileCommands_Paste_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = clipboard != null && ItemsListBox != null && ItemsListBox.Items.Count <= 10;
        }

        private void FileCommands_Clear_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ItemsListBox.Items.Clear();
        }

        private void FileCommands_Clear_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ItemsListBox != null)
                e.CanExecute = ItemsListBox.Items.Count > 0;
            else
                e.CanExecute = false;
        }

        #endregion COMMANDS
    }
}
