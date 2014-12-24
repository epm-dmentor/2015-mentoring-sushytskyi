using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
