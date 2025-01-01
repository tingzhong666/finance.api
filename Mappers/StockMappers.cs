using finance.api.DTOs.Stock;
using finance.api.Models;
using System.Xml.Linq;

namespace finance.api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToDto(this Stock stock)
        {
            return new StockDto()
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Industry = stock.Industry,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                MarketCap = stock.MarketCap,
                Comments =  stock.Comments.Select(v => v.ToDto()).ToList()
            };
        }

        public static Stock ToModel(this CreateStockDto createStockDto)
        {
            return new Stock()
            {
                Symbol = createStockDto.Symbol,
                CompanyName = createStockDto.CompanyName,
                Industry = createStockDto.Industry,
                Purchase = createStockDto.Purchase,
                LastDiv = createStockDto.LastDiv,
                MarketCap = createStockDto.MarketCap
            };
        }

    }
}
