using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APEX.Common.Interfaces;

namespace APEX.Common.Models
{
    public class Permission : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RolePermission> Roles { get; set; } = new List<RolePermission>();
    }
}
