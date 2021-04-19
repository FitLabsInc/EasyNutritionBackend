using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services
{
    public interface IProgressService
    {
        Task<IEnumerable<Progress>> ListAsync();
        Task<IEnumerable<Progress>> ListBySessionIdAsync(int sessionId);

        Task<ProgressResponse> GetByIdAsync(int id);
        Task<ProgressResponse> SaveAsync(Progress progress);
        Task<ProgressResponse> UpdateAsync(int id, Progress progress);

        Task<ProgressResponse> DeleteAsync(int id);
    }
}
