using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Repositories
{
    public interface IUserRepository
    {

        Task<IEnumerable<User>> ListAsync();
        Task<IEnumerable<User>> ListByRoleIdAsync(int roleId);
        Task AddAsync(User user);
        Task<User> FindById(int id);
        void Update(User user);
        void Remove(User user);

    }
}
