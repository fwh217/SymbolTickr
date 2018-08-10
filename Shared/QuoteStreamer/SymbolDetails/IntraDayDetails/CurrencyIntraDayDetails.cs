using System;
namespace QuoteStreamer.SymbolDetails.IntraDayDetails
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
