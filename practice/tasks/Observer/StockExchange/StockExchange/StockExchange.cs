using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.StockExchange
{
    //1. Разиваем методы на логические цепочки действий (монофункциональные)
    //2. Дать нормальные адекватные названия методав, сгенеренным выше

    //IT2: code + comments - OMG. simplify it, split to separate logical method. Give reasonable names to the methods
    // correct code for this class only after consultation with me
    public partial class StockExchange : IStockExchange
    {
        private const int DefaultCashAmount = 100;

        //IT: readonly?
        //IS:Corrected
        //IT2: it's better to use interfaces instead of concreat types if that's possibles
        private readonly IList<Share> _initialOffers = new List<Share>();
        private readonly IList<DealRequest> _sellRequests = new List<DealRequest>();
        private readonly IList<ExchangeInternalAccount> _internalAccounts = new List<ExchangeInternalAccount>();

        public event SoldEventHandler Sold;
        public event SellingRequestedEventHandler SellingRequested;


        //IT: make it readable and understandable.
        //IT: advise you can split it to few method if that's possible
        public ResultCode Buy(IBroker broker, string securityId, int ammount, decimal price)
        {
            ResultCode resultCode;
            var buyerAccount = Find(_internalAccounts, broker);
            var buyerShare = Find(buyerAccount.Shares, securityId);

            //check buyer balance
            if (GetBrokerBalance(_internalAccounts, broker) < ammount * price)
                return ResultCode.NotEnoughMoney;

            //process buy using initial offers list
            var SellingShare = Find(_initialOffers, securityId);
            resultCode = CheckConstrains(SellingShare, securityId, ammount, price);

            if (resultCode == ResultCode.Ok)
            {
                UpdateBuyerAccount(securityId, ammount, price, buyerAccount, buyerShare);

                _initialOffers[_initialOffers.IndexOf(SellingShare)].Update((ammount * -1), price);
                if (Sold != null)
                    Sold(new DealInfo(securityId, price, ammount));
                return resultCode;
            }

            //process buy using sell requests list
            var dealRequest = Find(_sellRequests, securityId);
            resultCode = CheckConstrains(dealRequest, securityId, ammount, price);
            if (resultCode != ResultCode.Ok)
                return resultCode;

            UpdateBuyerAccount(securityId, ammount, price, buyerAccount, buyerShare);

            //updated seller acount
            var sellerAccount = Find(_internalAccounts, dealRequest.Seller);
            sellerAccount.CashBalance += ammount;

            var sellerShare = Find(sellerAccount.Shares, securityId);
            sellerAccount.Shares[sellerAccount.Shares.IndexOf(sellerShare)].Update(ammount * -1, price);

            _sellRequests.Remove(dealRequest);
            //

            Sold(new DealInfo(securityId, price, ammount));
            return resultCode;
        }

        public Guid RequestSell(IBroker broker, string securityId, int ammount, decimal price)
        {
            //check if broker has active account.
            var brokerAccount = Find(_internalAccounts, broker);
            if (brokerAccount != null)
            {
                //check if broker has share to sell 
                var share = brokerAccount.Shares.FirstOrDefault(s => s.SecurityId == securityId);
                if (share != null && share.Ammount >= ammount)
                {
                    //generate request add it list
                    var request = new DealRequest(broker, securityId, ammount, price, DealType.Sell);
                    _sellRequests.Add(request);
                    if (SellingRequested != null)
                        SellingRequested(new DealInfo(securityId, price, ammount));
                    return request.Id;
                }
            }
            return Guid.Empty;
        }

        public bool CancelRequest(Guid requestId)
        {
            var request = _sellRequests.FirstOrDefault(s => s.Id == requestId);

            if (request != null)
            {
                _sellRequests.Remove(request);
                return true;
            }
            return false;
        }

        //IS: we might need to delete IStockExchange as return type as we set link between broker and account in broker method call 
        public IStockExchange Register(IBroker broker)
        {
            _internalAccounts.Add(new ExchangeInternalAccount(new List<Share>(), DefaultCashAmount, broker));
            broker.SettleStockExchange(this);
            return this;
        }

        public void Bid(Share share)
        {
            if (_initialOffers.Contains(share))
                //we need to ovverride share equlity
                throw new Exception("Share already listed");
            _initialOffers.Add(share);
        }

        public IEnumerable<Share> GetAvailableShares()
        {
            //IT: IReadOnlyList<Share>
            //IS:corrected
            return new List<Share>(_initialOffers).AsReadOnly();
        }

        public BrokerAccount GetAccount(IBroker broker)
        {
            var account = Find(_internalAccounts, broker);
            //IT: possible access breach - readonly list!
            //IS:BrokerAccount class corrected

            //IT3: null reference exception
            return account == null ? null : new BrokerAccount(account.Shares, account.CashBalance);
        }


        //1. find share
        //2. check constraints
        private Share Find(IEnumerable<Share> shares, string securityId)
        {
            if (shares == null)
                return null;

            var resultShare = shares.FirstOrDefault(s => String.Equals(s.SecurityId, securityId));

            return resultShare;
        }

        private ResultCode CheckConstrains(Share share, string securityId, int amount, decimal price)
        {
            if (String.Equals(share.SecurityId, securityId))
            {
                if (share.Ammount >= amount)
                {
                    if (share.Price == price)
                    {
                        //IT: isn't that better to break the loop here ?
                        return ResultCode.Ok;

                    }
                    return ResultCode.WrongPrice;
                }
                else
                {
                    return ResultCode.NotEnoughSec;
                }
            }
            else
            {
                return ResultCode.SecurityNotFound;
            }

        }

        private DealRequest Find(IList<DealRequest> deals, string securityId)
        {
            if (deals == null)
                return null;

            var deal = deals.FirstOrDefault(s => String.Equals(s.SecurityId, securityId));

            return deal;
        }


        private ResultCode CheckConstrains(DealRequest deal, string securityId, int amount, decimal price)
        {
            if (String.Equals(deal.SecurityId, securityId))
            {
                if (deal.Amount == amount)
                {
                    if (deal.Price == price)
                    {
                        return ResultCode.Ok;
                    }
                    return ResultCode.WrongPrice;
                }
                else
                {
                    return ResultCode.NotEnoughSec;
                }
            }
            else
            {
                return ResultCode.SecurityNotFound;
            }
        }

        private decimal GetBrokerBalance(IList<ExchangeInternalAccount> acccounts, IBroker broker)
        {
            //brokers cash balance less than selling position
            if (broker == null)
                return 0;
            var brokerAccount = acccounts.FirstOrDefault(s => s.Broker == broker);
            if (brokerAccount != null)
                return brokerAccount.CashBalance;
            return 0;
        }
        private ExchangeInternalAccount Find(IList<ExchangeInternalAccount> acccounts, IBroker broker)
        {
            if (broker == null)
                return null;
            var brokerAccount = acccounts.FirstOrDefault(s => s.Broker == broker);
            return brokerAccount;
        }

        private void UpdateBuyerAccount(string securityId, int ammount, decimal price, ExchangeInternalAccount buyerAccount, Share buyerShare)
        {
            if (buyerShare != null)
            {
                buyerAccount.Shares[buyerAccount.Shares.IndexOf(buyerShare)].Update(ammount, price);
                buyerAccount.CashBalance -= ammount * price;
            }
            else
            {
                buyerAccount.Shares.Add(new Share(securityId, ammount, price));
                buyerAccount.CashBalance -= ammount * price;
            }
        }
    }
}
