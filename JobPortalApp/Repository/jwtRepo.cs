using JobPortalApp.Model.db_models;
using JobPortalApp.ViewModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalApp.Repository
{
    public class jwtRepo
    {
        private jwt_vm jwtSetting;
        public jwtRepo(IOptionsSnapshot<jwt_vm> options)
        {
            jwtSetting = options.Value;
        }

        public string GenerateJWT(User user, IList<string> roles)
        {
            var claim = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var claimRoles = roles.Select(r => new Claim(ClaimTypes.Role, r));

            claim.AddRange(claimRoles);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(jwtSetting.ExpirationInDays));

            var token = new JwtSecurityToken(
                     issuer: jwtSetting.Issuer,
                     audience: jwtSetting.Issuer,
                     claims: claim,
                     expires: expires,
                     signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
