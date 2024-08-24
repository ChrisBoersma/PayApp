﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace PayApp
{
    internal class Logger
    {
        public static void Log(double price, User payingUser, IEnumerable<User> joiningUsers)
        {
            string text = GetText(price, payingUser, joiningUsers);
            string fileName = SaveLoadUsers.GetFileName();
            string logFileName = fileName.Split('.')[0] + "_Log." + fileName.Split(".")[1];
            File.AppendAllText(logFileName, text);
        }

        private static string GetText(double price, User payingUser, IEnumerable<User> joiningUsers)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToShortDateString());
            sb.Append('\t');
            sb.Append(payingUser.Name);
            sb.Append('\t');
            sb.Append(price.ToString("C2"));
            sb.Append("\t\t");
            foreach (User user in joiningUsers)
            {
                sb.Append(user.Name);
                sb.Append('\t');
                if (user.ChangeInCredit > 0)
                {
                    sb.Append("+");
                }
                sb.Append(user.ChangeInCredit.ToString("F2", CultureInfo.CurrentCulture));
                sb.Append('\t');
            }
            sb.Append('\n');
            return sb.ToString();
        }
    }
}
