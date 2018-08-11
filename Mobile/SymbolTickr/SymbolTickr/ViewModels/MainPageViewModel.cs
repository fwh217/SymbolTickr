using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading;
using QuoteStreamer.TickerInfo;
using QuoteStreamer.Core;
using System.ComponentModel;
namespace SymbolTickr.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ITickerInfo> symbolsList;

        public ObservableCollection<ITickerInfo> SymbolsList
        {
            get
            {
                if (symbolsList == null)
                {
                    symbolsList = new ObservableCollection<ITickerInfo>();
                }
                OnPropertyChanged("SymbolsList");
                return symbolsList;
            }
        }

        public MainPageViewModel()
        {
            List<StoredSymbol> storedSymbols = new List<StoredSymbol>();
            storedSymbols.Add(new StoredSymbol { Symbol = "MSFT", Type = SymbolType.Stock });
            storedSymbols.Add(new StoredSymbol { Symbol = "EUR", Type = SymbolType.Currency });
            storedSymbols.Add(new StoredSymbol { Symbol = "BTC", Type = SymbolType.Crypto });
            AddSymbolsToList(storedSymbols);
            Thread thread = new Thread(IntraDayUpdate);
            thread.Start();
        }

        private void IntraDayUpdate()
        {
            while (true)
            {
                Thread.Sleep(60000);
                foreach (ITickerInfo ticker in SymbolsList)
                {
                    ticker.SetIntraDayDetails();
                }
            }
        }

        public void AddSymbolsToList(List<StoredSymbol> storedSymbols)
        {
            foreach (StoredSymbol symbol in storedSymbols)
            {
                ITickerInfo TickerInfo = TickerInfoFactory.GetTickerInfo(symbol);
                SymbolsList.Add(TickerInfo);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
