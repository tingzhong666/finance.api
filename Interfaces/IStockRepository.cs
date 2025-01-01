using finance.api.DTOs.Stock;
using finance.api.Models;

namespace finance.api.Interfaces
{
    public interface IStockRepository
    {
        public Task<List<Stock>> GetAllAsync();
        public Task<Stock?> GetByIdAsync(int id);
        public Task<Stock> CreateAsync(Stock stockModel);
        public Task<Stock?> UpdateAsync(int id, UpdataStockDto stockDto);
        public Task<Stock?> DeleteAsync(int id);
        public Task<bool> IsExistAsync(int id);
    }
}
