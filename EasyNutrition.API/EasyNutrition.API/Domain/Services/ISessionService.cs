using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services
{
    public interface ISessionService
    {
        Task<IEnumerable<Session>> ListAsync();
        Task<IEnumerable<Session>> ListByUserIdAsync(int userId);

        Task<SessionResponse> GetByIdAsync(int id);
        Task<SessionResponse> SaveAsync(Session session);
        Task<SessionResponse> UpdateAsync(int id, Session session);

        Task<SessionResponse> DeleteAsync(int id);

    }
}
