using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.Account;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var appUser = new AppUser{
                    UserName = registerDTO.UserName,
                    Email = registerDTO.Email,
                };

                var createUser = await _userManager.CreateAsync(appUser, registerDTO.Password!);

                if(createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if(roleResult.Succeeded)
                    {
                        return Ok("User created");
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createUser.Errors);
                }
            }
            catch (Exception ex)
            { 
                return StatusCode(500, ex);
            }
        }
    }
}