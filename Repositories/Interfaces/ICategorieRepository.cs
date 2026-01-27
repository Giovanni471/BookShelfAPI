using BookShelf.Models;

namespace BookShelf.Repositories.Interfaces
{
    public interface ICategorieRepository
    {
        public Task<List<Categorie>> GetAllCategoriesAsync();

        public Task<List<Categorie>> GetBookCategoriesAsyncByIdBook(int id);
    }
}
