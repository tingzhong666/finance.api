using Microsoft.AspNetCore.Identity;

namespace finance.api.Models
{
	public class AppUser : IdentityUser
	{
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
	}
}
