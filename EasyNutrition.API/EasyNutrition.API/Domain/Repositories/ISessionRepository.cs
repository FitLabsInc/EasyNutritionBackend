using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Repositories
{
    public interface ISessionRepository
    {

        Task<IEnumerable<Session>> LisAsync();
        Task<IEnumerable<Session>> ListByUserIdAsync(int userId);

        Task AddAsync(Session session);

        Task<Session> FindById(int userId);

        void Update(Session session);

        void Remove(Session session);
    }
}
