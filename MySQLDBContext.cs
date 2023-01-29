using System.Diagnostics.CodeAnalysis;
using Example.Models;
using Microsoft.EntityFrameworkCore;

namespace Example;
public class MySQLDBContext : DbContext
{
    [AllowNull]
    public DbSet<User> User { get; set; }
    [AllowNull]
    public DbSet<Pizza> Pizza { get; set; }
    public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options) { }
}