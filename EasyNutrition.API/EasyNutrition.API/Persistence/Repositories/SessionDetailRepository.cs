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
    public class SessionDetailRepository : BaseRepository, ISessionDetailRepository
    {
        public SessionDetailRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SessionDetail>> ListAsync()
        {
            return await _context.SessionDetails.Include(p => p.User).ToListAsync();
        }

     

        public async Task<IEnumerable<SessionDetail>> ListByUserIdAsync(int userId)
        {
            return await _context.SessionDetails
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<SessionDetail>> ListBySessionIdAsync(int sesssionId)
        {
            return await _context.SessionDetails
                .Where(p => p.SessionId == sesssionId)
                .Include(p => p.Session)
                .ToListAsync();
        }


        public async Task AddAsync(SessionDetail sessionDetail)
        {
            await _context.SessionDetails.AddAsync(sessionDetail);
        }

        public async Task<SessionDetail> FindById(int userId)
        {
           return  await _context.SessionDetails.FindAsync(userId);
        }

        public async Task<SessionDetail> FindByyId(int sessionId)
        {
            return await _context.SessionDetails.FindAsync(sessionId);
        }

        

        public void Remove(SessionDetail sessionDetail)
        {
            _context.SessionDetails.Remove(sessionDetail);
        }

        public void Update(SessionDetail sessionDetail)
        {
            _context.SessionDetails.Update(sessionDetail);
        }
    }
}
