using PyPosApi.modules.moduleLogin.enums;

namespace PyPosApi.common.entities
{
	public class LoginResponseEntity
	{
        public string Token { get; set; }
        public LoginResponses Response { get; set; }
    }
}

