using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.StockExchange
{
    public class StockExchange : IStockExchange
    {

        private List<Share> _initialOffers = new List<Share>();
        private List<SellRequest> _sellRequests = new List<SellRequest>();
        private List<ExchangeInternalAccounts> _internalAccounts = new List<ExchangeInternalAccounts>();

        public event SoldEventHandler Sold;
        public event SellingRequestedEventHandler SellingRequested;

        public ResultCode Buy(IBroker broker, string securityId, int ammount, decimal price)
        {
            var sellFound = false;
            ResultCode resultCode;

            var initialOfferShare = InitialOfferSearch(_initialOffers, securityId, ammount, price, out resultCode);

            if (initialOfferShare != null)
            {
                if (_internalAccounts.Find(s => s.Broker == broker).CashBalance <
                    initialOfferShare.Ammount * initialOfferShare.Price)
                {
                    resultCode = ResultCode.NotEnoughMoney;
                }
                else
                {

                    Share share =
                        _internalAccounts.Find(s => s.Broker == broker)
                            .Shares.FirstOrDefault(s => s.SecurityId == securityId);

                    if (share != null)
                    {
                        var newShare = new Share(share.SecurityId, share.Ammount + ammount, price);
                        ((List<Share>)_internalAccounts.Find(s => s.Broker == broker).Shares).Remove(share);
                        ((List<Share>)_internalAccounts.Find(s => s.Broker == broker).Shares).Add(newShare);
                        _initialOffers[_initialOffers.FindIndex(s => s == initialOfferShare)] = new Share(securityId, initialOfferShare.Ammount - ammount, initialOfferShare.Price);
                        sellFound = true;
                    }
                    else
                    {
                        var newShare = new Share(securityId, ammount, price);
                        ((List<Share>)_internalAccounts.Find(s => s.Broker == broker).Shares).Add(newShare);
                        _initialOffers[_initialOffers.FindIndex(s => s == initialOfferShare)] = new Share(securityId, initialOfferShare.Ammount - ammount, initialOfferShare.Price);
                        sellFound = true;

                    }
                    _internalAccounts.Find(s => s.Broker == broker).CashBalance -= ammount*price;
                }
            }

            if (!sellFound)
            {
                var sellRequest = SellRequestsSearch(_sellRequests, securityId, ammount, price, out resultCode);

                if (sellRequest == null)
                {
                    return resultCode;
                }

                if (_internalAccounts.Find(s => s.Broker == broker).CashBalance <
                    sellRequest.Amount * sellRequest.Price)
                {
                    resultCode = ResultCode.NotEnoughMoney;
                    return resultCode;
                }

                Share share =
                    _internalAccounts.Find(s => s.Broker == broker)
                        .Shares.FirstOrDefault(s => s.SecurityId == securityId);

                if (share != null)
                {
                    var newShare = new Share(share.SecurityId, share.Ammount + ammount, price);
                    ((List<Share>)_internalAccounts.Find(s => s.Broker == broker).Shares).Remove(share);
                    ((List<Share>)_internalAccounts.Find(s => s.Broker == broker).Shares).Add(newShare);
                    

                }
                else
                {
                    var newShare = new Share(securityId, ammount, price);
                    ((List<Share>)_internalAccounts.Find(s => s.Broker == broker).Shares).Add(newShare);
                }
                _internalAccounts.Find(s => s.Broker == broker).CashBalance -= ammount *price;
                var sellerAccount = _internalAccounts.Find(s => s.Broker == sellRequest.Seller);
            //   sellerAccount.CashBalance+=ammount *price;
            //    GetNewShare()
                //sellerAccount.Shares.FirstOrDefault(s=>s.SecurityId==securityId).Ammount+=ammount *price;
                
                resultCode = ResultCode.Ok;

            }
            return resultCode;
        }

        public Guid RequestSell(IBroker broker, string securityId, int ammount, decimal price)
        {
            //check if broker has shares to sell
            var brokerAccount = _internalAccounts.Find(s => s.Broker == broker);
            if (brokerAccount!= null)
            {
                var share = brokerAccount.Shares.FirstOrDefault(s => s.SecurityId == securityId);
                if (share != null && share.Ammount >= ammount)
                {
                    var request = new SellRequest(broker, securityId, ammount, price);
                    _sellRequests.Add(request);
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

        public IStockExchange Register(IBroker broker)
        {
            _internalAccounts.Add(new ExchangeInternalAccounts(new List<Share>(), 100, broker));
            broker.SettleStockExchange(this);
            return this;
        }

        public void Bid(Share share)
        {
            if (_initialOffers.Contains(share))
                throw new Exception();
            _initialOffers.Add(share);
        }

        public IEnumerable<Share> GetAvailableShares()
        {
            return new List<Share>(_initialOffers);
        }

        public BrokerAccount GetAccount(IBroker broker)
        {
            var account = _internalAccounts.Find(s => s.Broker == broker);
            return new BrokerAccount(account.Shares, account.CashBalance, account.Broker);
        }

        private Share InitialOfferSearch(IEnumerable<Share> inputList, string securityId, int amount, decimal price,
            out ResultCode resultCode)
        {
            resultCode = ResultCode.SecurityNotFound;
            Share result = null;
            foreach (Share share in inputList)
            {
                if (share.SecurityId == securityId)
                {
                    if (share.Ammount >= amount)
                    {
                        if (share.Price <= price)
                        {
                            result = share;
                        }
                        else
                        {
                            resultCode = ResultCode.WrongPrice;
                        }
                    }
                    else
                    {
                        resultCode = ResultCode.NotEnoughSec;
                    }
                }
                else
                {
                    resultCode = ResultCode.SecurityNotFound;
                }

            }
            return result;
        }

        private SellRequest SellRequestsSearch(IEnumerable<SellRequest> inputList, string securityId, int amount, decimal price,
     out ResultCode resultCode)
        {
            resultCode = ResultCode.SecurityNotFound;
            SellRequest result = null;
            foreach (SellRequest sellRequest in inputList)
            {
                if (sellRequest.SecurityId == securityId)
                {
                    if (sellRequest.Amount >= amount)
                    {
                        if (sellRequest.Price <= price)
                        {
                            result = sellRequest;
                        }
                        else
                        {
                            resultCode = ResultCode.WrongPrice;
                        }
                    }
                    else
                    {
                        resultCode = ResultCode.NotEnoughSec;
                    }
                }
                else
                {
                    resultCode = ResultCode.SecurityNotFound;
                }

            }
            return result;
        }

        private Share GetNewShare(List<ExchangeInternalAccounts> internalAccounts,IBroker broker, string securityId, int amount,decimal price, bool increaseCount)
        {
            Share oldShare=null;
            Share newShare = null;

            foreach (ExchangeInternalAccounts account in internalAccounts)
            {
                if (account.Broker == broker)
                {
                    foreach (var share in account.Shares)
                    {
                        if (share.SecurityId == securityId)
                        {
                            oldShare = share;
                        }
                    }
                }
            }
            if (oldShare != null&&increaseCount)
            {
                newShare=new Share(securityId,amount+oldShare.Ammount,price);

            }
            if (oldShare != null && !increaseCount)
            {
                newShare = new Share(securityId, oldShare.Ammount-amount, price);
            }
            if (oldShare == null && increaseCount)
            {
                newShare = new Share(securityId, amount, price);                
            }
            if (oldShare == null && !increaseCount)
            {
               throw new Exception("No shares on broker's ccount mathing condition which count can be decreased");
            }
            return newShare;
        }
      
    }
}
