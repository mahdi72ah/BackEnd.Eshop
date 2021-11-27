using Angular.Eshop.Core.Services.Interfaces;
using Angular.Eshop.DataLayer.Entities.Account;
using Angular.Eshop.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion

        #region dispose

        public void Dispose()
        {
            userRepository?.Dispose();
        }

        #endregion
    }
}
