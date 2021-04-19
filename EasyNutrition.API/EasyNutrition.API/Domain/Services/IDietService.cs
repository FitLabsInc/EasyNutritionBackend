using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services
{
    public interface IDietService
    {
        Task<IEnumerable<Diet>> ListAsync();
        Task<IEnumerable<Diet>> ListBySessionIdAsync(int sessionId);

        Task<DietResponse> GetByIdAsync(int id);
        Task<DietResponse> SaveAsync(Diet diet);
        Task<DietResponse> UpdateAsync(int id, Diet diet);

        Task<DietResponse> DeleteAsync(int id);
    }
}
