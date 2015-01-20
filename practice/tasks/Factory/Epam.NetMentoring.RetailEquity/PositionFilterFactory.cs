using System;

namespace Epam.NetMentoring.RetailEquity
{
    public class PositionFilterFactory : IPositionFilterFactory
    {
        public IPositionFilter CreatePositionFilter(string bankName)
        {
            IPositionFilter filter = null;
            switch (bankName)
            {
                case "Barcap":
                    filter = new BarcapPositionFilter();
                    break;
                case "Connacord":
                    filter = new ConnacordPositionFilter();
                    break;
                case "BOFA":
                    filter = new BofaPositionFilter();
                    break;
                default:
                    throw new NoBankFoundException(String.Format("No bank found for Bank Name: {0}",bankName));
            }
            return filter;
        }
    }
}
