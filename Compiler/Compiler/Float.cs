using System;
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
}
