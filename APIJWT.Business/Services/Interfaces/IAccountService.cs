using APIJWT.Business.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJWT.Business.Services.Interfaces
{
    public interface IAccountService
    {
        public Task RegisterAsync(UserRegisterDto userRegisterDto);
        public Task<string> LoginAsync(UserLoginDto userLoginDto);
    }
}
