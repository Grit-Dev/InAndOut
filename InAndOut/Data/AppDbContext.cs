using InAndOut.Models;
using Microsoft.EntityFrameworkCore;

namespace InAndOut.Data
{
    public class AppDbContext : DbContext 
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //This is set up to help create, edit and update the database

        }

        //Table to be created using the model/Class
        public DbSet<Item> Items { get; set; }

        //Table to be created using the model/Class
        public DbSet<Expense> Expenses { get; set; }

        
    }
}
