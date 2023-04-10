using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class Dict<TKey>
    {
        private Dictionary<TKey, dynamic> dict;

        public Dict()
        {
            dict = new Dictionary<TKey, dynamic>();
        }

        public void Add(TKey key, dynamic value)
        {
            dict.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return dict.ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            return dict.Remove(key);
        }

        public int Count
        {
            get { return dict.Count; }
        }

        public dynamic this[TKey key]
        {
            get
            {
                return dict[key];
            }
            set
            {
                dict[key] = value;
            }
        }

        public override string ToString()
        {
            string d = "{" + string.Join(", ", dict) + "}";
            return d;
        }
    }
}
