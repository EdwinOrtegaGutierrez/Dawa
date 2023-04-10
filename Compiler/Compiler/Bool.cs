using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    internal class Bool
    {
        private bool value;

        public Bool(bool v) => value = v;

        public bool GetValue() => value;

        public override string ToString() => value.ToString();
    }
}
