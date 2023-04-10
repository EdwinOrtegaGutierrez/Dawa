using System.Linq;

namespace Compiler
{
    internal class Tuple
    {
        private dynamic[] elements;
        private int size;

        public Tuple(params dynamic[] args)
        {
            this.size = args.Length;
            this.elements = new dynamic[size];

            for (int i = 0; i < args.Length; i++)
            {
                this.elements[i] = args[i];
            }
        }

        public dynamic this[int index]
        {
            get => elements[index % size];
        }

        public int Count
        {
            get { return size; }
        }

        public IEnumerator<dynamic> GetEnumerator()
        {
            int index = 0;
            while (true)
            {
                yield return elements[index % size];
                index++;
            }
        }

        public override string ToString()
        {
            string t = "(" + string.Join(", ", elements) + ")";
            return t;
        }
    }
}
