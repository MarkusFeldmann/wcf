using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Extensions;

namespace QuickReturns.StockTrading.ExchangeService.Hosts
{
    class Program
    {
        static void Main(string[] args)
        {
            //code based
            //Uri address = new Uri("http://localhost:8080/QuickReturns/Exchange");
            //ServiceHost host = new ServiceHost(typeof(TradeService), address);
            //host.Open();

            //Config based
            Type ServiceType = typeof(TradeService);
            ServiceHost host = new ServiceHost(ServiceType);
            host.Open();

            "Host open at 8080, press key to exit.\nMex Enpoint at: http://localhost:8080/QuickReturns/?wsdl".cwGreen();
            Console.ReadLine();
        }
    }
}
