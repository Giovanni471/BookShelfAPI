using BookShelf.Models;
using BookShelf.Models.ViewModels;

namespace BookShelf.Services.Interfaces
{
    public interface ILibriService
    {
        Task<List<Libri>> GetAllLibriAsync();
        Task<Libri?> GetLibroByIdAsync(int id);
        Task<List<LibroViewModel>> GetAllLibriWithCategorie();
    }
}