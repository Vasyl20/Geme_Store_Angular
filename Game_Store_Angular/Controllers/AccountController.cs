using Game_Store_Angular.DDTO.DataAccess;
using Game_Store_Angular.DDTO.DataAccess.Entity;
using Game_Store_Angular.DDTO.Domian.Interfaces;
using Game_Store_Angular.DDTO.DTO;
using Game_Store_Angular.DDTO.DTO.Results;
using Game_Store_Angular.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Store_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTTokenService _IJWTokenService;

        public AccountController(
             EFContext context,
             UserManager<User> userManager,
             SignInManager<User> signInManager,
             IJWTTokenService JWTTokenService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _IJWTokenService = JWTTokenService;
        }

        [HttpPost("register")]
        public async Task<ResultDTO> Register([FromBody] UserRegisterDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResultErrorDTO
                    {
                        Code = 405,
                        Message = "ERROR",
                        Errors = new List<string>()
                        {
                            "Enter all fields!"
                        }
                    };
                }
                else
                {
                    var user = new User
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        PhoneNumber = model.Phone,
                        Address = model.Address,
                        Age = model.Age,
                        FullName = model.FullName
                    };
                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        result = _userManager.AddToRoleAsync(user, "User").Result;
                        _context.SaveChanges();

                        return new ResultDTO
                        {
                            Code = 200,
                            Message = "OK"
                        };
                    }
                    else
                    {
                        return new ResultErrorDTO
                        {
                            Code = 405,
                            Message = "ERROR",
                            Errors = CustomValidator.getErrorsByIdntityResult(result)
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return new ResultErrorDTO
                {
                    Code = 500,
                    Message = "ERROR",
                    Errors = new List<string>
                    {
                        e.Message
                    }
                };
            }
        }


        [HttpPost("login")]
        public async Task<ResultDTO> Login([FromBody] UserLoginDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResultErrorDTO
                    {
                        Code = 405,
                        Message = "ERROR",
                        Errors = new List<string>()
                        {
                            "Enter all fields!"
                        }
                    };
                }
                else
                {

                    var result = _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false).Result;

                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByEmailAsync(model.Email);
                        await _signInManager.SignInAsync(user, false);

                        return new ResultLoginDTO
                        {
                            Code = 200,
                            Message = "OK",
                            Token = _IJWTokenService.CreateToken(user)
                        };
                    }
                    else
                    {
                        return new ResultErrorDTO
                        {
                            Code = 405,
                            Message = "ERROR",
                            Errors = CustomValidator.getErrorsByModelState(ModelState)
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return new ResultErrorDTO
                {
                    Code = 500,
                    Message = "ERROR",
                    Errors = new List<string>
                    {
                        e.Message
                    }
                };
            }
        }

    }
}
