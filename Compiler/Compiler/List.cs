using System;
using System.Collections.Generic;

namespace Compiler
{
    
    public class List<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;

        public List()
        {
            this.items = new T[4];
            this.count = 0;
        }

        public void Add(T item)
        {
            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            items[count++] = item;
        }

        public void Clear()
        {
            items = new T[4];
            count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(this.items[i], item))
                {
                    return true;
                }
            }
            return false;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
            items[index] = item;
            count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    for (int j = i + 1; j < count; j++)
                    {
                        items[j - 1] = items[j];
                    }
                    count--;
                    items[count] = default(T);
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            for (int i = index + 1; i < count; i++)
            {
                items[i - 1] = items[i];
            }
            count--;
            items[count] = default(T);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        public int Count
        {
            get { return count; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                items[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            string listAsString = "[" + string.Join(", ", this) + "]";
            return listAsString;
        }
    }
}