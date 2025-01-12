using finance.api.Data;
using finance.api.Interfaces;
using finance.api.Models;
using Microsoft.EntityFrameworkCore;

namespace finance.api.Repository
{
	public class PortfolioRepository : IPortfolioRepository
	{
        private readonly AppDBContext _context;
		public PortfolioRepository(AppDBContext context)
		{
			_context = context;
		}
		public async Task<List<Stock>> GetUserPortfolio(AppUser user)
		{
			return await _context.Portfolios.Where(u => u.AppUserId == user.Id)
			.Select(stock => new Stock
			{
				Id = stock.StockId,
				Symbol = stock.Stock.Symbol,
				CompanyName = stock.Stock.CompanyName,
				Purchase = stock.Stock.Purchase,
				LastDiv = stock.Stock.LastDiv,
				Industry = stock.Stock.Industry,
				MarketCap = stock.Stock.MarketCap
			}).ToListAsync();
		}

	}
}
