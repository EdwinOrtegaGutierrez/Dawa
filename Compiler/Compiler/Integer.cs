namespace Compiler
{
    internal class Integer
    {
        private int value;

        public Integer(int v) => value = v;

        public int GetValue() => value;

        public override string ToString() => value.ToString();
    }
}
