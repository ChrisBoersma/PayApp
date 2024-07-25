using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;

namespace PayApp
{
    internal class SaveLoadUsers
    {
        private const string _filePath = @"c:\Users\Chris\Documents\Code\Csharp\PayApp\";
        private static string _fileName = "";
        public static ObservableCollection<User> LoadUsers()
        {
            ObservableCollection<User> userCollection = new ObservableCollection<User>();
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = _filePath;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _fileName = openFileDialog.FileName;
                string[] lines = File.ReadAllLines(_fileName);
                foreach (var line in lines)
                {
                    string[] items = line.Split(',');
                    User user = new User(items[0], items[1]);
                    userCollection.Add(user);
                }
            }
            return userCollection;
        }

        public static void SaveUsers(ObservableCollection<User> users)
        {
            ObservableCollection<string> lines = new ObservableCollection<string>();
            foreach (User user in users)
            {
                lines.Add($"{user.Name},{user.Credits.ToString(CultureInfo.InvariantCulture)}");
            }
            if (_fileName != "")
            {
                File.WriteAllLines(_fileName, lines);
            }
        }

    }
}
