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

            Password pword = new Password(8, (int)Library.numbers,(int)Library.lowercase);
            Console.WriteLine("Created own password  " + pword.NewPassword());

            Console.WriteLine("Hex Password          " + Password.HexPasswordGen());
            Console.WriteLine("PIN Code-             " + Password.PinCodeGen());
        }
    }
}

