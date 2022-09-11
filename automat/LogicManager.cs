using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automat
{
    internal class LogicManager
    {
        Dispenser dispenser = Dispenser.Instance;

        int coinBuffer = 0;

        public void CoinInput(int coin)
        {
            coinBuffer += coin;
        }

        //public Product? Grapper(int x,int y)
        //{
        //    if(dispenser.Products[x, y] != null)
        //    return dispenser.Products[x,y].Pop();
        //    return null;
        //}



    }
}
