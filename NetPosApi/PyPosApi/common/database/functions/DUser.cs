using System;
using Microsoft.EntityFrameworkCore;
using PyPosApi.common.database.context;
using PyPosApi.common.database.schemes;
using PyPosApi.common.entities;
using PyPosApi.common.security;
using PyPosApi.modules.moduleLogin.enums;

namespace PyPosApi.common.database.functions
{
	public class DUser
	{
		private readonly DatabaseContext _databaseContext;

		public DUser(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		/// <summary>
		/// delete user by Id
		/// </summary>
		/// <param name="idUser"></param>
		/// <returns></returns>
		public async Task<bool> Delete(Guid idUser)
		{
			bool isDeleted = false;
			try
			{
				UserScheme? user = _databaseContext.UserSchemes.Where(usr=> usr.Id == idUser).FirstOrDefault();
				if (user == null)
					throw new Exception("user not exists");
				_databaseContext.UserSchemes.Remove(user);
				await _databaseContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				
			}
			return isDeleted;
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
                else
                {
                    response.Response = LoginResponses.SUCCESS;
                    response.Token = _jwtSecurity.GenerateToken(email, user.Id);
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        /// <summary>
        /// create new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> Create(UserScheme user)
		{

			bool isCreated = false;
			try
			{
				if (user == null)
					throw new ArgumentNullException($"null {nameof(user)}");

				bool existIdUser = _databaseContext.UserSchemes.Any(usr => usr.Id == user.Id);
				if (existIdUser)
					throw new Exception("user id exists");

				bool existEmailUser = _databaseContext.UserSchemes.Any(usr=> usr.Email == user.Email);
				if (existEmailUser)
					throw new Exception("user email exists");

				bool existRFCUser = _databaseContext.UserSchemes.Any(usr => usr.RFC == user.RFC);
				if (existRFCUser)
					throw new Exception("user RFC exists");

				await _databaseContext.UserSchemes.AddAsync(user);
				await _databaseContext.SaveChangesAsync();
			}
			catch(Exception ex)
			{

			}
			return isCreated;
		}
	}
}

