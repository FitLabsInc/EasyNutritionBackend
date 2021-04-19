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
    public class SessionService : ISessionService
    {

        private readonly ISessionRepository _sessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SessionService(ISessionRepository sessionRepository, IUnitOfWork unitOfWork)
        {
            _sessionRepository = sessionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Session>> ListAsync()
        {
            return await _sessionRepository.LisAsync();
        }

        public async Task<IEnumerable<Session>> ListByUserIdAsync(int userId)
        {
            return await _sessionRepository.ListByUserIdAsync(userId);
        }


        public async Task<SessionResponse> GetByIdAsync(int id)
        {
            var existingSession = await _sessionRepository.FindById(id);

            if (existingSession == null)
                return new SessionResponse("Session not found");
            return new SessionResponse(existingSession);
        }


        public async Task<SessionResponse> SaveAsync(Session session)
        {
            try
            {
                await _sessionRepository.AddAsync(session);
                await _unitOfWork.CompleteAsync();

                return new SessionResponse(session);
            }
            catch (Exception ex)
            {
                return new SessionResponse($"An error ocurred while saving session: {ex.Message}");
            }
        }

        public async Task<SessionResponse> UpdateAsync(int userId, Session session)
        {
            var existingSession = await _sessionRepository.FindById(userId);
            if (existingSession == null)
                return new SessionResponse("Session not found");

            existingSession.Link = session.Link;

            try
            {
                _sessionRepository.Update(existingSession);
                await _unitOfWork.CompleteAsync();

                return new SessionResponse(existingSession);
            }
            catch (Exception ex)
            {
                return new SessionResponse($"An error ocurred while updating Session: {ex.Message}");
            }
        }


        public async Task<SessionResponse> DeleteAsync(int id)
        {
            var existingSession = await _sessionRepository.FindById(id);

            if (existingSession == null)
                return new SessionResponse("Session not found");

            try
            {
                _sessionRepository.Remove(existingSession);
                await _unitOfWork.CompleteAsync();

                return new SessionResponse(existingSession);
            }
            catch (Exception ex)
            {
                return new SessionResponse($"An error ocurred while deleting session: {ex.Message}");
            }
        }


    }
}
