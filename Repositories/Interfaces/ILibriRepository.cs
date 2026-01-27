using BookShelf.Models;

namespace BookShelf.Repositories.Interfaces
{
    public interface ILibriRepository
    {
        public Task<List<Libri>> GetAllLibri();
        public Task<Libri> GetLibroById(int id);

    }
}
