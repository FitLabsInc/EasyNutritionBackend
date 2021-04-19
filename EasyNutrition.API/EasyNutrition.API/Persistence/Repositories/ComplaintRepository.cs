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
    public class ComplaintRepository : BaseRepository, IComplaintRepository
    {
        public ComplaintRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Complaint>> ListAsync()
        {
            return await _context.Complaint.Include(p => p.User).ToListAsync();

        }

        public async Task AddAsync(Complaint complaint)
        {
            await _context.Complaint.AddAsync(complaint);
        }

        public async Task<Complaint> FindById(int id)
        {
            return await _context.Complaint.FindAsync(id);
        }

        public void Update(Complaint complaint)
        {
            _context.Complaint.Update(complaint);
        }

        public void Remove(Complaint complaint)
        {
            _context.Complaint.Remove(complaint);
        }
    }

}
