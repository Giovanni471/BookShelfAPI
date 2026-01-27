using BookShelf.Models;
using BookShelf.Repositories.Interfaces;
using BookShelf.Services.Interfaces;

namespace BookShelf.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly ICategorieRepository _categorieRepository;

        public CategorieService(ICategorieRepository categorieRepository)
        {
            _categorieRepository = categorieRepository;
        }

        public async Task<List<Categorie>> GetAllCategoriesAsync()
        {
            return await _categorieRepository.GetAllCategoriesAsync();
        }

        public async Task<List<Categorie>> GetBookCategoriesAsyncByIdBook(int id)
        {
            return await _categorieRepository.GetBookCategoriesAsyncByIdBook(id);
        }
    }
}