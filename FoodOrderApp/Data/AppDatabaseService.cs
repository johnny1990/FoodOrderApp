using FoodOrderApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp.Data
{
    public class AppDatabaseService
    {
        private readonly OrderAppDbContext _context;

        public AppDatabaseService(OrderAppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated(); 
        }

        public async Task<List<Table>> GetTablesAsync() =>
            await _context.Tables.ToListAsync();

        public async Task AddDummyTablesAsync()
        {
            if (_context.Tables.Any()) return;

            var tables = Enumerable.Range(1, 15)
                .Select(i => new Table { Name = i.ToString(), IsOccupied = false })
                .ToList();
            tables.Insert(0, new Table { Name = "W", IsOccupied = false });

            _context.Tables.AddRange(tables);
            await _context.SaveChangesAsync();
        }

        // Additional methods for Products, Orders, etc.
    }

}
