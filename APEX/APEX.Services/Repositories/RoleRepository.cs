using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using APEX.Common.Models;

namespace APEX.Services.Repositories
{
    public class RoleRepository : BaseRepository<Role>//, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Role>> GetAllWithPermissionsAsync()
        {
            return await _context.Roles
                .Include(r => r.Permissions)
                .ThenInclude(rp => rp.Permission)
                .ToListAsync();
        }
    }
}
