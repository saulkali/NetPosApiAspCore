using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PyPosApi.common.entities;
using PyPosApi.modules.moduleRegisterEmploye.enums;
using PyPosApi.modules.moduleRegisterEmploye.model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PyPosApi.modules.moduleRegisterEmploye.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterEmployeController : ControllerBase
    {
        private readonly RegisterEmployeRepository _registerEmployeRepository;
        public RegisterEmployeController(RegisterEmployeRepository registerEmployeRepository)
        {
            _registerEmployeRepository = registerEmployeRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserEntity userEntity)
        {
            RegisterResponses response = await _registerEmployeRepository.Register(userEntity);
            return Ok(response);
        }

    }
}
