using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FinReconcile.Infra
{
    public class SessionIdGenerator
    {
        public static string CreateNewId()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            int len = 5;

            Random rnd = new Random();
            StringBuilder b = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                b.Append(chars[rnd.Next(chars.Length)]);
            }
            return b.ToString();
        }
    }
}