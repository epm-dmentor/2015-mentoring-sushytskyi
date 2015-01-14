using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class D1FeedManager : IFeedManager
    {
        private readonly D1TradeFeed _feed;
        public List<string> _errors = new List<string>();

        public D1FeedManager(D1TradeFeed feed)
        {
            this._feed = feed;
        }
        public bool TryValidate(out List<string> errors)
        {
            foreach (D1Record record in _feed.Records)
            {
                ZeroMarketCheck(record);
            }
            if (_errors.Count > 0)
            {
                errors = _errors;
                return false;
            }

            Console.WriteLine("D1 feed validated");
            errors = new List<string>();
            return true;
        }

        public void PrintErros()
        {
            foreach (var erro in _errors)
            {
                Console.WriteLine(erro);
            }
        }

        private void ZeroMarketCheck(D1Record record)
        {
            if (record.Market == "")
                _errors.Add(String.Format("Zero Market found for ref: {0}", record.SourceTradeRef));
        }

        public IEnumerable<string> MatchFeed()
        {
            List<string> res = new List<string>();
            foreach (var record in _feed.Records)
            {
                res.Add(record.SourceAccountId + " " + record.CounterpartyId + " " + record.PrincipalId);
            }

            return res;
        }

        public void Save()
        {
            Console.WriteLine("D1 Feed, Saved");
        }
    }
}
