using System;
namespace QuoteStreamer.SymbolDetails
{
    public class CurrencyIntraDayDetails : IIntraDayDetails
    {
        private double currentPrice;

        public double CurrentPrice
        {
            get
            {
                return currentPrice;
            }
            set
            {
                currentPrice = value;
            }
        }
    }
}
