using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Persistence.Contexts;
using EasyNutrition.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Persistence.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {

        public RoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
        }

        public async Task<Role> FindById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<IEnumerable<Role>> ListAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public void Remove(Role role)
        {
            _context.Roles.Remove(role);
        }

        public void Update(Role role)
        {
            _context.Roles.Update(role);
        }

    }
}
