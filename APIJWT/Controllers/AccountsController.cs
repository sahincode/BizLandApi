using APIJWT.Business.DTOs.UserDTOs;
using APIJWT.Business.Exceptions.EntityExceptions;
using APIJWT.Business.Exceptions.OperationExceptions;
using APIJWT.Business.Services.Interfaces;
using APIJWT.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AccountsController(IAccountService accountService ,
            RoleManager<IdentityRole> roleManager ,UserManager<User> userManager)
        {
            _accountService = accountService;
            this._roleManager = roleManager;
            this._userManager = userManager;
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromForm] UserRegisterDto registerDto)
        {
            try
            {
                await _accountService.RegisterAsync(registerDto);
            }
            catch (EntityExistException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidRegisterException ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok("User is registered");
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromForm] UserLoginDto loginDto)
        {
            string token = String.Empty;
            try
            {
                token = await _accountService.LoginAsync(loginDto);
            }
            catch (InvalidCredentialsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidLoginException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(token);
        }

       

        //[HttpGet("[action]")]
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    User admin = new User
        //    {
        //        FullName = "Shahin Ismayil",
        //        UserName = "Sako"
        //    };

        //    var result = await _userManager.CreateAsync(admin, "Sahin6134@");
        //    var addedRole = await _userManager.AddToRoleAsync(admin, "SuperAdmin");

        //    return Ok();
        //}

        //[HttpGet("[action]")]
        //public async Task<IActionResult> CreateRole()
        //{
        //    var role1 = new IdentityRole("SuperAdmin");
        //    var role2 = new IdentityRole("Admin");
        //    var role3 = new IdentityRole("User");

        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    await _roleManager.CreateAsync(role3);

        //    return Ok("Created");
        //}
        
    }
}
