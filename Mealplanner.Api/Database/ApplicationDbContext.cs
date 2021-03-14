using Microsoft.EntityFrameworkCore;

namespace Mealplanner.Api.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
   }
}