using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDemoOperator.model
{
    public class Item
    {
        private string _name;
        private int _price;

        public Item()
        {
        }

        public Item(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Price)}: {Price}";
        }

        protected bool Equals(Item other)
        {
            return _name == other._name && _price == other._price;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Item)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_name != null ? _name.GetHashCode() : 0) * 397) ^ _price;
            }
        }
    }
}
