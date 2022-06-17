﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCar_API.Data;
using RentaCar_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar_API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "UserPolicy")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public UserController(RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(User users)
        {
            var user = new User
            {
                Name = users.Name,
                Email = users.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(users.Password)
            };
            _rentaCarContext.Users.Add(user);
            _rentaCarContext.SaveChanges();
            return Ok(user);
            //return Created(uri: "success", value: (_rentaCarContext.Users.Add(user)user.Id = _rentaCarContext.SaveChanges()));

        }
        //[HttpPost("Login")]
        //public IActionResult Login([FromBody] LoginDTO values)
        //{
        //    var user = _rentaCarContext.Users.FirstOrDefault(e => e.Email == values.Email);

        //    if (user == null) return BadRequest(error: new { message = "Invalid Credantials" });
        //    if (!BCrypt.Net.BCrypt.Verify(values.Password, user.Password))
        //    {
        //        return BadRequest(error: new { message = "invalid credantials" });

        //    };
        //    var jwt =_jwtService.Generate(user.Id);
        //    //HttpContext.Response.Cookies.Append(key: "jwt", value: jwt, new CookieOptions
        //    //{
        //    //    HttpOnly = true
        //    //});

        //    return Ok(jwt);
        //}
        //[HttpGet("User")]
        //public IActionResult User()
        //{
        //    try
        //    {
        //        var jwt = Request.Cookies["jwt"];
        //        var token = _jwtService.Verify(jwt);
        //        int userId = int.Parse(token.Issuer);
        //        var user = _rentaCarContext.Users.FirstOrDefault(e => e.Id == userId);
        //        return Ok(user);
        //    }
        //    catch (Exception _)
        //    {
        //        return Unauthorized();
        //    }

        //}
        //[HttpPost("Logout")]
        //public IActionResult Logout()
        //{
        //    Response.Cookies.Delete(key: "jwt");
        //    return Ok(new
        //    {
        //        message = "success"
        //    });

        //}
    }
}
