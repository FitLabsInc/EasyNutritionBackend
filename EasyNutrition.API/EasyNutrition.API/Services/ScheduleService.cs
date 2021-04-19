using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Repositories;
using EasyNutrition.API.Domain.Services;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyNutrition.API.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public async Task<IEnumerable<Schedule>> ListAsync()
        {
            return await _scheduleRepository.ListAsync();
        }
        public ScheduleService(IScheduleRepository scheduleRepository, IUnitOfWork unitOfWork)
        {
            _scheduleRepository = scheduleRepository;
            _unitOfWork = unitOfWork;
        }
    
        public async Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId)
        {
            return await _scheduleRepository.ListByUserIdAsync(userId);
        }

        public async Task<ScheduleResponse> GetByIdAsync(int id)
        {
            var existingSchedule = await _scheduleRepository.FindById(id);

            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");
            return new ScheduleResponse(existingSchedule);
        }

        public async Task<ScheduleResponse> SaveAsync(Schedule schedule)
        {
            try
            {
                await _scheduleRepository.AddAsync(schedule);
                await _unitOfWork.CompleteAsync();

                return new ScheduleResponse(schedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while saving schedule: {ex.Message}");
            }
        }

        public async Task<ScheduleResponse> UpdateAsync(int userId, Schedule schedule)
        {
            var existingSchedule = await _scheduleRepository.FindById(userId);
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");

            existingSchedule.State = schedule.State;

            try
            {
                _scheduleRepository.Update(existingSchedule);
                await _unitOfWork.CompleteAsync();

                return new ScheduleResponse(existingSchedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while updating schedule: {ex.Message}");
            }
        }

        public async Task<ScheduleResponse> DeleteAsync(int id)
        {
            var existingSchedule = await _scheduleRepository.FindById(id);

            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");

            try
            {
                _scheduleRepository.Remove(existingSchedule);
                await _unitOfWork.CompleteAsync();

                return new ScheduleResponse(existingSchedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while deleting schedule: {ex.Message}");
            }
        }


    }
}
