using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Persistence.Contexts;
using EasyNutrition.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyNutrition.API
{
    public class ExperienceRepository : BaseRepository, IExperienceRepository
    {
        public ExperienceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Experience>> ListAsync()
        {
            return await _context.Experience.Include(p => p.User).ToListAsync();
        }

        public async Task AddAsync(Experience experience)
        {
            await _context.Experience.AddAsync(experience);
        }

        public async Task<Experience> FindById(int id)
        {
            return await _context.Experience.FindAsync();
        }

        public void Update(Experience experience)
        {
            _context.Experience.Update(experience);
        }

        public void Remove(Experience experience)
        {
            _context.Experience.Remove(experience);
        }

    }
}