using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PayApp
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private double _credits;
        public double Credits
        {
            get { return _credits; }
            set
            {
                _credits = Math.Round(value, 2);
                OnPropertyChanged(nameof(CreditsString));
            }
        }

        public string CreditsString => Credits.ToString("F2", CultureInfo.CurrentCulture);
        public string Name { get; set; }
        public bool Joins { get; set; }

        public User (string name, string credits)
        {
            Name = name;
            Credits = double.Parse(credits, CultureInfo.InvariantCulture);
            Joins = false;
        }

        public User(User user)
        {
            Name = user.Name;
            Credits = user.Credits;
            Joins = user.Joins;
        }

        public User()
        {
            Name = "";
            Credits = 0;
            Joins = false;
        }
    }
}
