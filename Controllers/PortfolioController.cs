﻿using finance.api.Extensions;
using finance.api.Interfaces;
using finance.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace finance.api.Controllers
{
	[Route("api/portfolio")]
	[ApiController]
	public class PortfolioController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IStockRepository _stockRepo;
		private readonly IPortfolioRepository _portfolioRepo;
		public PortfolioController(UserManager<AppUser> userManager,
		IStockRepository stockRepo, IPortfolioRepository portfolioRepo)
		{
			_userManager = userManager;
			_stockRepo = stockRepo;
			_portfolioRepo = portfolioRepo;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetUserPortfolio()
		{
			var username = User.GetUsername();
			var appUser = await _userManager.FindByNameAsync(username);
			var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
			return Ok(userPortfolio);
		}
	}
}
