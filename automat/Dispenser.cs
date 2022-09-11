using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automat
{
    internal class Dispenser
    {
        Program program = new Program();
        Product[,] products = new Product[2, 5];

        private int coinBuffer;

        public int CoinBuffer
        {
            get { return coinBuffer; }
            set { coinBuffer = value; }
        }

        private int coinBin;

        public int CoinBin
        {
            get { return coinBin; }
            set { coinBin = value; }
        }

        public Product[,]? Products { get => products; }
        private static Dispenser? instance = null;
        public static Dispenser Instance 
        { 
            get 
            { 
                if( instance == null)
                {
                    instance = new Dispenser();
                }
                return instance; 
            } 
        }

        public void AdminRefill(int[] pos)
        {
            for (int i = products[pos[0], pos[1]].stack.Count; i < 10; i++)
            {
                if (refills[pos[0], pos[1]] != null)
                products[pos[0], pos[1]].stack.Push(refills[pos[0], pos[1]]);
            }
        }

        public void ChangeProduct(int[] pos)
        {
            Console.Clear();
            program.PrintString("whats the name of the product");
            string name = program.GetAnswer();
            program.PrintString("what is the price of the product");
            int price = int.Parse(program.GetAnswer());
            refills[pos[0], pos[1]] = new ProductData(name, price);
            AdminRefill(pos);
        }

        public void BuySomething(int[] pos)
        {
            if(coinBuffer >= products[pos[0], pos[1]].Stack.Peek().Price)
            {
                Console.Clear();
                coinBin =+ products[pos[0], pos[1]].Stack.Peek().Price;
                program.PrintString("you get "+(coinBuffer-products[pos[0], pos[1]].Stack.Peek().Price).ToString()+" coins back");
                program.PrintString(products[pos[0], pos[1]].Stack.Pop().Name + " rolls out");
            }
            Thread.Sleep(1000);
        }

        private Dispenser() { QuickStock(); }
        private void QuickStock()
        {
            for (int i = 0; i < products.GetLength(0); i++)
            {
                for (int j = 0; j < products.GetLength(1); j++)
                {
                    this.products[i, j] = new Product();
                }
            }
        }
        ProductData[,] refills = new ProductData[2, 5];
    }
}
