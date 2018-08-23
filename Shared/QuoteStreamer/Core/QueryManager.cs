using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuoteStreamer.SymbolDetails;
namespace QuoteStreamer.Core
{
    public static class QueryManager
    {
        private const string apiKey = "DQ547O5NWG9WUI2A";

        private static JObject getJObject(string jsonQueryUrl)
        {
            JObject jObjcet = null;
            if(!String.IsNullOrEmpty(jsonQueryUrl))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string jsonStr = client.DownloadString(jsonQueryUrl);
                        jObjcet = JObject.Parse(jsonStr);
                    }
                    catch (WebException) { }
                    catch (JsonReaderException) { }
                }
            }
            return jObjcet;
        }

        public static StockIntraDayDetails GetStockIntraDayDetails(string symbol)
        {
            StockIntraDayDetails stockIntraDayDetails = null;
            String jsonQueryUrl = string.Format("https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={0}&interval=1min&apikey={1}", symbol, apiKey);
            JObject jObject = getJObject(jsonQueryUrl);
            if (jObject != null)
            {
                JToken currentJToken = jObject.GetValue("Time Series (1min)").First.First;
                stockIntraDayDetails = new StockIntraDayDetails()
                {
                    CurrentPrice = currentJToken.Value<double>("4. close"),
                    Volume = currentJToken.Value<int>("5. volume")
                };
            }
            return stockIntraDayDetails;
        }

        public static CurrencyIntraDayDetails GetCurrencyIntraDayDetails(string symbol)
        {
            CurrencyIntraDayDetails currencyIntraDayDerails = null;
            String jsonQueryUrl = string.Format("https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency={0}&to_currency=USD&apikey={1}", symbol, apiKey);
            JObject jObject = getJObject(jsonQueryUrl);
            if (jObject != null)
            {
                JToken currentJToken = jObject.GetValue("Realtime Currency Exchange Rate");
                currencyIntraDayDerails = new CurrencyIntraDayDetails()
                {
                    CurrentPrice = currentJToken.Value<double>("5. Exchange Rate")
                };
            }
            return currencyIntraDayDerails;
        }

        public static CryptoIntraDayDetails GetCryptoIntraDayDetails(string symbol)
        {
            CryptoIntraDayDetails cryptoIntraDayDetails = null;
            String jsonQueryUrl = string.Format("https://www.alphavantage.co/query?function=DIGITAL_CURRENCY_INTRADAY&symbol={0}&market=USD&apikey={1}", symbol, apiKey);
            JObject jObject = getJObject(jsonQueryUrl);
            if (jObject != null)
            {
                JToken currentJToken = jObject.GetValue("Time Series (Digital Currency Intraday)").First.First;
                cryptoIntraDayDetails = new CryptoIntraDayDetails()
                {
                    CurrentPrice = currentJToken.Value<double>("1b. price (USD)"),
                    Volume = currentJToken.Value<double>("2. volume")
                };
            }
            return cryptoIntraDayDetails;
        }
    }
}

