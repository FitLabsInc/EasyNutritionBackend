using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> ListAsync();

        Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId);

        Task<ScheduleResponse> GetByIdAsync(int id);
        Task<ScheduleResponse> SaveAsync(Schedule schedule);
        Task<ScheduleResponse> UpdateAsync(int id, Schedule schedule);
    }
}

