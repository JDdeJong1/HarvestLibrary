using HarvestLibrary.Database;
using HarvestLibrary.DTOs.Customer;
using HarvestLibrary.Model;
using Microsoft.AspNetCore.Mvc;

namespace HarvestLibrary.Controllers
{
    [Route("HarvestLibrary/CustomerController")]
    [ApiController]
    public class CustomerController
    {
        private readonly LibraryContext _context;
        private LibraryService _libraryService;

        public CustomerController(LibraryContext context)
        {
            _context = context;
            _libraryService = LibraryService.GetInstance(context);
        }

        [HttpPost]
        public IActionResult RegisterCustomer([FromBody] RegisterCustomerDTO reg)
        {
            return _libraryService.RegisterCustomer(reg);
        }
    }
}
