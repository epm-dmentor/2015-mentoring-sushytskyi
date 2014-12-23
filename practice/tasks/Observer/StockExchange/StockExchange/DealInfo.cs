namespace Epam.NetMentoring.StockExchange
{
    //IT: the same effect as you turn on camare and make a record in the mirror (a mirror in the mirror in the mirror...)
    //IT: It's bad idea to make class that just saves another object (at least at this case)
  public class DealInfo
    {
        public SellRequest Deal;

        public DealInfo(SellRequest deal)
        {
            // TODO: Complete member initialization
            Deal = deal;
        }
    }
}
