using AutoMapper;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveRoleResource, Role>();
            CreateMap<SaveUserResource, User>();


            CreateMap<SaveSessionResource, Session>();
            CreateMap<SaveSessionDetailResource, SessionDetail>();


            CreateMap<SaveComplaintResource, Complaint>();
            CreateMap<SaveExperienceResource, Experience>();

            CreateMap<SaveSubscriptionResource, Subscription>();
            CreateMap<SaveScheduleResource, Schedule>();

            CreateMap<SaveDietResource, Diet>();
            CreateMap<SaveProgressResource, Progress>();
  
        }


    }
}
