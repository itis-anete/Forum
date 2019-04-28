using ForumProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumProject.Infrastructure.Database
{
    public class ForumDbContext : DbContext
    {
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            : base(options)
        {
        }
    }
}


