using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EventProjectWeb.Model.Auth
{
    public class EventTokenHandler
    {
        public static JWTToken CreateToken(string email)
        {
            var responseModel = new JWTToken();
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,email),
            };
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("EventApiAuthKeyPasswordsasdafaafafadaf"));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            responseModel.AccessTokenExpiration = System.DateTime.Now.AddMinutes(30);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: "ercanmuzir@gmail.com",
                audience:"ercanmuzir@gmail.com",
                expires: responseModel.AccessTokenExpiration,
                signingCredentials:credentials,
                claims:claims

                );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            responseModel.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);

            return responseModel;
        }
    }
}
