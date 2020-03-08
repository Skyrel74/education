using Coin.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web;

namespace Coin.API
{
    public class CMC
    {
        private static readonly string API_KEY = "388b0c65-c940-45ab-86c0-2eca3cdf5c19";

        public static CoinModel MakeAPICall()
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5000";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return JsonConvert.DeserializeObject<CoinModel>(client.DownloadString(URL.ToString()));

        }
    }
}