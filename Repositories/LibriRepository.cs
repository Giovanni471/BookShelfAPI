using BookShelf.Data;
using BookShelf.Models;
using BookShelf.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookShelf.Repositories
{
    public class LibriRepository : ILibriRepository
    {
        private readonly MyDbContext _context;

        public LibriRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Libri>> GetAllLibri()
        {
            try
            {
                return await _context.Libris.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Libri?> GetLibroById(int id)
        {
            try
            {
                return await _context.Libris.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
