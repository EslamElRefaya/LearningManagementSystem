using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagementSystem.Domain.Entities;
using LearningManagementSystem.Domain.Enums;

namespace LearningManagementSystem.Domain.Interfaces.Repositories
{
    interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByRoleAsync(UserRole Role);
    }
}
