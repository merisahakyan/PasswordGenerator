using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace PwGen
{
    public class Password
    {
        const string numbers = "1234567890";
        const string alphabetlower = "abcdefghijklmnopqrstuvwxyz";
        const string alphabetupper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string symbols = "?!/-_.$#@&^()+*=`~";


        private char[] pin;
        private string alphabet = String.Empty;
        private string[] alphabetarray = { numbers, alphabetlower, alphabetupper, symbols };

        public Password(int length, params int[] condition)
        {
            if (length >= 6 && length <= 16)
                pin = new char[length];
            else
                throw new ArgumentOutOfRangeException("password's length must be more than 5 and less than 17 symbols");

            condition = RemoveEquals(condition);
            
            for (int i = 0; i < condition.Length; i++)

                if (condition[i] >= 0 && condition[i] <= 3)
                    alphabet += alphabetarray[condition[i]];
                else
                    throw new ArgumentOutOfRangeException("conditions must be equal 0,1,2 or3");


        }

        public char[] NewPassword()
        {
            byte[] data = new byte[pin.Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(data);
            var seed = BitConverter.ToInt32(data, 0);
            var rnd = new Random(seed);
            for (int i = 0; i < pin.Length; i++)
            {
                pin[i] = (char)alphabet[rnd.Next(0, alphabet.Length-1)];
            }
            return pin;
        }
        public string ToString(char[] pin)
        {
            string s = String.Empty; ;
            foreach (var m in pin)
                s = s + m;
            return s;
        }
        public  int [] RemoveEquals(int [] str)
        {
            List<int> newlist = new List<int>();
            int count = 0;
            for(int i=0;i<str.Length;i++)
            {
                count = 0;
                for (int j = 0; j < str.Length && j != i; j++)
                    if (str[i] == str[j])
                        count++;
                if (count == 0)
                    newlist.Add(str[i]);
                

            }
            return newlist.ToArray();

        }

    }
}
