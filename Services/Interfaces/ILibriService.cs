using BookShelf.Models;

namespace BookShelf.Services.Interfaces
{
    public interface ILibriService
    {
        Task<List<Libri>> GetAllLibriAsync();
        Task<Libri?> GetLibroByIdAsync(int id);
    }
}