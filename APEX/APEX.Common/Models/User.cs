using System;
using System.Collections.Generic;
using APEX.Common.Interfaces;

namespace APEX.Common.Models
{
    public class User : IEntity<int>, IAuditable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }

}
