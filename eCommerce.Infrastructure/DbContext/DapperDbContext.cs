using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.DbContext;


internal class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        string? connectionString = _configuration.GetConnectionString("PostgresConnection");

        //Create a new connection with the retrived connection string
        _connection = new Npgsql.NpgsqlConnection(connectionString ?? throw new ArgumentNullException(nameof(connectionString)));
    }

    //we create a property
    public IDbConnection DbConnection => _connection;
}
