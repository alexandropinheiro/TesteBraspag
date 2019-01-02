using Api.AuthenticateUtils;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {        
        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody]User usuario,
            [FromServices]UserManager<ApplicationUser> userManager,
            [FromServices]SignInManager<ApplicationUser> signInManager,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            bool credenciaisValidas = false;
            List<Claim> listaClaims = new List<Claim>();

            if (usuario != null && !string.IsNullOrWhiteSpace(usuario.UserID))
            {
                // Verifica a existência do usuário nas tabelas do
                // ASP.NET Core Identity
                var userIdentity = userManager
                    .FindByNameAsync(usuario.UserID).Result;
                if (userIdentity != null)
                {
                    // Efetua o login com base no Id do usuário e sua senha
                    var resultadoLogin = signInManager
                        .CheckPasswordSignInAsync(userIdentity, usuario.Password, false)
                        .Result;
                    if (resultadoLogin.Succeeded)
                    {
                        listaClaims = ObterListaDeClaims(userManager, userIdentity);

                        credenciaisValidas = listaClaims.Any();
                    }
                }

                if (credenciaisValidas)
                {
                    //var claims = new[] {
                    //    new Claim(JwtRegisteredClaimNames.UniqueName, userIdentity.Email),
                    //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //    new Claim(ClaimTypes.Role, Roles.ROLE_ACESSO)
                    //};

                    listaClaims.Add(
                        new Claim(JwtRegisteredClaimNames.UniqueName, userIdentity.Email));

                    listaClaims.Add(
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        );

                    var key =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("35725c901c45f1c13f9e3fe8421a15dd2613"));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    DateTime dataCriacao = DateTime.Now;
                    DateTime dataExpiracao = dataCriacao +
                        TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                    var token = new JwtSecurityToken(
                        issuer: tokenConfigurations.Issuer,
                        audience: tokenConfigurations.Audience,
                        claims: listaClaims,
                        expires: dataExpiracao,
                        signingCredentials: creds
                    );

                    return new
                    {
                        authenticated = true,
                        created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                        expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                        accessToken = new JwtSecurityTokenHandler().WriteToken(token),
                        message = "OK"
                    };
                }
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }

            return null;
        }

        private List<Claim> ObterListaDeClaims(UserManager<ApplicationUser> userManager,
                                               ApplicationUser applicationUser)
        {
            var listaClaims = new List<Claim>();

            if (userManager.IsInRoleAsync(applicationUser, Roles.ROLE_SUPERVISOR).Result)
                listaClaims.Add(new Claim(ClaimTypes.Role, Roles.ROLE_SUPERVISOR));

            if (userManager.IsInRoleAsync(applicationUser, Roles.ROLE_FUNCIONARIO).Result)
                listaClaims.Add(new Claim(ClaimTypes.Role, Roles.ROLE_FUNCIONARIO));

            if (userManager.IsInRoleAsync(applicationUser, Roles.ROLE_ACESSO).Result)
                listaClaims.Add(new Claim(ClaimTypes.Role, Roles.ROLE_ACESSO));

            return listaClaims;
        }
    }
}
