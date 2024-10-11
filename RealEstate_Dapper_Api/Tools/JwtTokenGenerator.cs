using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenGenerator
    {
        // Sınıf üzerinden newlemeden erişim sağlamak için static tanımlıyoruz.
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(model.Role))
                claims.Add(new Claim(ClaimTypes.Role, model.Role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()));

            if (!string.IsNullOrWhiteSpace(model.Username))
                claims.Add(new Claim("Username", model.Username));

            //Token oluşturma
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key));

            // key ile claimsden önce kullanılır. HMACSHA256 bir algoritmadır
            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Tokenin ayakta kalma süresi
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefault.Expire);
            //token parametresi
            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefault.ValidIssuer,
                                                          audience: JwtTokenDefault.ValidAudience,
                                                          claims: claims, notBefore: DateTime.UtcNow,
                                                          expires: expireDate,
                                                          signingCredentials: signinCredentials);


            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
        }
    }
}
