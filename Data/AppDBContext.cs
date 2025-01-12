using finance.api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace finance.api.Data
{
	public class AppDBContext : IdentityDbContext<AppUser>
	{
		public AppDBContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Stock> Stocks { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Portfolio> Portfolios { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// === 用户与股票 关系表
			builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

			builder.Entity<Portfolio>()
				.HasOne(u => u.AppUser)
				.WithMany(u => u.Portfolios)
				.HasForeignKey(p => p.AppUserId);

			builder.Entity<Portfolio>()
				.HasOne(u => u.Stock)
				.WithMany(u => u.Portfolios)
				.HasForeignKey(p => p.StockId);
			// ===

			var roles = new List<IdentityRole>()
			{
				new IdentityRole()
				{
					Name="Admin",
					NormalizedName="ADMIN",
				},

				new IdentityRole()
				{
					Name="User",
					NormalizedName="USER",
				}
			};

			builder.Entity<IdentityRole>().HasData(roles);
		}
	}
}
