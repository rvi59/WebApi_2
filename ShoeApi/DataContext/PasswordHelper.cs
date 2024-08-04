using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ShoeApi.DataContext
{
    public class PasswordHelper
    {
        public static string EncodePassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] encodedBytes = new SHA256Managed().ComputeHash(passwordBytes);
            return Convert.ToBase64String(encodedBytes);
        }


        public static string DecodePassword(string encodedPassword)
        {
            byte[] encodedBytes = Convert.FromBase64String(encodedPassword);
            byte[] passwordBytes = new SHA256Managed().ComputeHash(encodedBytes);
            return Encoding.UTF8.GetString(passwordBytes);
        }

        public static bool ValidateEmail(string emailAddress)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            bool isValid = Regex.IsMatch(emailAddress, pattern);

            return isValid;
        }

    }
}