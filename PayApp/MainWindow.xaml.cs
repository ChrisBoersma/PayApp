using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace PayApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<User> _users;
        private User _selectedUser;
        private User _editedUser;
        private User? _payingUser;
        private bool _confirmDelete = false;
        private bool _confirmEdit = false;
        private double _price = 0;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        public User EditedUser
        {
            get { return _editedUser; }
            set
            {
                _editedUser = value;
                OnPropertyChanged();
            }
        }
        public User? PayingUser
        {
            get { return _payingUser; }
            set
            {
                _payingUser = value;
                OnPropertyChanged();
            }
        }
        public double Price
        {
            get { return _price; }
            set
            {
                _price = Math.Round(value, 2);
                OnPropertyChanged(nameof(PriceString));
            }
        }

        public string PriceString
        {
            get { return Price.ToString("F2", CultureInfo.CurrentCulture); }
            set { Price = double.Parse(value, CultureInfo.CurrentCulture); }
        }

        public string DeleteText
        {
            get { return $"Weet je zeker dat je \"{SelectedUser.Name}\" wilt verwijderen?"; }
        }

        public bool ConfirmDelete
        {
            get { return _confirmDelete; }
            set { _confirmDelete = value; }
        }

        public bool ConfirmEdit
        {
            get { return _confirmEdit; }
            set { _confirmEdit = value; }
        }

        public ObservableCollection<string> LogLines => Logger.GetLogLines();

        public MainWindow()
        {
            DataContext = this;
            Users = SaveLoadUsers.LoadUsers();
        }

        protected override void OnClosed(EventArgs e)
        {
            SaveLoadUsers.SaveUsers(Users);
            base.OnClosed(e);
        }

        public void AddUser(object sender, RoutedEventArgs e)
        {
            User newUser = new User();
            EditedUser = newUser;
            var userWindow = new UserWindow(this);
            userWindow.ShowDialog();
            if (ConfirmEdit)
            {
                Users.Add(newUser);
            }
        }

        public void DeleteUser(object sender, RoutedEventArgs e)
        {
            if (SelectedUser != null)
            {
                var DeleteWindow = new DeleteWindow(this);
                DeleteWindow.ShowDialog();
                if (ConfirmDelete)
                {
                    Users.Remove(SelectedUser);
                }
            }
        }

        public void EditUser(object sender, RoutedEventArgs e)
        {
            if (SelectedUser != null)
            {
                EditedUser = new User(SelectedUser);
                var userWindow = new UserWindow(this);
                userWindow.ShowDialog();
                if (ConfirmEdit)
                {
                    Users[Users.IndexOf(SelectedUser)] = EditedUser;
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DeleteUser(this, e);
            }
            base.OnKeyDown(e);
        }

        public void CalculatePayment(object sender, RoutedEventArgs e)
        {
            PaymentCalculator payCalc = new PaymentCalculator(Users.Where(x => x.Joins));
            PayingUser = payCalc.CalculatePayingUser();
        }

        public void Pay(object sender, RoutedEventArgs e)
        {
            if (PayingUser != null && PayingUser.Joins && Price > 0)
            {
                PaymentCalculator payCalc = new PaymentCalculator(Users.Where(x => x.Joins));
                payCalc.Pay(Price, PayingUser);
                Price = 0;
                PayingUser = null;
                OnPropertyChanged(nameof(LogLines));
            }
        }

        public void ChoosePayingUser(object sender, RoutedEventArgs e)
        {
            PayingUser = SelectedUser;
        }
    }
}
