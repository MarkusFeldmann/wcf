using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using QuickReturns.StockTrading.ExchangeService.Contracts;
using System.Collections;
using QuickReturns.StockTrading.ExchangeService.DataContracts;


namespace QuickReturns.StockTrading.ExchangeService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]       // Singleton Instance
    public class TradeService : ITradeService
    {
        private Hashtable tickers = new Hashtable();
        public QuickReturns.StockTrading.ExchangeService.DataContracts.Quote GetQuote(string ticker)
        {
            lock (tickers)
            {
                Quote quote = tickers[ticker] as Quote;
                if (quote == null)
                {
                    throw new Exception(String.Format("No quotes found for ticker {0}", ticker));
                }
                return quote;
            }
        }

        public void PublishQuote(QuickReturns.StockTrading.ExchangeService.DataContracts.Quote quote)
        {
            lock (tickers)
            {
                Quote storedQuote = tickers[quote.Ticker] as Quote;
                if (storedQuote == null)
                {
                    tickers.Add(quote.Ticker, quote);
                }
            }
        }
    }
}
