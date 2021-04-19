using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Repositories;
using EasyNutrition.API.Domain.Services;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExperienceService(IExperienceRepository experienceRepository, IUnitOfWork unitOfWork)
        {
            _experienceRepository = experienceRepository;
            _unitOfWork = unitOfWork;

        }


        public async Task<IEnumerable<Experience>> ListAsync()
        {
            return await _experienceRepository.ListAsync();
        }

        public async Task<ExperienceResponse> SaveAsync(Experience experience)
        {
            try
            {
                await _experienceRepository.AddAsync(experience);
                await _unitOfWork.CompleteAsync();

                return new ExperienceResponse(experience);
            }
            catch(Exception ex)
            {
                return new ExperienceResponse($"An error ocurred while saving experience:{ ex.Message}");
            }

        }

        public async Task<ExperienceResponse> UpdateAsync(int id, Experience experience)
        {
            var existingExperience = await _experienceRepository.FindById(id);

            if (existingExperience == null)
                return new ExperienceResponse("Complaint not found");

            existingExperience.Description = experience.Description;

            try
            {
                _experienceRepository.Update(existingExperience);
                await _unitOfWork.CompleteAsync();

                return new ExperienceResponse(existingExperience);
            }
            catch (Exception ex)
            {
                return new ExperienceResponse($"An error ocurred while updating experience: {ex.Message}");
            }

        }

        public async Task<ExperienceResponse> DeleteAsync(int id)
        {
            var existingExperience = await _experienceRepository.FindById(id);

            if (existingExperience == null)
                return new ExperienceResponse("Experience not found");

            try
            {
                _experienceRepository.Remove(existingExperience);
                await _unitOfWork.CompleteAsync();

                return new ExperienceResponse(existingExperience);
            }
            catch (Exception ex)
            {
                return new ExperienceResponse($"An error ocurred while deleting experience:{ex.Message}");
            }

        }

    }


}
