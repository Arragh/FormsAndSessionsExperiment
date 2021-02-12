using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAndSessionsExperiment.Models.ContextModels
{
    public class TestDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) => Database.EnsureCreated();
    }
}
