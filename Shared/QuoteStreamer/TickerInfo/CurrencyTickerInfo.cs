using System;
namespace QuoteStreamer.TickerInfo
{
    public class CurrencyTickerInfo : TickerInfoBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol">Must be a valid currency symbol. Verify this before constructing the object</param>
        public CurrencyTickerInfo(string symbol) : base(symbol) { }

        public override void SetIntraDayDetails()
        {
            CurrencyIntraDayDetails intraDayDetails = QueryManager.GetCurrencyIntraDayDetails(Symbol);
            CurrentPrice = intraDayDetails?.CurrentPrice;
        }
    }
}
