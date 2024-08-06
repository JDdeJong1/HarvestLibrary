using HarvestLibrary.Database;
using HarvestLibrary.DTOs.Book;
using HarvestLibrary.DTOs.Customer;
using HarvestLibrary.DTOs.Reservation;
using HarvestLibrary.Model;
using Microsoft.AspNetCore.Mvc;

namespace HarvestLibrary.Controllers
{
    public class LibraryService : ControllerBase
    {
        private static LibraryService _instance;

        private static readonly object _lock = new object();
        private static readonly object _reservationLock = new object();

        private LibraryContext _context;

        public static LibraryService GetInstance(LibraryContext context)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LibraryService(context);
                    }
                }
            }
            return _instance;
        }

        private LibraryService(LibraryContext context)
        {
            _context = context;
        }

        // BOOK
        public IActionResult SearchBook(SearchBookDTO search)
        {
            var hits = _context.Books.Where(b => b.Title == search.query || b.Author == search.query).ToList();
            return Ok(hits);
        }

        // CUSTOMER
        public IActionResult RegisterCustomer(RegisterCustomerDTO reg)
        {
            Customer cus = new Customer
            {
                Name = reg.CustomerName
            };
            _context.Customers.Add(cus);
            _context.SaveChanges();
            return Ok();
        }

        // RESERVATION
        public IActionResult GetReservationByID(int id)
        {
            Reservation res = _context.Reservations.Find(id);

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        public IActionResult CreateReservation(CreateReservationRequestDTO request)
        {
            Book maybeBook = _context.Books.Where(b => b.Title == request.BookTitle).FirstOrDefault();

            if (maybeBook == null)
            {
                return NotFound();
            }

            Reservation maybeReserved = _context.Reservations.Where(r => r.BookID == maybeBook.Id).FirstOrDefault();
            if (maybeReserved != null)
            {
                return Conflict();
            }

            Reservation res = new Reservation
            {
                CustomerID = request.CustomerID,
                BookID = maybeBook.Id,
            };
            _context.Reservations.Add(res);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetReservationByID), new { id = res.Id }, res);
        }                      

        public IActionResult DeleteReservation(int id)
        {
            Reservation res = _context.Reservations.FirstOrDefault(r => r.Id == id);

            if (res == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(res);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
