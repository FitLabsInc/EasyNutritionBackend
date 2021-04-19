using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Repositories
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> ListAsync();

        Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId);

        Task AddAsync(Schedule schedule);
        Task<Schedule> FindById(int userId);
        void Update(Schedule schedule);
        void Remove(Schedule schedule);
    }
}
