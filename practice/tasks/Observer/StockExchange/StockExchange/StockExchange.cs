using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.StockExchange
{
    public class StockExchange : IStockExchange
    {
        public event SoldEventHandler Sold;
        public event SellingRequestedHandler SellingRequested;

        public IList<SellRecord> SellList =new List<SellRecord>();
        public IList<BuyRecord> BuyList = new List<BuyRecord>();
        private Dictionary<IBroker, int> _brokersAccounts = new Dictionary<IBroker, int>();


        public void Buy(IBroker broker,string securityId, int ammount, int price)
        {
            bool matched = false;
            foreach (SellRecord sellRecord in SellList)
            {
                if (sellRecord.SecurityId == securityId && sellRecord.Amount == ammount && sellRecord.Price == price)
                {
                    if (GetBrokerCashPosition(broker) >= sellRecord.Amount * sellRecord.Price)
                    {
                        var matchId = Guid.NewGuid();
                        sellRecord.MatchedBuyId = matchId;
                        var newSellBuy = new BuyRecord(broker, securityId, ammount, price);
                        newSellBuy.MatchedSellId = matchId;

                        UpdateBrokerCashPositon(broker, sellRecord.Amount * sellRecord.Price, false);
                        UpdateBrokerCashPositon(sellRecord.Seller, sellRecord.Amount * sellRecord.Price, true);
                        matched = true;

                        if (Sold != null)
                            Sold(new DealInfo(sellRecord));

                    }
                    else
                    {
                        if (!matched)
                        {
                            var newSellBuy = new SellRecord(broker, securityId, ammount, price);
                            SellList.Add(newSellBuy);
                        }

                    }
                }
            }
        }

        public void Register(IBroker broker)
        {
            if (!_brokersAccounts.ContainsKey(broker))
            {
                _brokersAccounts.Add(broker, 100);
            }
        }

        private void UpdateBrokerCashPositon(IBroker broker, int amount, bool increaseValue)
        {
            if (!increaseValue)
                amount = amount * -1;

            if (_brokersAccounts.ContainsKey(broker))
            {
                _brokersAccounts[broker] += amount;
            }
        }

        private int GetBrokerCashPosition(IBroker broker)
        {
            int cash = 0;

            if (_brokersAccounts.ContainsKey(broker))
                cash += _brokersAccounts[broker];
            return cash;
        }

        public void RequestSell(IBroker broker,string securityId, int ammount, int price)
        {
            bool matched = false;
            foreach (BuyRecord buyRecord in BuyList)
            {
                if (buyRecord.SecurityId == securityId && buyRecord.Amount == ammount && buyRecord.Price == price)
                {
                    matched = true;
                    var matchId = Guid.NewGuid();
                    buyRecord.MatchedSellId = matchId;
                    var newSell = new SellRecord(broker, securityId, ammount, price);
                    newSell.MatchedBuyId = matchId;
                    SellList.Add(newSell);
 

                    UpdateBrokerCashPositon(broker, buyRecord.Amount * buyRecord.Price, true);
                    UpdateBrokerCashPositon(buyRecord.Buyer, buyRecord.Amount * buyRecord.Price, false);
                    if (Sold != null)
                        Sold(new DealInfo(newSell));

                }
            }
            if (!matched)
            {
                var newSell = new SellRecord(broker, securityId, ammount, price);
                SellList.Add(newSell);
            }

        }
    }
}
