﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayApp
{
    internal class PaymentCalculator
    {
        private IEnumerable<User> JoiningUsers { get; set; }
        public PaymentCalculator(IEnumerable<User> users)
        {
            JoiningUsers = users;
        }

        public User? CalculatePayingUser()
        {
            /*
            User? payingUser = null;
            double maxCredits = double.MaxValue;
            foreach (var user in JoiningUsers)
            {
                if (user.Credits < maxCredits)
                {
                    maxCredits = user.Credits;
                    payingUser = user;
                }
            }
            return payingUser;
            */
            return JoiningUsers.MinBy(x => x.Credits);
        }

        public void Pay(double price, User? payingUser)
        {
            double pricePart = price / JoiningUsers.Count();

            foreach (var user in JoiningUsers)
            {
                if (user.Equals(payingUser))
                {
                    user.Credits += pricePart * (JoiningUsers.Count() - 1);
                }
                else
                {
                    user.Credits -= pricePart;
                }
            }
        }
    }
}
