using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        } 
        public  async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.Include(c => c.Comments).ToListAsync();
        }
        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int Id, UpdateStockRequestDto stockDto)
        {
            var exstock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == Id);

            if (exstock == null)
            {
                return null;
            }
            exstock.Symbol = stockDto.Symbol;
            exstock.CompanyName = stockDto.CompanyName;
            exstock.PurchasePrice = stockDto.PurchasePrice;
            exstock.LastDiv = stockDto.LastDiv;
            exstock.Industry = stockDto.Industry;
            exstock.MarketCap = stockDto.MarketCap;

            await _context.SaveChangesAsync();
            return exstock;
        }
        public async Task<Stock?> DeleteAsync(int Id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == Id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public Task<bool> StockExists(int Id)
        {
            return _context.Stocks.AnyAsync(s =>s.Id == Id);
        }
    }
}