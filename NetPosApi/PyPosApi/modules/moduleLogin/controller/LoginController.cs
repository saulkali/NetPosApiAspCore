using Microsoft.AspNetCore.Mvc;
using PyPosApi.modules.moduleLogin.model;
using PyPosApi.common.entities;

namespace PyPosApi.modules.moduleLogin.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginRepository _loginRepository;

        public LoginController(LoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }


        [HttpPost("auth")]
        public async Task<ActionResult> Post([FromBody] LoginEntity loginEntity)
        {
            LoginResponseEntity response = await _loginRepository.Auth(loginEntity.Email,loginEntity.Password);           
            return Ok(response);
        }
    }
}