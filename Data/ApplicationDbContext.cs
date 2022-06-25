using Microsoft.EntityFrameworkCore;
using project.Models;
namespace project.Data
{
  public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
  base(options)
  {




  }
 
 public DbSet<Item> Items { get; set; }
}

}