using System;
namespace QuoteStreamer.SymbolDetails
{
    interface IIntraDayDetails
    {
        double CurrentPrice { get; set; }
    }
}
