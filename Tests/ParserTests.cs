using Draws.RandomStocks.Services;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Draws.RandomStocks.Tests {
    public class ParserTests {
        private const string _avanzaUrl = "https://www.avanza.se/frontend/template.html/marketing/advanced-filter/advanced-filter-template?widgets.stockLists.filter.list[0]=SE.LargeCap.SE&widgets.stockLists.filter.list[1]=SE.Inofficiella&widgets.stockLists.filter.list[2]=SE.MidCap.SE&widgets.stockLists.filter.list[3]=SE.SmallCap.SE&widgets.stockLists.filter.list[4]=SE.Xterna+listan&widgets.stockLists.filter.list[5]=SE.FNSE&widgets.stockLists.filter.list[6]=SE.XNGM&widgets.stockLists.filter.list[7]=SE.NSME&widgets.stockLists.filter.list[8]=SE.XSAT&widgets.stockLists.active=true&parameters.startIndex=0&parameters.maxResults=10&parameters.selectedFields[0]=LATEST&parameters.selectedFields[1]=PRICE_PER_EARNINGS&parameters.selectedFields[2]=NBR_OF_OWNERS";
        
        [Fact]
        public async Task Parser_should_get_html_nodes() {
            // Arrange
            HtmlParserService sut = new HtmlParserService(_avanzaUrl);
            await sut.Initialise();

            // Act
            var result = sut.GetAllTickers();

            // Assert
            result.Should().NotBeEmpty();
        }
    }
}
