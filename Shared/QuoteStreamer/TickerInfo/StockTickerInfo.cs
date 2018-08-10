using System;
namespace QuoteStreamer.TickerInfo
{
    public class StockTickerInfo : TickerInfoBase
    {
        private int? volume;

        public int? Volume
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
        /// <param name="symbol">Must be a valid stock symbol. Verify this before constructing this object</param>
        public StockTickerInfo(string symbol) : base(symbol) { }

        public override void SetIntraDayDetails()
        {
            StockIntraDayDetails intraDayDetails = QueryManager.GetStockIntraDayDetails(Symbol);
            CurrentPrice = intraDayDetails?.CurrentPrice;
            Volume = intraDayDetails?.Volume;
        }
    }
}
