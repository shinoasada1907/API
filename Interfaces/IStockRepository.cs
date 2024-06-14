using API.DTO.Stock;
using API.Helpers;
using API.Models;

namespace API.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject queryObject);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stock);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDTO stockRequestDTO);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExists(int id);
    }
}