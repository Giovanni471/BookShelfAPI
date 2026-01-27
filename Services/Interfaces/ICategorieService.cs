using BookShelf.Models;

namespace BookShelf.Services.Interfaces
{
    public interface ICategorieService
    {
        Task<List<Categorie>> GetAllCategoriesAsync();
        Task<List<Categorie>> GetBookCategoriesAsyncByIdBook(int id);
    }
}