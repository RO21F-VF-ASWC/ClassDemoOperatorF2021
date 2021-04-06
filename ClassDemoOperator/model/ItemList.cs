using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDemoOperator.model
{
    public class ItemList: IEnumerable<Item>
    {
        private HashSet<Item> _items;

        public ItemList()
        {
            _items = new HashSet<Item>();
        }

        public List<Item> Items => _items.ToList();

        public bool Add(Item item)
        {
            return _items.Add(item);
        }

        public void AddRange(ItemList inList)
        {
            foreach (Item item in inList.Items)
            {
                _items.Add(item);
            }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Remove(Item item)
        {
            return _items.Remove(item);
        }

        public int Count => _items.Count;


        

        public override string ToString()
        {
            return $"{nameof(Items)}: [{String.Join(", ",Items)}]";
        }

        /*
         * Til at understøtte foreach + LINQ
         */
        public IEnumerator<Item> GetEnumerator()
        {
            foreach (Item item in _items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /*
         * Til at understøtte brackets
         */
        public Item this[string name]
        {
            get { return _items.ToList().Find(i => i.Name == name); }

            set
            {
                Item item = _items.ToList().Find(i => i.Name == name);
                if (item != null)
                {
                    item.Price = value.Price;
                }
                else
                {
                    _items.Add(value);
                }
            }
        }

        /*
         * overload af + operator
         */
        public static ItemList operator +(ItemList A, ItemList B)
        {
            ItemList retur = new ItemList();
            retur.AddRange(A);
            retur.AddRange(B);
            return retur;
        }

        public static ItemList operator +(ItemList A, Item item)
        {
            ItemList retur = new ItemList();
            retur.AddRange(A);
            retur.Add(item);
            return retur;
        }

        public static ItemList operator +(Item item, ItemList A)
        {
            return A + item;
        }

        /*
         * Support equality
         */
        protected bool Equals(ItemList other)
        {
            if (_items.Count != other.Count)
            {
                return false;
            }

            foreach (Item item in _items)
            {
                if (!other.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ItemList) obj);
        }

        public override int GetHashCode()
        {
            return (_items != null ? _items.GetHashCode() : 0);
        }


        public static bool operator ==(ItemList A, ItemList B)
        {
            return A.Equals(B);
        }
        public static bool operator !=(ItemList A, ItemList B)
        {
            return !(A == B);
        }
    }
}
