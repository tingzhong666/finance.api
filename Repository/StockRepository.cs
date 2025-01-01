using finance.api.Data;
using finance.api.DTOs.Stock;
using finance.api.Interfaces;
using finance.api.Mappers;
using finance.api.Models;
using Microsoft.EntityFrameworkCore;

namespace finance.api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDBContext db;

        public StockRepository(AppDBContext db)
        {
            this.db = db;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await db.Stocks.AddAsync(stockModel);
            await db.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await db.Stocks.Include(v => v.ToDto()).FirstOrDefaultAsync(v => v.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            db.Stocks.Remove(stockModel);
            await db.SaveChangesAsync();

            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await db.Stocks.Include(v => v.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await db.Stocks.Include(v => v.ToDto()).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await db.Stocks.FirstOrDefaultAsync(v => v.Id == id) != null;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdataStockDto stockDto)
        {
            var stackModel = await db.Stocks.Include(v => v.ToDto()).FirstOrDefaultAsync(v => v.Id == id);
            if (stackModel == null)
            {
                return null;
            }

            stackModel.Symbol = stockDto.Symbol;
            stackModel.CompanyName = stockDto.CompanyName;
            stackModel.Purchase = stockDto.Purchase;
            stackModel.LastDiv = stockDto.LastDiv;
            stackModel.Industry = stockDto.Industry;
            stackModel.MarketCap = stockDto.MarketCap;

            await db.SaveChangesAsync();

            return stackModel;
        }
    }
}
