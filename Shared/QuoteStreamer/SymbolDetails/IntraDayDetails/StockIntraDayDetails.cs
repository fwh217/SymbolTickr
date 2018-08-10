using System;
using System.Collections.Generic;
using System.Text;
namespace QuoteStreamer.SymbolDetails.IntraDayDetails
{
    public class StockIntraDayDetails : IIntraDayDetails
    {
        private double currentPrice;
        private int volume;

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

        public int Volume
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

