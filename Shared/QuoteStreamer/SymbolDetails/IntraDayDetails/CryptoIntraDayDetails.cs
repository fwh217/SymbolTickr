using System;
namespace QuoteStreamer.SymbolDetails.IntraDayDetails
{
    public class CryptoIntraDayDetails
    {
        public class CryptoIntraDayDetails : IIntraDayDetails
        {
            private double currentPrice;
            private double volume;

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

            public double Volume
            {
                get
                {
                    return volume;
                }
                set
                {
                    volume = value;
                }
            }
        }
    }
}
