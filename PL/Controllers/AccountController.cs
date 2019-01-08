using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using BLL.Models;
using BLL.Interfaces;
using BLL.Infrastructure;
using System.Web;

namespace PL.Controllers
{
    public class AccountController : ApiController
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


    }
}
