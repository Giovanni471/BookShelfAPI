using BookShelf.Data;
using BookShelf.Models;
using BookShelf.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly MyDbContext _context;

        public CategorieRepository(MyDbContext context) { _context = context; }

        public async Task<List<Categorie>> GetAllCategoriesAsync()
        {
            try
            {
                return await _context.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Categorie>> GetBookCategoriesAsyncByIdBook(int id)
        {
            try
            {
                var categorieIds = _context.LibroCategoria
                                .Where(lc => lc.IdLibro == id)
                                .Select(lc => lc.IdCategoria);

                var categories = await _context.Categories
                    .Where(cat => categorieIds.Contains(cat.Id))
                    .ToListAsync();

                return categories;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
