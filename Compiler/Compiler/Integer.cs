using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    internal class Integer
    {

        //Saber si es un entero
        private bool integer(string num)
        {

            if(num.GetType == int) { 
            int i = 0;

                while (i < num.length)
                {
                    if (num[i] == "int =")
                    {
                        return true;
                    }
                    i = i + 1;
                }
            }
            else
            {
                Console.Write("El tipo de dato no es entero");
                return false;
            }
        }
    }
}
