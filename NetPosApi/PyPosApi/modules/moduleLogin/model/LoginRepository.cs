using Microsoft.EntityFrameworkCore;
using PyPosApi.common.security;
using PyPosApi.common.database.context;
using PyPosApi.common.database.schemes;
using PyPosApi.common.entities;
using PyPosApi.modules.moduleLogin.enums;

namespace PyPosApi.modules.moduleLogin.model
{
    public class LoginRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly JwtSecurity _jwtSecurity;

        public LoginRepository(DatabaseContext databaseContext,JwtSecurity jwtSecurity)
        {
            _databaseContext = databaseContext;
            _jwtSecurity = jwtSecurity;
        }

        /// <summary>
        /// valida la autenticacion del usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<LoginResponseEntity> Auth(string email, string password)
        {
            LoginResponseEntity response = new()
            {
                Response = LoginResponses.UNKNOW,
                Token = string.Empty
            };
            try
            {
                UserScheme? user = await _databaseContext.UserSchemes.Where(us => us.Email == email).FirstOrDefaultAsync();
                if (user == null)
                    response.Response = LoginResponses.USERNOTEXISTS;
                else if (!Crypto.VerifyPasswordHash(password, user.Password))
                    response.Response = LoginResponses.CREDENTIALNOTVALID;
                else {
                    response.Response = LoginResponses.SUCCESS;
                    response.Token = _jwtSecurity.GenerateToken(email,user.Id);
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
