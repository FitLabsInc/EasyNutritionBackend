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
    public class SubscriptionRepository : BaseRepository, ISubscriptionRepository
    {

        public SubscriptionRepository(AppDbContext context) : base(context)
        {
        }

    
        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _context.Subscriptions.Include(p=> p.User).ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> ListByUserIdAsync(int userId)
        {
            return await _context.Subscriptions
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task AddAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
        }

        public async Task<Subscription> FindById(int userId)
        {
            return await _context.Subscriptions.FindAsync(userId);
        }

        public void Remove(Subscription subscription)
        {
            _context.Subscriptions.Remove(subscription);
        }

        public void Update(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
        }
    }
}
