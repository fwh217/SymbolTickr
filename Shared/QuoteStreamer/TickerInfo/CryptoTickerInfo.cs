using System;
using QuoteStreamer.SymbolDetails;
using QuoteStreamer.Core;
namespace QuoteStreamer.TickerInfo
{
    public class CryptoTickerInfo : TickerInfoBase
    {

        private double? volume;

        public double? Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
                OnPropertyChanged("Volume");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol">Must be a valid crypto symbol. Verify this before constructing this object</param>
        public CryptoTickerInfo(string symbol) : base(symbol) { }

        public override void SetIntraDayDetails()
        {
            CryptoIntraDayDetails intraDayDetails = QueryManager.GetCryptoIntraDayDetails(Symbol);
            CurrentPrice = intraDayDetails?.CurrentPrice;
            Volume = intraDayDetails?.Volume;
        }
    }
}
