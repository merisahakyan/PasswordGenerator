using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PwGen;

namespace Experiment
{
    class Program
    {
        static void Main(string[] args)
        {
            //for  "1234567890" - 0
            //for  "abcdefghijklmnopqrstuvwxyz" - 1
            //for  "ABCDEFGHIJKLMNOPQRSTUVWXYZ" - 2
            //for  "?!/-_.$#@&^()+*=`~" - 3
            //first digit in ctor is password's length
            Password pword = new Password(8, 1, 3, 3, 0);
            Console.WriteLine(pword.NewPassword());

            Console.WriteLine(Password.HexPasswordGen());
        }
    }
}
