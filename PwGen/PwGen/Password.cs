using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace PwGen
{
    public enum Library
    {
        numbers,
        lowercase,
        uppercase,
        symbols
    }

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

        public string NewPassword()
        {
            byte[] data = new byte[pin.Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(data);
            var seed = BitConverter.ToInt32(data, 0);
            var rnd = new Random(seed);
            for (int i = 0; i < pin.Length; i++)
            {
                pin[i] = (char)alphabet[rnd.Next(0, alphabet.Length - 1)];
            }
            return Password.ToString(pin);
        }

        public static string HexPasswordGen()
        {

            char[] pin = new char[19];
            string hex = "0123456789abcdefABCDEF";
            byte[] data = new byte[pin.Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(data);
            var seed = BitConverter.ToInt32(data, 0);
            var rnd = new Random(seed);
            for (int i = 0; i < 19; i++)
            {
                if (i != 4 && i != 9 && i != 14)
                    pin[i] = (char)hex[rnd.Next(0, hex.Length - 1)];
                else
                    pin[i] = '-';
            }
            return Password.ToString(pin);


        }

        public static string PinCodeGen()
        {
            char[] pin = new char[4];
            string pincode = "0123456789";
            byte[] data = new byte[pin.Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(data);
            var seed = BitConverter.ToInt32(data, 0);
            var rnd = new Random(seed);
            for (int i = 0; i < pin.Length; i++)
            {
                pin[i] = (char)pincode[rnd.Next(0, pincode.Length - 1)];
            }
            return Password.ToString(pin);
        }
        public static string ToString(char[] pin)
        {
            string s = String.Empty; ;
            foreach (var m in pin)
                s = s + m;
            return s;
        }
        public int[] RemoveEquals(int[] str)
        {
            List<int> newlist = new List<int>();
            int count = 0;
            for (int i = 0; i < str.Length; i++)
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
