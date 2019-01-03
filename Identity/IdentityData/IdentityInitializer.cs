using Identity.Models;
using Identity.AuthenticateUtils;
using Microsoft.AspNetCore.Identity;
using System;

namespace Identity.Data
{
    public class IdentityInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityInitializer(ApplicationDbContext context,
                                   UserManager<ApplicationUser> userManager,
                                   RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_context.Database.EnsureCreated())
            {
                
                CreateRoles(Roles.ROLE_ACESSO, 
                            Roles.ROLE_FUNCIONARIO, 
                            Roles.ROLE_SUPERVISOR);

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "supervisor",
                        Email = "supervisor@braspag.com.br",
                        EmailConfirmed = true
                    }, "VouTrabalharNaBrasp@g2019", Roles.ROLE_SUPERVISOR);

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "funcionario",
                        Email = "funcionario@braspag.com.br",
                        EmailConfirmed = true
                    }, "VouTrabalharNaBrasp@g2019", Roles.ROLE_FUNCIONARIO);

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "estagiario",
                        Email = "estagiario@braspag.com.br",
                        EmailConfirmed = true
                    }, "VouTrabalharNaBrasp@g2019", Roles.ROLE_ACESSO);

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "UsuarioSemAcesso",
                        Email = "usuariosemacesso@braspag.com.br",
                        EmailConfirmed = true
                    }, "VouTrabalharNaBrasp@g2019");
            }        
        }

        private void CreateUser(ApplicationUser user, string password, string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = _userManager.CreateAsync(user, password).Result;

                if (resultado.Succeeded && !string.IsNullOrWhiteSpace(initialRole))
                    _userManager.AddToRoleAsync(user, initialRole).Wait();

            }
        }

        private void CreateRoles(params string[] roles)
        {
            foreach (var role in roles)
            {
                if (!_roleManager.RoleExistsAsync(role).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(role)).Result;

                    if (!resultado.Succeeded)
                        throw new Exception($"Erro durante a criação da role {role}.");
                }
            }
        }
    }
}
