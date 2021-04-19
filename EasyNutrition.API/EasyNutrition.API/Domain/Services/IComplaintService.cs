using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services
{
    public interface IComplaintService
    {
        Task<IEnumerable<Complaint>> ListAsync();
        Task<ComplaintResponse> SaveAsync(Complaint complaint);

        Task<ComplaintResponse> UpdateAsync(int id, Complaint complaint);

        Task<ComplaintResponse> DeleteAsync(int id);



    }



}