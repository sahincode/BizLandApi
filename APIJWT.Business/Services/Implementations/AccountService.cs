using APIJWT.Business.DTOs.UserDTOs;
using APIJWT.Business.Exceptions.EntityExceptions;
using APIJWT.Business.Exceptions.OperationExceptions;
using APIJWT.Business.Services.Interfaces;
using APIJWT.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Services.Implementations
{
    public  class AccountService :IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountService( UserManager<User> userManager ,
            RoleManager<IdentityRole> roleManager,SignInManager<User> signInManager ,
            IConfiguration configuration)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
        }
        public async Task RegisterAsync(UserRegisterDto userRegisterDto)
        {
            User user = null;
            user = await _userManager.FindByNameAsync(userRegisterDto.Username);
            if (user != null)
            {
                throw new EntityExistException("User alreay exist!");
            }
            user = await _userManager.FindByEmailAsync(userRegisterDto.Email);
            if (user != null)
            {
                throw new EntityExistException("User alreay exist!");
            }
            user = new User()
            {
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                FullName=userRegisterDto.FullName

            };
            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            if (!result.Succeeded)
            {
                throw new InvalidRegisterException(result.Errors.First().Description);
            }
           var resultRole= await _userManager.AddToRoleAsync(user, "User");
            if (!resultRole.Succeeded)
            {
                throw new InvalidRegisterException(result.Errors.First().Description);
            }
        }
        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            User user = null;
            user =  await _userManager.FindByEmailAsync(userLoginDto.EmailOrUsername);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(userLoginDto.EmailOrUsername);
                if (user == null) throw new InvalidCredentialsException("Invalid credentials!");
            }
            var result =  await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, true, false);
            if (!result.Succeeded)
            {
                throw new InvalidLoginException("Invalid login attempt! \n If you did not register please register!");

            }
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub ,user.Id),
                new Claim("FullName" ,user.FullName),
                new Claim(ClaimTypes.Name,user.UserName)

            };
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            var symmetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value));
            var signInCreds = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                audience: _configuration.GetSection("JWT:Audience").Value,
               issuer: _configuration.GetSection("JWT:Issuer").Value,
               claims: claims,
               notBefore: DateTime.UtcNow,
               expires: DateTime.UtcNow.AddHours(2),
               signingCredentials: signInCreds
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return token;

            
        }
    }
}
