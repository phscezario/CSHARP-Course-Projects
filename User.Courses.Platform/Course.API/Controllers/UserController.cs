using Course.API.Business.Entities;
using Course.API.Business.Repositories;
using Course.API.Configuration;
using Course.API.Filters;
using Course.API.Infrastructure.Data;
using Course.API.Infrastructure.Data.Repositories;
using Course.API.Models;
using Course.API.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Course.API.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public UserController(IUserRepository userRepository, IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// This service allows you to authenticate a registered and active user.
        /// </summary>
        /// <param name="loginViewModelInput">Login view model</param>
        /// <returns>Return status ok, user data and token if sucessful</returns>
        [SwaggerResponse(statusCode: 200, description: "Successful authentication.", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Required fields.", Type = typeof(ValidatesFieldViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Internal Error.", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("login")]
        [ValidationModelStateCustomized]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            var user = _userRepository.GetUser(loginViewModelInput.Login);

            if (user == null)
            {
                return BadRequest("There was an error trying to access");
            }

            /*if (user.Password != loginViewModelInput.Password.CreateEncriptedPassword())
            {
                return BadRequest("There was an error trying to access");
            }*/

            var userViewModelOutput = new UserViewModelOutput()
            {
                Code = user.Id,
                Login = loginViewModelInput.Login,
                Email = user.Email
            };

            var token = _authenticationService.GenerateToken(userViewModelOutput);

            return Ok(new
            {
                Token = token,
                User = userViewModelOutput
            });
        }

        /// <summary>
        /// TThis service allows you to register an unregistered user. 
        /// </summary>
        /// <param name="register">View model of the login register</param>
        [SwaggerResponse(statusCode: 200, description: "User successfully registered.", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Required fields.", Type = typeof(ValidatesFieldViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Internal Error.", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("register")]
        [ValidationModelStateCustomized]
        public IActionResult Register(RegisterViewModelInput loginViewModelInput)
        {
            //var migrationPendency = context.Database.GetPendingMigrations();

            /*if (migrationPendency.Count() > 0)
            {
                context.Database.Migrate();
            }*/

            var user = new User();
            user.Login = loginViewModelInput.Login;
            user.Email = loginViewModelInput.Email;
            user.Password = loginViewModelInput.Password;

            _userRepository.Add(user);
            _userRepository.Commit();

            return Created("", loginViewModelInput);
        }
    }
}
