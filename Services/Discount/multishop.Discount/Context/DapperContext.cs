using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using multishop.Discount.Entities;

namespace multishop.Discount.Context;

public class DapperContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=MUHAMMEDYUCEDAG\\SQLEXPRESS;initial catalog=MultiShopDiscountDb;integrated security=true");
    }
    
    public DbSet<Coupon> Coupons { get; set; }
    public IDbConnection CreateDbConnection() => new SqlConnection(_connectionString);
}