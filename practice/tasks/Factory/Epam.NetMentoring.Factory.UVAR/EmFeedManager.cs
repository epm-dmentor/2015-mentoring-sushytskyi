using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class EmFeedManager : IFeedManager
    {
        private readonly EmTradeFeed _feed;
        private readonly List<string> _errors = new List<string>();

        public EmFeedManager(EmTradeFeed feed)
        {
            this._feed = feed;
        }
        public bool TryValidate(out List<string> errors)
        {
            foreach (EmRecord record in _feed.Records)
            {
                ZeroAccountCheck(record);
            }
            if (_errors.Count > 0)
            {
                errors = _errors;
                return false;
            }

            Console.WriteLine("EM feed validated");
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

        private void ZeroAccountCheck(EmRecord record)
        {
            if (record.SourceAccountId == 0)
                _errors.Add(String.Format("Zero account found for trade ref: {0}", record.SourceTradeRef));
        }

        public IEnumerable<string> MatchFeed()
        {
            List<string> res = new List<string>();
            foreach (var record in _feed.Records)
            {
                res.Add(record.SourceAccountId + "-EM_FEED");
            }

            return res;
        }


        public void Save()
        {
            Console.WriteLine("EM Feed, Saved");
        }
    }
}
