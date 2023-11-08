using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API;
using ProEventos.API.Extensions;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
namespace ProEventos.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService,
                                 ITokenService tokenService){
            _accountService = accountService;
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(){
            try{
                var userName = User.GetUserName();
                var user = await _accountService.GetUserByUserNameAsync(userName);
                return Ok(user);

            }catch(Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar usuário. Erro: {ex.Message}");
            }
        }

          [HttpPost("Register}")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto userDto){
            try{
                
                if(await _accountService.UserExists(userDto.UserName))
                return BadRequest("Usuário já existe");
                var user = await _accountService.CreateAccountAsync(userDto);
                if(user!=null)
                return Ok(user);

                return BadRequest("Usuário não criado, tente novamente mais tarde!");

            }catch(Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar usuário. Erro: {ex.Message}");
            }
        }

        [HttpGet("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userlogin){
            try{
                var user = await _accountService.GetUserByUserNameAsync(userlogin.Username);
                if(user == null) return Unauthorized("Usuário ou senha está errado");

                var result = await _accountService.CheckUserPasswordAsync(user, userlogin.Password);
                if(!result.Succeeded) return Unauthorized("Usário não inválido");
                return Ok(
                    new{
                        userName = userlogin.Username,
                        PrimeiroNome = user.PrimeiroNome,
                        token = _tokenService.CreateToken(user).Result
                    }
                );

            }catch(Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar realizar login. Erro: {ex.Message}");
            }
        }

         [HttpPost("UpdateUser}")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto){
            try{

                var user = await _accountService.GetUserByUserNameAsync(User.GetUserName());
                if (user==null) return Unauthorized("Usuário inválido");

                var userReturn = await _accountService.UpdateAccount(userUpdateDto);
                if(userReturn ==null)
                return NoContent();
               
                return Ok(userReturn);

    

            }catch(Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o  usuário. Erro: {ex.Message}");
            }
        }
        
    }
}