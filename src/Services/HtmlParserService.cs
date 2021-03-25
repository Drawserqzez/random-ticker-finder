using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Draws.RandomStocks.Models;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace Draws.RandomStocks.Services {
    public class HtmlParserService {
        private HtmlDocument _document;
        private string _url;

        public HtmlParserService(string url) {
            _url = url;
        }

        public async Task Initialise() {
            _document = await new HtmlWeb().LoadFromWebAsync(_url);
        }

        public IEnumerable<Ticker> GetAllTickers() {
            List<Ticker> _tickers = new List<Ticker>();
            var htmlNode = _document.DocumentNode;

            int tickerAmount = Convert.ToInt32(Math.Round((double)htmlNode.QuerySelectorAll("tr").Count() / 3));

            for(int i = 0; i < tickerAmount; i++) {
                var rows = htmlNode.QuerySelectorAll($"#{i}");

                foreach (var row in rows) {
                    _tickers.Add(new Ticker() { Name = row.InnerText });
                }
            }

            return _tickers;
        }
    }
}