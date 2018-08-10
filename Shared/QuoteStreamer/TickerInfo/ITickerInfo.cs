using System;
namespace QuoteStreamer.TickerInfo
{
    public interface ITickerInfo
    {
        string Symbol { get; }
        double? CurrentPrice { get; set; }

        void SetIntraDayDetails();
    }
}
