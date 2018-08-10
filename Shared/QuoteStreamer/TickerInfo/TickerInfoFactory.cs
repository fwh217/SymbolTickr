using System;
using QuoteStreamer.Core;
namespace QuoteStreamer.TickerInfo
{
    public static class TickerInfoFactory
    {
        public static ITickerInfo GetTickerInfo(StoredSymbol symbol)
        {
            ITickerInfo ticker = null;
            if (symbol.Type.Equals(SymbolType.Stock))
            {
                ticker = new StockTickerInfo(symbol.Symbol.ToUpper());
            }
            else if (symbol.Type.Equals(SymbolType.Currency))
            {
                ticker = new CurrencyTickerInfo(symbol.Symbol.ToUpper());
            }
            else if (symbol.Type.Equals(SymbolType.Crypto))
            {
                ticker = new CryptoTickerInfo(symbol.Symbol.ToUpper());
            }
            return ticker;
        }
    }
}
