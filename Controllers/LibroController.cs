using BookShelf.Data;
using BookShelf.Models;
using BookShelf.Models.ViewModels;
using BookShelf.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{
    [Route("/api/Libri")]
    public class LibroController : Controller
    {
        private readonly ILibriService _libriService;

        public LibroController(ILibriService serv)
        {
            _libriService = serv;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Libri>>> GetAllLibri()
        {
            return await _libriService.GetAllLibriAsync();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Libri?>> GetLibroById(int Id)
        {
            return await _libriService.GetLibroByIdAsync(Id);
        }


        [HttpGet]
        [Route("GetAllWithCategorie")]
        public async Task<ActionResult<List<LibroViewModel?>>> GetAllLibriWithCategorie()
        {
            return await _libriService.GetAllLibriWithCategorie();
        }
    }
}
