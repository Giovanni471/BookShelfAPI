using BookShelf.Data;
using BookShelf.Models;
using BookShelf.Models.DapperModels;
using BookShelf.Models.ViewModels;
using BookShelf.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
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

        public async Task<List<LibroViewModel>> GetAllLibriWithCategorie()
        {
            try
            {
                var connectionString = _context.Database.GetConnectionString();
                List<LibroViewModel> returnList = new List<LibroViewModel>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    var viewModel = await conn.QueryAsync<ViewLibriCategorieModel>("SELECT * FROM ViewLibriCategorie");

                    returnList = ViewLibriCategorieModel.MapViewToModel(viewModel);
                }

                return returnList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
