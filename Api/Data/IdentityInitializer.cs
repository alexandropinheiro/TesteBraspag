﻿using Api.Models;
using Api.AuthenticateUtils;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
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
                if (!_roleManager.RoleExistsAsync(Roles.ROLE_ACESSO).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(Roles.ROLE_ACESSO)).Result;

                    if (!resultado.Succeeded)
                        throw new Exception($"Erro durante a criação da role {Roles.ROLE_ACESSO}.");
                }

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "usuario1",
                        Email = "usuario1@braspag.com.br",
                        EmailConfirmed = true
                    }, "VouTrabalharNaBrasp@g2019", Roles.ROLE_ACESSO);

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "usuario2",
                        Email = "usuario2@braspag.com.br",
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
    }
}
