using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ApiScheduler.Services
{
    public static class Support
    {
        public static bool IsValidNumber(this string number)
        {
            if (int.TryParse(number, out int outPut))
            {
                var reg = new Regex(@"^\d+$");
                if (reg.IsMatch(number))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public static string GetMd5(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                var hash = sBuilder.ToString();

                return hash;
            }
        }
    }
}