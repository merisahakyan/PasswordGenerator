#Password Generator
###Example

```cs
using System;
Using PwGen;
namespace Experiment
{
     class Program
       {
     
        static void Main(string[] args)
        {
            /* 
             for  "1234567890" - 0 
             for  "abcdefghijklmnopqrstuvwxyz" - 1
             for  "ABCDEFGHIJKLMNOPQRSTUVWXYZ" - 2
             for  "?!/-_.$#@&^()+*=~" - 3
             first digit in ctor is password's length,other digits are for choosing alphabet for your password  
             */
            Password pword = new Password(8,1,3,3,0);
            var password = pword.NewPassword();  //generating new password from choosen alphabet
            Console.WriteLine(pword.ToString(password));
        }
    }
}
```
