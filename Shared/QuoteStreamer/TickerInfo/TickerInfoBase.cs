using System;
using System.ComponentModel;
namespace QuoteStreamer.TickerInfo
{
    public abstract class TickerInfoBase : ITickerInfo, INotifyPropertyChanged
    {
        private readonly string symbol;
        private double? currentPrice;

        public string Symbol
        {
            get
            {
                return symbol;
            }
        }

        public double? CurrentPrice
        {
            get
            {
                return currentPrice;
            }
            set
            {
                currentPrice = value;
                OnPropertyChanged("CurrentPrice");
            }
        }

        public TickerInfoBase(string symbol)
        {
            this.symbol = symbol;
            SetIntraDayDetails();
        }

        public abstract void SetIntraDayDetails();

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
