using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayApp
{
    internal class PaymentCalculator
    {
        private List<User> _JoiningUsers = new List<User>();
        private IEnumerable<User> Users { get; set; }
        private List<User> JoiningUsers => _JoiningUsers;
        public PaymentCalculator(IEnumerable<User> users)
        {
            Users = users;
        }

        public User? CalculatePayingUser()
        {
            User? payingUser = null;
            double maxCredits = double.MaxValue;
            foreach (var user in Users)
            {
                if (user.Joins)
                {
                    JoiningUsers.Add(user);
                    if (user.Credits < maxCredits)
                    {
                        maxCredits = user.Credits;
                        payingUser = user;
                    }
                }
            }

            return payingUser;
        }

        public void Pay(double price, User? payingUser)
        {
            if (payingUser == null)
            {
                return;
            }

            double pricePart = price / JoiningUsers.Count;

            foreach (var user in JoiningUsers)
            {
                if (user.Equals(payingUser))
                {
                    user.Credits += pricePart * (JoiningUsers.Count - 1);
                }
                else
                {
                    user.Credits -= pricePart;
                }
            }
        }
    }
}
