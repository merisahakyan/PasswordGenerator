#Class Library for generating passwords
The Class Library **PwGen** has a class **Password**, which consists of one **NewPassword()** not static and two **HexPasswordGen()** , **PinCodeGen()** static methods. **NewPassword()** method generates a password with choosen alphabet and with given length(length must be equal to 6 or more).The constructor Password(int length, params int[] condition) has argument with type _params_, wich allows you to choose alphabet for your password.Here is method **RemoveEquals(int[] str)** ,which removes the equal members from the given  _int_ array.With this library you can also generate passwords **HEX** and **Pin Codes**(with 4 length).

##Here are trial code
```cs
using System;
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
```
##And the result is:
![result](https://github.com/marysahakyan/PasswordGenerator/blob/master/passgen.png)
