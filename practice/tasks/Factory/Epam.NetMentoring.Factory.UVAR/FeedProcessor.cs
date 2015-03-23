using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Factory.UVAR
{
    public class FeedProcessor : IFeedProcessor
    {
        public void Process(TradeFeedItem item)
        {
            Guid saveId;
            Console.WriteLine("Validation started");

            var validationErrors = Manager.Validate(item).ToList();
            if (validationErrors.Any())
            {
                PrintValidationErrors(validationErrors);
                return;
            }
            Console.WriteLine("Validation finished");
            Console.WriteLine("Matching account");
            Console.WriteLine(Manager.Match(item));

            try
            {
                saveId = Manager.Save(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Exception during item saving", ex);
            }

            Console.WriteLine("Item Saved: {0}", saveId);

        }
        protected virtual IFeedManager Manager
        {
            get { return new FeedManager(); }
        }

        //IT: you made it to be overridable, but for such things as publishing errors we use DI
        protected virtual void PrintValidationErrors(IEnumerable<ValidationError> errors)
        {
            Console.WriteLine("Validation Failed");
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorText);
            }

        }
    }
}
