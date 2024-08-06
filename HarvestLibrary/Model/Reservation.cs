using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvestLibrary.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public int? CustomerID { get; set; }
        public int? BookID { get; set; }
    }
}
