using System;
using Xamarin.Forms;
using QuoteStreamer.TickerInfo;

namespace SymbolTickr.Core
{
	public class SymbolDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StockTemplate { get; set; }
        public DataTemplate CurrencyTemplate { get; set; }
        public DataTemplate CryptoTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            DataTemplate template = null;
            if (item is StockTickerInfo)
            {
                template = StockTemplate;
            }
            else if (item is CurrencyTickerInfo)
            {
                template = CurrencyTemplate;
            }
            else if (item is CryptoTickerInfo)
            {
                template = CryptoTemplate;
            }
            return template;
        }
    }
}
