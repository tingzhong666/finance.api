using finance.api.Models;

namespace finance.api.Interfaces
{
	public interface IPortfolioRepository
	{
		Task<List<Stock>> GetUserPortfolio(AppUser user);
	}
}
