using Example.Models;
using Microsoft.EntityFrameworkCore;

namespace Example;
public class MySQLDBContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Pizza> Pizza { get; set; }
    public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options) { }
}