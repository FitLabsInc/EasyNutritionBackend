using AutoMapper;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Role, RoleResource>();
            CreateMap<User, UserResource>();


            CreateMap<Session, SessionResource>();

            CreateMap<SessionDetail, SessionDetailResource>();


            CreateMap<Complaint, ComplaintResource>();
            CreateMap<Experience, ExperienceResource>();

            CreateMap<Subscription, SubscriptionResource>();

            CreateMap<Schedule, ScheduleResource>();

            CreateMap<Diet, DietResource>();
            CreateMap<Progress, ProgressResource>();
        }
    }
}
