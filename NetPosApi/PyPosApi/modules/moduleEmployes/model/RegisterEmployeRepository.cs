using Microsoft.EntityFrameworkCore;
using PyPosApi.common.database.context;
using PyPosApi.common.database.schemes;
using PyPosApi.common.entities;
using PyPosApi.common.security;
using PyPosApi.modules.moduleRegisterEmploye.enums;

namespace PyPosApi.modules.moduleRegisterEmploye.model
{
    public class RegisterEmployeRepository
    {

        private readonly DatabaseContext _databaseContext;

        public RegisterEmployeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<RegisterResponses> Register(UserEntity userEntity)
        {
            RegisterResponses response = RegisterResponses.UNKNOW;
            try
            {
                UserScheme? userScheme = await _databaseContext.UserSchemes.Where(us => us.Email == userEntity.Email).FirstOrDefaultAsync();
                if (userScheme != null)
                    response = RegisterResponses.USEREXISTS;
                else
                {
                    UserScheme newUserScheme = new UserScheme()
                    {
                        Id = Guid.NewGuid(),
                        Email = userEntity.Email,
                        FirstName = userEntity.FirstName,
                        LastName = userEntity.LastName,
                        Password = Crypto.HashPassword(userEntity.Password),
                        Phone = userEntity.Phone
                    };
                    _databaseContext.UserSchemes.Add(newUserScheme);
                    await _databaseContext.SaveChangesAsync();
                }

            }
            catch (Exception ex) { 
            
            }
            return response;
        }

    }
}
