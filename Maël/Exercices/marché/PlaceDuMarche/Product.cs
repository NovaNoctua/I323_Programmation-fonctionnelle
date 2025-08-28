using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceDuMarche
{
    internal class Product
    {
        private int _place;
        private string _sellerName;
        private string _productName;
        private int _quantity;
        private string _unit;
        private int _price;

        public int Place { get { return _place; } set { _place = value; } }
        public string SellerName { get { return _sellerName; } set { _sellerName = value; } }
        public string ProductName { get { return _productName; } set { _productName = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        public string Unit { get { return _unit; } set { _unit = value; } }
        public int Price { get { return _price; } set { _price = value; } }

        public Product(int place, string sellerName, string productName, int quantity, string unit, int price)
        {
            _place = place;
            _sellerName = sellerName;
            _productName = productName;
            _quantity = quantity;
            _unit = unit;
            _price = price;
        }
    }
}
