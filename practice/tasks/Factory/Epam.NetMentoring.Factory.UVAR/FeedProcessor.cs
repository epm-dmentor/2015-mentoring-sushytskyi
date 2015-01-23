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

            //IT: why do not use var validationErrors ?
            //IT: in that case ToList might be reasonable to avoid double enumeration : Count & something can be in the method PrintValidationErrors
            List<string> validationErrors = Manager.Validate(item).ToList();
            if (validationErrors.Count > 0)
            {
                PrintValidationErrors(validationErrors);
                return;
            }
            Console.WriteLine("Validation finished");
            Console.WriteLine("Matching account");
            Console.WriteLine(Manager.Match(item));

            //IT: saving is really very significant part, if something can't be saved due to an error, as usual an exception must be thrown
            if (Manager.Save(item))
            {
                Console.WriteLine("Item Saved");
            }

        }
        protected virtual IFeedManager Manager
        {
            get { return new FeedManager(); }
        }

        //IT: you made it to be overridable, but for such things as publishing errors we use DI
        protected virtual void PrintValidationErrors(IEnumerable<string> errors)
        {
            Console.WriteLine("Validation Failed");
            //IT: use var errror. Use var more, it's just convinient :)
            foreach (string error in errors)
            {
                Console.WriteLine(error);
            }

        }
    }
}
