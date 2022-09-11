using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automat
{
    internal class Product
    {

        public Stack<ProductData> stack = new Stack<ProductData>();

        public Stack<ProductData> Stack
        {
            get { return stack; }
            set { stack = value; }
        }

        public Product()
        {
        }
    }

    internal class ProductData
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public ProductData(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
