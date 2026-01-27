using BookShelf.Data;
using BookShelf.Models;
using BookShelf.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{
    [Route("/api/Categorie")]
    public class CategoriaController : Controller
    {
        private readonly ICategorieService _categoriaService;

        public CategoriaController(ICategorieService serv)
        {
            _categoriaService = serv;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Categorie>>> GetAllCategorie()
        {
            return await _categoriaService.GetAllCategoriesAsync();
        }

        [HttpGet]
        [Route("GetByIdBook")]
        public async Task<ActionResult<List<Categorie>>> GetCategorieLibroById(int Id)
        {
            return await _categoriaService.GetBookCategoriesAsyncByIdBook(Id);
        }
    }
}
