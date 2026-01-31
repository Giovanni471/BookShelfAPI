using BookShelf.Models;
using BookShelf.Models.ViewModels;

namespace BookShelf.Repositories.Interfaces
{
    public interface ILibriRepository
    {
        public Task<List<Libri>> GetAllLibri();
        public Task<Libri> GetLibroById(int id);
        public Task<List<LibroViewModel>> GetAllLibriWithCategorie();


    }
}
