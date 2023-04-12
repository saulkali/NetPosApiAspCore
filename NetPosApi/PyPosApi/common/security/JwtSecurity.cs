using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PyPosApi.common.security
{
	public class JwtSecurity
	{
		private readonly string _secretKey;

		public JwtSecurity(string secretKey)
		{
			_secretKey = secretKey;
		}

		/// <summary>
		/// genera el token de autenticacion
		/// </summary>
		/// <param name="email"></param>
		/// <param name="idUser"></param>
		/// <returns></returns>
		public string GenerateToken(string email,Guid idUser)
		{
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			byte[] key = Encoding.ASCII.GetBytes(_secretKey);
			SecurityTokenDescriptor tokenDescription = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] {
					new Claim(ClaimTypes.Email, email),
					new Claim(ClaimTypes.NameIdentifier, idUser.ToString())
				}),
				Expires = DateTime.UtcNow.AddHours(6),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256Signature
					)
			};
			SecurityToken token = tokenHandler.CreateToken(tokenDescription);
			return tokenHandler.WriteToken(token);
		}

		/// <summary>
		/// valida los token 
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public ClaimsPrincipal ValidateToken(string token)
		{
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			byte[] key = Encoding.ASCII.GetBytes(_secretKey);
			TokenValidationParameters validationParameters = new TokenValidationParameters {
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = false,
				ValidateAudience = false,
				ClockSkew = TimeSpan.Zero
			};
			try
			{
				var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
				return principal;
			}
			catch
			{
				return null;
			}
		}
	}
}

