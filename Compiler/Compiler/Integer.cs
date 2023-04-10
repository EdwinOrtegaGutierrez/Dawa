namespace Compiler
{
    internal class Integer
    {
<<<<<<< HEAD
        private int value;

        public Integer(int v) => value = v;

        public int GetValue() => value;

        public override string ToString() => value.ToString();
=======

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
>>>>>>> 0c154896f59fdc40efa46c52ba4d41108efdb9d0
    }
}
