using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.StockExchange
{
    public enum ResultCode
    {
         Ok, 
         SecurityNotFound,
         WrongPrice,
         NotEnoughSec,
         NotEnoughMoney
    
    }
}
