using System;

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
}
