using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coin.Models
{
    public class USD
    {
        public float price { get; set; }
        public float percent_change_1h { get; set; }
        public float percent_change_24h { get; set; }
        public string market_cap { get; set; }
        public string last_updated { get; set; }
    }
}