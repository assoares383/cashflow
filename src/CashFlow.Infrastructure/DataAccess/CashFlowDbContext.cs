using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

internal class CashFlowDbContext : DbContext
{
    public DbSet<Expense>  Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=cashflow_db;Uid=cashflow_admin;Pwd=cashflow#root;";

        var version = new Version(8, 0, 27);
        var serverVersion = new MySqlServerVersion(version);
        
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}