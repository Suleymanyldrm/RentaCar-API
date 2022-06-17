using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCar_API.Data;
using RentaCar_API.DTOs;
using RentaCar_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnonymousController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public AnonymousController(RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;

        }
        [HttpPost("Register")]
        public IActionResult Register(SaveUserDTO users)
        {
            var user = new User
            {
                Name = users.FullName,
                Email = users.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(users.Password)
            };
            _rentaCarContext.Users.Add(user);
            _rentaCarContext.SaveChanges();
            return Ok(user);


        }
    }
}
