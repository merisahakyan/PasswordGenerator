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
            Password pword = new Password(8, 0, 1, 2);
            Console.WriteLine("Created own password  "+pword.NewPassword());

            Console.WriteLine("Hex Password          "+Password.HexPasswordGen());
            Console.WriteLine("PIN Code-             "+Password.PinCodeGen());
        }
    }
}
