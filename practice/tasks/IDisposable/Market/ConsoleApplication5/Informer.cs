using System;
using System.Collections.Generic;

namespace ConsoleApplication5
{
  public class Informer:IInformer
    {
      public List<Ask> OpenAsks { set; get; }
      public List<Bid> OpenBids { set; get; }
      public List<Ask> BuysConfirmedlist { set; get; }
      public List<Bid> SoldList { set; get; }

      public Informer(List<Ask> openAsks, List<Bid> openBids, List<Ask> buysConfirmedlist, List<Bid> soldList)
      {
          OpenAsks = openAsks;
          OpenBids = openBids;
          BuysConfirmedlist = buysConfirmedlist;
          SoldList = soldList;
      }

      public void PrintStat()
      {
          Console.WriteLine("Broker notification");
          OpenAsks.ForEach(s=>Console.WriteLine("Open Ask Position ->   Security Code: {0}     Price: {1}  Amount: {2}   Broker: {3}",s.SecCode,s.Price,s.Amount,s.Broker));
          OpenBids.ForEach(s => Console.WriteLine("Open Bid Position->    Security Code: {0}     Price: {1}  Amount: {2}     Broker: {3}", s.SecCode, s.Price, s.Amount, s.Broker));

          SoldList.ForEach(s => Console.WriteLine("Sold ->    Security Code: {0}     Price: {1}  Amount: {2}", s.SecCode, s.Price, s.Amount));
          BuysConfirmedlist.ForEach(s => Console.WriteLine("Bought ->    Security Code: {0}     Price: {1}  Amount: {2}", s.SecCode, s.Price, s.Amount));
          Console.WriteLine("End of broker notification");
          Console.WriteLine("");
          Console.WriteLine("");
      }

    }
}
