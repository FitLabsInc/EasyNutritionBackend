using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Repositories
{
    public interface IDietRepository
    {
        Task<IEnumerable<Diet>> ListAsync();
        Task<IEnumerable<Diet>> ListBySessionIdAsync(int sessionId);

        Task AddAsync(Diet diet);

        Task<Diet> FindById(int id);

        void Update(Diet diet);

        void Remove(Diet diet);
    }
}
