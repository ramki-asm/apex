// APEX.Services/Repositories/RoleRepository.cs
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using APEX.Common.Models;
using APEX.Services.Data;
using APEX.Services.Repositories;
using Services.Services;

namespace Services.Repositories
{
    public class RoleRepository : BaseRepository<Role>//, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        //    public async Task<IEnumerable<Role>> GetAllWithPermissionsAsync()
        //    {
        //        return await _context.Roles
        //            .Include(r => r.Permissions.Select(rp => rp.Permission))
        //            .ToListAsync();
        //    }
        //}
    }
}