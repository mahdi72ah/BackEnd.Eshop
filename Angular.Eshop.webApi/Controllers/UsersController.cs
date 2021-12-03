using Angular.Eshop.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Angular.Eshop.webApi.Controllers
{
    public class UsersController : SiteBaseController
    {
        private IUserService userservice;

        public UsersController(IUserService userservice)
        {
            this.userservice = userservice;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Users()
        {
            return new ObjectResult(await userservice.GetAllUsers());
        }

    }
}
