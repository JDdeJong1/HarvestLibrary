using HarvestLibrary.Database;
using HarvestLibrary.DTOs.Reservation;
using HarvestLibrary.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HarvestLibrary.Controllers
{
    [Route("HarvestLibrary/ReservationController")]
    [ApiController]
    public class ReservationController
    {
        private readonly LibraryContext _context;
        private LibraryService _libraryService;

        public ReservationController(LibraryContext context)
        {
            _context = context;
            _libraryService = LibraryService.GetInstance(context);
        }

        [HttpGet("{id}")]
        public IActionResult GetReservationByID([FromRoute] int id)
        {
            return _libraryService.GetReservationByID(id);
        }


        [HttpPost]
        public IActionResult CreateReservation([FromBody] CreateReservationRequestDTO request)
        {
            return _libraryService.CreateReservation(request);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteReservation([FromRoute] int id)
        {
            return _libraryService.DeleteReservation(id);
        }
    }
}
