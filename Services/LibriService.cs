using BookShelf.Models;
using BookShelf.Repositories;
using BookShelf.Repositories.Interfaces;
using BookShelf.Services.Interfaces;

namespace BookShelf.Services
{
    public class LibriService : ILibriService
    {
        private readonly ILibriRepository _libriRepository;
        public LibriService(ILibriRepository libriRepository)
        {
            _libriRepository = libriRepository;
        }

        public async Task<List<Libri>> GetAllLibriAsync()
        {
            return await _libriRepository.GetAllLibri();
        }

        public async Task<Libri?> GetLibroByIdAsync(int id)
        {
            return await _libriRepository.GetLibroById(id);
        }
    }
}