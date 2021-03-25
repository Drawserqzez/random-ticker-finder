using System;

namespace Draws.RandomStocks.Models {
    public class Ticker {
        public Uri BuyUrl { get; set; }
        public decimal LatestPrice { get; set; }
        public string Name { get; set; }
        public int OwnerAmount { get; set; }
        public decimal PENumber { get; set; }
    }
}