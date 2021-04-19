using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Repositories;
using EasyNutrition.API.Domain.Services;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyNutrition.API.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
        {
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _subscriptionRepository.ListAsync();
        }

        public async Task<IEnumerable<Subscription>> ListByUserIdAsync(int userId)
        {
            return await _subscriptionRepository.ListByUserIdAsync(userId);
        }

        public async Task<SubscriptionResponse> GetByIdAsync(int id)
        {
            var existingSubscription = await _subscriptionRepository.FindById(id);

            if (existingSubscription == null)
                return new SubscriptionResponse("Subscription not found");
            return new SubscriptionResponse(existingSubscription);
        }


        public async Task<SubscriptionResponse> SaveAsync(Subscription subscription)
        {
            try
            {
                await _subscriptionRepository.AddAsync(subscription);
                await _unitOfWork.CompleteAsync();

                return new SubscriptionResponse(subscription);
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse($"An error ocurred while saving subscription: {ex.Message}");
            }
        }

        public async Task<SubscriptionResponse> UpdateAsync(int userId, Subscription subscription)
        {
            var existingSubscription = await _subscriptionRepository.FindById(userId);
            if (existingSubscription == null)
                return new SubscriptionResponse("Subscription not found");

            existingSubscription.MaxSessions = subscription.MaxSessions;

            try
            {
                _subscriptionRepository.Update(existingSubscription);
                await _unitOfWork.CompleteAsync();

                return new SubscriptionResponse(existingSubscription);
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse($"An error ocurred while updating subscription: {ex.Message}");
            }
        }

        public async Task<SubscriptionResponse> DeleteAsync(int id)
        {
            var existingSubscription = await _subscriptionRepository.FindById(id);

            if (existingSubscription == null)
                return new SubscriptionResponse("Subscription not found");

            try
            {
                _subscriptionRepository.Remove(existingSubscription);
                await _unitOfWork.CompleteAsync();

                return new SubscriptionResponse(existingSubscription);
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse($"An error ocurred while deleting subscription: {ex.Message}");
            }
        }


    }
}
