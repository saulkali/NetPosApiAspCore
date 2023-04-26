using Microsoft.EntityFrameworkCore;
using PyPosApi.common.security;
using PyPosApi.common.database.context;
using PyPosApi.common.database.schemes;
using PyPosApi.common.entities;
using PyPosApi.modules.moduleLogin.enums;
using PyPosApi.common.database.functions;

namespace PyPosApi.modules.moduleLogin.model
{
    public class LoginRepository
    {
        private readonly DUser _dUser;
        private readonly JwtSecurity _jwtSecurity;

        public LoginRepository(DUser dUser,JwtSecurity jwtSecurity)
        {
            _dUser = dUser;
            _jwtSecurity = jwtSecurity;
        }

        /// <summary>
        /// valida la autenticacion del usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<LoginResponseEntity> Auth(string email, string password) =>
            await _dUser.Auth(email,password);
        
    }
}
