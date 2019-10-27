using Geardao.Deploy.Supervisor.Ef.Model;
using Microsoft.EntityFrameworkCore;

namespace Geardao.Deploy.Supervisor.Ef
{
    public class ApplicationDatabaseContext : DbContext
    {
        
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Execute> Executes { get; set; }
        
    }
}