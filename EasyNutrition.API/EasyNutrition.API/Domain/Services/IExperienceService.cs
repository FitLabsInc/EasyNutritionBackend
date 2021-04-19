using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services
{
    public interface IExperienceService
    {
        Task<IEnumerable<Experience>> ListAsync();
        Task<ExperienceResponse> SaveAsync(Experience experience);

        Task<ExperienceResponse> UpdateAsync(int id, Experience experience);

        Task<ExperienceResponse> DeleteAsync(int id);

    }

}
