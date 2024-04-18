using Microsoft.EntityFrameworkCore;

namespace VideoGamesApp.Data
{
    public class ApplicationDbContext : DbContext // the class inherited everything from package
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
    }
}
