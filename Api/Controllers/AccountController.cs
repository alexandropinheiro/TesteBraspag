using Api.AuthenticateUtils;
using Api.Models;
using log4net.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public AccountController(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

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
                var userIdentity = userManager
                    .FindByNameAsync(usuario.UserID).Result;
                if (userIdentity != null)
                {
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
                    var key =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
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

            if (listaClaims.Count > 0)
            {
                listaClaims.Add(
                        new Claim(JwtRegisteredClaimNames.UniqueName, applicationUser.Email));

                listaClaims.Add(
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    );
            }

            return listaClaims;
        }
    }
}
