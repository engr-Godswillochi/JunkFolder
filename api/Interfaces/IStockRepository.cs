using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModej);
        Task<Stock?> UpdateAsync(int Id, UpdateStockRequestDto stockDto);
        Task<Stock?> DeleteAsync(int Id);
        Task<bool> StockExists(int Id);
    }
}