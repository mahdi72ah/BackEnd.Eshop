using Angular.Eshop.Core.Services.Interfaces;
using Angular.Eshop.DataLayer.Entities.Account;
using Angular.Eshop.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Eshop.Core.DTOs.Acount;
using Microsoft.EntityFrameworkCore;

namespace Angular.Eshop.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        #region constructor

        private IGenericRepository<Users> userRepository;

        public UserService(IGenericRepository<Users> userRepository)
        {
            this.userRepository = userRepository;
        }

        #endregion

        #region User Section

        public async Task<List<Users>> GetAllUsers()
        {
            return await userRepository.GetEntitiesQuery().ToListAsync();
        }

        public async Task<RegisterUserResult> RegisterUser(RejisteruserDto rejisteruserDto)
        {
            if (IsExitesUserByEmail(rejisteruserDto.Email))
                return RegisterUserResult.EmailExists;

            var user = new Users()
            {
                Address = rejisteruserDto.Address,
                Email = rejisteruserDto.Email,
                FirstName = rejisteruserDto.FirstName,
                lastName = rejisteruserDto.lastName,
                EmailActiveCode = Guid.NewGuid().ToString()
            };

            await userRepository.AddEntity(user);
            await userRepository.SaveChanges();

            return RegisterUserResult.Success;
        }

        public bool IsExitesUserByEmail(string email)
        {
            return userRepository.GetEntitiesQuery().Any(p => p.Email == email);
        }

        #endregion

        #region dispose

        public void Dispose()
        {
            userRepository?.Dispose();
        }

        #endregion
    }
}
