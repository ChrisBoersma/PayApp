using System.Windows;
using System.Windows.Input;

namespace PayApp
{
    public partial class DeleteWindow : Window
    { 
        private MainWindow _mainWindow;
        public DeleteWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            DataContext = mainWindow.DataContext;
            InitializeComponent();
        }
        public void ConfirmDeleteYes(object sender, RoutedEventArgs e)
        {
            _mainWindow.ConfirmDelete = true;
            Close();
        }
        public void ConfirmDeleteNo(object sender, RoutedEventArgs e)
        {
            _mainWindow.ConfirmDelete = false;
            Close();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _mainWindow.ConfirmDelete = true;
                Close();
            }
            base.OnKeyDown(e);
        }
    }
}
