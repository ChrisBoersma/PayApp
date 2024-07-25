using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace PayApp
{
    public partial class UserWindow : Window
    {
        private MainWindow _mainWindow;
        public UserWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            DataContext = mainWindow.DataContext;
            InitializeComponent();
        }
        public void ConfirmEditYes(object sender, RoutedEventArgs e)
        {
            _mainWindow.ConfirmEdit = true;
            Close();
        }
        public void ConfirmEditNo(object sender, RoutedEventArgs e)
        {
            _mainWindow.ConfirmEdit = false;
            Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmEditYes(this, e);
            }
            base.OnKeyDown(e);
        }
    }
}
