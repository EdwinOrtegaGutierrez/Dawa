using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    internal class Float
    {
        private double value;

        public Float(double v) => value = v;

        public double GetValue() => value;

        public override string ToString() => value.ToString();
    }
=======

public class Class1
{
	public Class1()
	{
		private bool flotantes(float num)
		{
            if (num.GetType == float) {
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
                Console.Write("El tipo de dato no es flotante");
                return false;
            }
        }
	}
>>>>>>> 0c154896f59fdc40efa46c52ba4d41108efdb9d0
}
