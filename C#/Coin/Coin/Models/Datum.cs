﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coin.Models
{
    public class Datum
    {
        public string name { get; set; }
        public string symbol { get; set; }
        public Quote quote { get; set; }
    }
}