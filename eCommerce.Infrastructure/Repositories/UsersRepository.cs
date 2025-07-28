using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;
        public UsersRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
        {
            //Generate a new unique user ID for the user
            user.UserId = Guid.NewGuid();

            //Sql query to insert the user into the users table
            string sql = "INSERT INTO public.\"Users\" (\"UserId\", \"Email\", \"Password\", \"PersonName\",\"Gender\") " +
                         "VALUES (@UserId, @Email, @Password, @PersonName, @Gender)";
            int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(sql, user);
            
            return rowCountAffected > 0 ? user : null;
        }

        public async Task<ApplicationUser?> GetUserByEmailAnPasswordAsync(string? email, string? password)
        {
            var parameters = new { Email = email, Password = password };
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
            ApplicationUser user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

            return user;
        }
    }
}
