using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Repositories
{
    public interface IProgressRepository
    {
        Task<IEnumerable<Progress>> ListAsync();
        Task<IEnumerable<Progress>> ListBySessionIdAsync(int sessionId);

        Task AddAsync(Progress progress);

        Task<Progress> FindById(int id);

        void Update(Progress progress);

        void Remove(Progress progress);
    }
}
