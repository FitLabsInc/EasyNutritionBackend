using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task<IEnumerable<Subscription>> ListByUserIdAsync(int userId);

        Task AddAsync(Subscription subscription);
        Task<Subscription> FindById(int userId);
        void Update(Subscription subscription);
        void Remove(Subscription subscription);
    }
}
