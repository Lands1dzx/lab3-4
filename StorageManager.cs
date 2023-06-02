using lab3;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    public class StorageManager
    {
        public string Name;
        public string email;
        public int age;
        public Storages storages;
        public StorageManager(string storageManagerName, int storageManagerAge, string storageManagerEmail, Storages storag)
        {
            Validate(storageManagerName, storageManagerAge, storageManagerEmail);
            Name = storageManagerName;
            email = storageManagerEmail;
            age = storageManagerAge;
            storages = storag;
        }
        private void Validate(string storageManagerName, int storageManagerAge, string storageManagerEmail)
        {
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                 @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            string namePattern = "[а-я]$";

            var Exception = new List<string>();

            if (!Regex.IsMatch(storageManagerEmail, pattern, RegexOptions.IgnoreCase))
            {
                Exception.Add("Почта неправильная " + storageManagerEmail);
            }

            if (!Regex.IsMatch(storageManagerName, namePattern, RegexOptions.IgnoreCase))
            {
                Exception.Add("Извините, у вас неправильное имя " + storageManagerName);
            }

            if (storageManagerAge <= 0 )
            {
                Exception.Add("Неправильный возраст " + storageManagerAge);
            }

            if (Exception.Any())
            {
                throw new ArgumentException(string.Join("\n", Exception));
            }
        }
    }
}
