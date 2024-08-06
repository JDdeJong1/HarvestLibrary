using HarvestLibrary.Database;
using HarvestLibrary.DTOs.Book;
using HarvestLibrary.DTOs.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace HarvestLibrary.Controllers
{
    [Route("HarvestLibrary/BookController")]
    [ApiController]
    public class BookController
    {
        private readonly LibraryContext _context;
        private LibraryService _libraryService;

        public BookController(LibraryContext context)
        {
            _context = context;
            _libraryService = LibraryService.GetInstance(context);
        }
        [HttpPost]
        public IActionResult SearchBook([FromBody] SearchBookDTO search)
        {
            return _libraryService.SearchBook(search);
        }
    }
}
