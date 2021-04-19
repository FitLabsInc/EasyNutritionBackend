using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task<IEnumerable<Subscription>> ListByUserIdAsync(int userId);

        Task<SubscriptionResponse> GetByIdAsync(int id);
        Task<SubscriptionResponse> SaveAsync(Subscription subscription);
        Task<SubscriptionResponse> UpdateAsync(int id, Subscription subscription);
    }
}
