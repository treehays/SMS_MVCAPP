using Microsoft.EntityFrameworkCore;
using SMS_MVCAPP.Models.Entities;

namespace SMS_MVCAPP.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<User>users { get; set; }
    }
}
