namespace Compiler
{
    public class Operator
    {
        // +
        public static T Add<T>(T a, T b) where T : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(T).IsPrimitive || typeof(T) == typeof(bool))
            {
                throw new ArgumentException("Type must be a numeric primitive.");
            }
            return (T)((dynamic)a + (dynamic)b);
        }
        // -
        public static T Subtract<T>(T a, T b) where T : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(T).IsPrimitive || typeof(T) == typeof(bool))
            {
                throw new ArgumentException("Type must be a numeric primitive.");
            }
            return (T)(dynamic)a - (dynamic)b;
        }
        // *
        public static T Multiply<T>(T a, T b) where T : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(T).IsPrimitive || typeof(T) == typeof(bool))
            {
                throw new ArgumentException("Type must be a numeric primitive.");
            }
            return (T)(dynamic)a * (dynamic)b;
        }
        // /
        public static double Divide<T>(T a, T b) where T : struct
        { 
            if ((dynamic)b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return (double)(dynamic)a / (double)(dynamic)b;
        }
        // %
        public static T Modulus<T>(T a, T b) where T : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(T).IsPrimitive || typeof(T) == typeof(bool))
            {
                throw new ArgumentException("Type must be a numeric primitive.");
            }
            return (T)(dynamic)a % (dynamic)b;
        }
        // **
        public static double Exponentiation<T>(T a, T b) where T : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(T).IsPrimitive || typeof(T) == typeof(bool))
            {
                throw new ArgumentException("Type must be a numeric primitive.");
            }
            return (double)Math.Pow((dynamic)a, (dynamic)b);
        }
    }
}
