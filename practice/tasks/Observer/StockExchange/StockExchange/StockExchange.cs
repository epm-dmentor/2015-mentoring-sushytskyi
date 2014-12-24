using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.StockExchange
{
    public class StockExchange : IStockExchange
    {
        //IT: readonly?
        //IS:Corrected
        private readonly List<Share> _initialOffers = new List<Share>();
        private readonly List<DealRequest> _sellRequests = new List<DealRequest>();
        private readonly List<ExchangeInternalAccounts> _internalAccounts = new List<ExchangeInternalAccounts>();

        public event SoldEventHandler Sold;
        public event SellingRequestedEventHandler SellingRequested;

        //process buy trade matching input with listed sell requests
        private bool ProcessBuyAsSellBuyMatch(IBroker broker, string securityId, int ammount, decimal price,
            out ResultCode resultCode, out IBroker seller)
        {

            //search for sell request matching criteria
            var sellRequest = GetMatchedSellRequestFromInputList(_sellRequests, securityId, ammount, price, out resultCode);

            //nothing found
            if (sellRequest == null)
            {
                seller = null;
                return false;
            }

            //brokers cash balance less than selling position
            if (_internalAccounts.Find(s => s.Broker == broker).CashBalance < ammount * price)
            {
                resultCode = ResultCode.NotEnoughMoney;
                seller = null;
                return false;
            }

            //get share from broker account if exists to update
            Share share =
                _internalAccounts.Find(s => s.Broker == broker)
                    .Shares.FirstOrDefault(s => s.SecurityId == securityId);

            //is share exists create new share with icreased position and assgin it to broker account
            if (share != null)
            {
                var newShare = GetNewShare(share, securityId, ammount, price, true);
                _internalAccounts.Find(s => s.Broker == broker).Shares.Remove(share);
                _internalAccounts.Find(s => s.Broker == broker).Shares.Add(newShare);
            }
            //if not exists create e share and assign it pn account
            else
            {
                var newShare = GetNewShare(null, securityId, ammount, price, true);
                if (newShare != null)
                    _internalAccounts.Find(s => s.Broker == broker).Shares.Add(newShare);
            }
            //finally updated broker balance deacreasing cash position
            _internalAccounts.Find(s => s.Broker == broker).CashBalance -= ammount * price;

            // Updated seller cash balance and share position            
            seller = sellRequest.Seller;

            //get seller share  
            Share sellerShare = _internalAccounts.Find(s => s.Broker == sellRequest.Seller)
                    .Shares.FirstOrDefault(s => s.SecurityId == sellRequest.SecurityId);
            //Remove share from seller account
            _internalAccounts.Find(s => s.Broker == sellRequest.Seller)
                .Shares.Remove(sellerShare);

            //create new share with deacreased position if share postion 0, null returned
            var newSellerShare = GetNewShare(sellerShare, securityId, ammount, price, false);

            //if share postion greater than 0 assign new share
            if (newSellerShare != null)
                _internalAccounts.Find(s => s.Broker == sellRequest.Seller)
                      .Shares.Add(newSellerShare);

            //increase seller cash balance
            _internalAccounts.Find(s => s.Broker == sellRequest.Seller)
                .CashBalance += ammount * price;

            //remove sell request
            _sellRequests.Remove(sellRequest);

            resultCode = ResultCode.Ok;
            return true;
        }
        //proccess by trade matching input with Initial Offer list
        private bool ProcessBuyAsInitialOfferBuy(IBroker broker, string securityId, int ammount, decimal price, out ResultCode resultCode)
        {
            //search for share matching critria in initioal offer list
            var initialOfferShare = GetMatchedShareFromInputList(_initialOffers, securityId, ammount, price, out resultCode);

            //share not found
            if (initialOfferShare == null)
            {
                return false;
            }
            //buyer cash balance less then requested deal
            if (_internalAccounts.Find(s => s.Broker == broker).CashBalance <
                ammount * price)
            {
                resultCode = ResultCode.NotEnoughMoney;
                return false;
            }

            //get broker share
            Share share =
                _internalAccounts.Find(s => s.Broker == broker)
                    .Shares.FirstOrDefault(s => s.SecurityId == securityId);

            //if exists increase current position
            if (share != null)
            {
                var newShare = GetNewShare(share, securityId, ammount, price, true);
                _internalAccounts.Find(s => s.Broker == broker).Shares.Remove(share);
                if (newShare != null)
                    _internalAccounts.Find(s => s.Broker == broker).Shares.Add(newShare);
            }
            //if not exists create new and assign to account 
            else
            {
                var newShare = GetNewShare(null, securityId, ammount, price, true);
                if (newShare != null)
                    _internalAccounts.Find(s => s.Broker == broker).Shares.Add(newShare);

            }

            //Update initial offer postion 
            //Get new share with decreased postion from initial offer list
            var newInitialOfferShare = GetNewShare(initialOfferShare, securityId, ammount, initialOfferShare.Price, false);

            //remove old share
            _initialOffers.Remove(initialOfferShare);
            //assign new one
            if (newInitialOfferShare != null)
                _initialOffers.Add(newInitialOfferShare);

            //deacrease buyer cash balance
            _internalAccounts.Find(s => s.Broker == broker).CashBalance -= ammount * price;

            resultCode = ResultCode.Ok;
            return true;
        }


        //IT: make it readable and understandable.
        //IT: advise you can split it to few method if that's possible
        public ResultCode Buy(IBroker broker, string securityId, int ammount, decimal price)
        {
            ResultCode resultCode;

            //try to process by using initial offer first if false return result code
            if (ProcessBuyAsInitialOfferBuy(broker, securityId, ammount, price, out resultCode))
            {
                if (Sold != null)
                    Sold(new DealInfo(securityId, price, ammount, broker));
                return resultCode;
            }
            //try to process trade based on plased sell requets
            IBroker seller;
            if (ProcessBuyAsSellBuyMatch(broker, securityId, ammount, price, out resultCode, out seller))
            {
                if (Sold != null)
                    Sold(new DealInfo(securityId, price, ammount, broker, seller));
                return resultCode;

            }
            return resultCode;
        }

        public Guid RequestSell(IBroker broker, string securityId, int ammount, decimal price)
        {
            //check if broker has active account.
            var brokerAccount = _internalAccounts.Find(s => s.Broker == broker);
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
                        SellingRequested(new DealInfo(broker, securityId, price, ammount));
                    return request.Id;
                }
            }
            return Guid.Empty;
        }

        public bool CancelRequest(Guid requestId)
        {
            var request = _sellRequests.FirstOrDefault(s => s.Id == requestId);

            //check if requst is still there
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
            _internalAccounts.Add(new ExchangeInternalAccounts(new List<Share>(), 100, broker));
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
            var account = _internalAccounts.Find(s => s.Broker == broker);
            //IT: possible access breach - readonly list!
            //IS:BrokerAccount class corrected
            return new BrokerAccount(account.Shares, account.CashBalance);
        }


        //IT: what does method mean?
        /// <summary>
        /// get share from input list of shares which match SecurityId,Price and existing ammount greater than requested. if nothing found 
        /// share evaluated to null you need to check resultCode with actual error code.  
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="securityId"></param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        private Share GetMatchedShareFromInputList(IEnumerable<Share> inputList, string securityId, int amount, decimal price,
            out ResultCode resultCode)
        {
            resultCode = ResultCode.SecurityNotFound;

            //IT: can have the same sec in inputList?
            foreach (Share share in inputList)
            {
                if (share.SecurityId == securityId)
                {
                    if (share.Ammount >= amount)
                    {
                        if (share.Price == price)
                        {
                            //IT: isn't that better to break the loop here ?
                            resultCode = ResultCode.Ok;
                            return share;
                        }
                        resultCode = ResultCode.WrongPrice;
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
            return null;
        }

        //IT: can it be generalized. It's pretty the same with the prev. method

        /// <summary>
        /// get Deal request from input list of Deal requests which match SecurityId,Price and ammount. if nothing found 
        /// share evaluated to null and you need to check resultCode with actual error code.  
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="securityId"></param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        /// <param name="resultCode"></param>
        /// <returns></returns>

        private DealRequest GetMatchedSellRequestFromInputList(IEnumerable<DealRequest> inputList, string securityId, int amount, decimal price,
     out ResultCode resultCode)
        {
            resultCode = ResultCode.SecurityNotFound;

            foreach (DealRequest sellRequest in inputList)
            {
                if (sellRequest.SecurityId == securityId)
                {
                    if (sellRequest.Amount == amount)
                    {
                        if (sellRequest.Price == price)
                        {
                            resultCode = ResultCode.Ok;
                            return sellRequest;
                        }
                        resultCode = ResultCode.WrongPrice;
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
            return null;
        }

        //IT: the method is not used at all
        /// <summary>
        /// Returns new share instance based on old share if provided
        /// </summary>
        /// <param name="oldShare">if null new share will be created with ammount as position</param>
        /// <param name="securityId"></param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        /// <param name="increase"> true if postion needs to be increased false otherwise</param>
        /// <returns></returns>
        private Share GetNewShare(Share oldShare, string securityId, int amount, decimal price, bool increase)
        {
            Share newShare = null;

            if (oldShare != null && increase)
            {
                newShare = new Share(securityId, amount + oldShare.Ammount, price);
            }
            if (oldShare != null && !increase)
            {
                if ((oldShare.Ammount - amount) < 0)
                    throw new Exception("new share ammount less than 0");

                if ((oldShare.Ammount - amount) == 0)
                    return null;

                newShare = new Share(securityId, oldShare.Ammount - amount, price);
            }
            if (oldShare == null && increase)
            {
                newShare = new Share(securityId, amount, price);
            }
            if (oldShare == null && !increase)
            {
                throw new Exception("Cannot decrease new share account as old share does not exists");
            }
            return newShare;
        }
    }
}
