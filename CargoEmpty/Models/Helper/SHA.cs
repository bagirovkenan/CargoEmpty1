using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CargoEmpty.Models.Helper
{
    public static class SHA
    {
        public static string ChangePSW(string ps)
        {
            SHA1 myEncrypt = new SHA1CryptoServiceProvider();
            string data = ps;
            var dataForEncrypt = Encoding.UTF8.GetBytes(data);
            var byteResult = myEncrypt.ComputeHash(dataForEncrypt);
            var EnResult = byteResult.Select(s => s.ToString("X2")).ToArray();
            var result = String.Join("", EnResult);

            return result;
        }

        ////////////////////////////////////////////////////////////////////
        ///
        public static string CustumSHA(string text)
        {
            string firstText = ChangePSW(text.Substring(0, 3));
            string secondText = ChangePSW(text.Substring(3));
            string AllTExt = firstText + secondText;
            string HashPassword = ChangePSW(AllTExt);
           

            return HashPassword;
        }
    }
}