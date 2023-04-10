using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class Str
    {
        private string value;

        public Str(string value)
        {
            this.value = value;
        }

        public int Length
        {
            get { return value.Length; }
        }

        public char this[int index]
        {
            get { return value[index]; }
            set { this.value = this.value.Substring(0, index) + this.value[index] + this.value.Substring(index + 1); }
        }

        public static Str operator +(Str s1, Str s2)
        {
            return new Str(s1.value + s2.value);
        }

        public static bool operator ==(Str s1, Str s2)
        {
            return s1.value == s2.value;
        }

        public static bool operator !=(Str s1, Str s2)
        {
            return s1.value != s2.value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Str s = (Str)obj;
            return this.value == s.value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public int Count(string sub)
        {
            int count = 0;
            int index = 0;
            while ((index = value.IndexOf(sub, index)) != -1)
            {
                count++;
                index += sub.Length;
            }
            return count;
        }

        public bool Contains(string sub)
        {
            return value.Contains(sub);
        }

        public Str Replace(string oldSub, string newSub)
        {
            return new Str(value.Replace(oldSub, newSub));
        }

        public Str Substring(int start)
        {
            return new Str(value.Substring(start));
        }

        public Str Substring(int start, int end)
        {
            return new Str(value.Substring(start, end - start));
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
