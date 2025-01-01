using finance.api.Models;

namespace finance.api.Interfaces
{
	public interface ITokenService
	{
		string CreateToken(AppUser user);
	}
}
