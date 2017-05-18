using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using QuickReturns.StockTrading.ExchangeService.Contracts;
using System.ServiceModel.Channels;
using QuickReturns.StockTrading.ExchangeService.DataContracts;


namespace QuickReturns.StockTrading.ExchangeService
{
    public class svcClient
    {
        static void Main(string[] args)
        {
            //Use a channel factory
            EndpointAddress ea = new EndpointAddress("http://localhost:8080/QuickReturns/Exchange");
            BasicHttpBinding bh = new BasicHttpBinding();
            IChannelFactory<ITradeService> channelFactory = new ChannelFactory<ITradeService>(bh);
            ITradeService pxy = channelFactory.CreateChannel(ea);

            Quote msftQuote = new Quote();
            msftQuote.Ticker = "MSFT";
            msftQuote.Bid = 30.25M;
            msftQuote.Ask = 32.00M;
            msftQuote.Publisher = "mind-it corp";

            pxy.PublishQuote(msftQuote);

            Quote result = null;
            result = pxy.GetQuote("MSFT");
            Console.WriteLine("result {0}\n{1}\n{2}", result.Ticker, result.Ask, result.Bid);

            try
            {
                Quote qu = pxy.GetQuote("IBM");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
