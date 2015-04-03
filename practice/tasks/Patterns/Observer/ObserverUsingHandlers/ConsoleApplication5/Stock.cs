using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class Stock
    {
        public Stock(string stockName, decimal stockPrice,string stockCode)
        {
            this.StockCode = stockCode;
            this.StockName = stockName;
            this.StockPrice = stockPrice;
        }

        public string StockCode { get; set; }
        public string StockName { get; set; }
        public decimal StockPrice { get; set; }
    }
}
