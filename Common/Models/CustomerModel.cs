using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Number { get; set; }  // Could be customer number or other identifier
        public string Address { get; set; }

        // Optional: Add any additional properties you need
        public string Email { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}