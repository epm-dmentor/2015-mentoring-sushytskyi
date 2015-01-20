using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class FeedProcessor : IFeedProcessor
    {
        public void Process(TradeFeedItem item)
        {
            Console.WriteLine("Validation started");
            List<string> validationErrors = Manager.Validate(item).ToList();
            if (validationErrors.Count > 0)
            {
                PrintValidationErrors(validationErrors);
                return;
            }
            Console.WriteLine("Validation finished");
            Console.WriteLine("Matching account");
            Console.WriteLine(Manager.Match(item));

            if (Manager.Save(item))
            {
                Console.WriteLine("Item Saved");
            }

        }
        protected virtual IFeedManager Manager
        {
            get { return new FeedManager(); }
        }

        protected virtual void PrintValidationErrors(IEnumerable<string> errors)
        {
            Console.WriteLine("Validation Failed");
            foreach (string error in errors)
            {
                Console.WriteLine(error);
            }

        }
    }
}
