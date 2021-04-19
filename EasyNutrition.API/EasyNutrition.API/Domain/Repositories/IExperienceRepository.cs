using EasyNutrition.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyNutrition.API
{
    public interface IExperienceRepository
    {
        Task<IEnumerable<Experience>> ListAsync();
        Task AddAsync(Experience experience);

        Task<Experience> FindById(int id);

        void Update(Experience experience);
        void Remove(Experience experience);

    }
}