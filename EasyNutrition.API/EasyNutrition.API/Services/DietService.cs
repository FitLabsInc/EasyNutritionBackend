using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Repositories;
using EasyNutrition.API.Domain.Services;
using EasyNutrition.API.Domain.Services.Communication;
using EasyNutrition.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Services
{
    public class DietService : IDietService
    {
        private readonly IDietRepository _dietRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DietService(IDietRepository dietRepository, IUnitOfWork unitOfWork)
        {
            _dietRepository = dietRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Diet>> ListAsync()
        {
            return await _dietRepository.ListAsync();
        }

        public async Task<IEnumerable<Diet>> ListBySessionIdAsync(int sessionId)
        {
            return await _dietRepository.ListBySessionIdAsync(sessionId);
        }


        public async Task<DietResponse> GetByIdAsync(int id)
        {
            var existingDiet = await _dietRepository.FindById(id);

            if (existingDiet == null)
                return new DietResponse("Diet not found");
            return new DietResponse(existingDiet);
        }


        public async Task<DietResponse> SaveAsync(Diet diet)
        {
            try
            {
                await _dietRepository.AddAsync(diet);
                await _unitOfWork.CompleteAsync();

                return new DietResponse(diet);
            }
            catch (Exception ex)
            {
                return new DietResponse($"An error ocurred while saving diet: {ex.Message}");
            }
        }

        public async Task<DietResponse> UpdateAsync(int id, Diet diet)
        {
            var existingDiet = await _dietRepository.FindById(id);
            if (existingDiet == null)
                return new DietResponse("Diet not found");

            existingDiet.Description = diet.Description;

            try
            {
                _dietRepository.Update(existingDiet);
                await _unitOfWork.CompleteAsync();

                return new DietResponse(existingDiet);
            }
            catch (Exception ex)
            {
                return new DietResponse($"An error ocurred while updating Diet: {ex.Message}");
            }
        }


        public async Task<DietResponse> DeleteAsync(int id)
        {
            var existingDiet = await _dietRepository.FindById(id);

            if (existingDiet == null)
                return new DietResponse("Diet not found");

            try
            {
                _dietRepository.Remove(existingDiet);
                await _unitOfWork.CompleteAsync();

                return new DietResponse(existingDiet);
            }
            catch (Exception ex)
            {
                return new DietResponse($"An error ocurred while deleting diet: {ex.Message}");
            }
        }
    }
}
