using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;
        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            return await _context.portfolios.Where(p => p.AppUserId == user.Id).Select(stock => new Stock
            {
                Id = stock.StockId,
                Symbol = stock.stock.Symbol,
                CompanyName = stock.stock.CompanyName,
                PurchasePrice = stock.stock.PurchasePrice,
                LastDiv = stock.stock.LastDiv,
                Industry = stock.stock.Industry,
                MarketCap = stock.stock.MarketCap,
            }).ToListAsync();
        }
    }
}