using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Repositories
{
    public interface ISessionDetailRepository
    {
        Task<IEnumerable<SessionDetail>> ListAsync();
        Task<IEnumerable<SessionDetail>> ListByUserIdAsync(int userId);
        Task<IEnumerable<SessionDetail>> ListBySessionIdAsync(int sesssionId);

        Task AddAsync(SessionDetail sessionDetail);

        Task<SessionDetail> FindById(int userId);
        Task<SessionDetail> FindByyId(int sessionId);

        void Update(SessionDetail sessionDetail);

        void Remove(SessionDetail sessionDetail);

        
    }
}
