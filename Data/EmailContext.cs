using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemboComingSoon.Models;

namespace RemboComingSoon.Data
{
    public class EmailContext : DbContext
    {
        public EmailContext (DbContextOptions<EmailContext> options)
            : base(options)
        {
        }

        public DbSet<RemboComingSoon.Models.Email> Email { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>().ToTable("Email");
        }
    }
}
