using Angular.Eshop.DataLayer.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angular.Eshop.Core.DTOs.Acount;

namespace Angular.Eshop.Core.Services.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<List<Users>> GetAllUsers();
        Task<RegisterUserResult> RegisterUser(RejisteruserDto rejisteruserDto);
        bool IsExitesUserByEmail(string email);
    }
}
