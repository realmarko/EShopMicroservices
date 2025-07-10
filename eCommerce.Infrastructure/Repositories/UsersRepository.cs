﻿using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();
            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailAnPasswordAsync(string? email, string? password)
        {
            return new ApplicationUser() { 
                UserId = Guid.NewGuid(),
                Email = email, 
                Password = password,
                PersonName = "Person name",
                Gender = GenderOptions.Male.ToString()
            };
        }
    }
}
