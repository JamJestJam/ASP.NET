using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacja.Models
{
    public interface IDB
    {
        IQueryable<User> Users { get; }
    }

    public class Ef : IDB
    {
        private DB context;

        public Ef(DB context)
        {
            this.context = context;
        }

        public IQueryable<User> Users { get => context.Users; }
    }

    public class DB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }

        public DB(DbContextOptions<DB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            User.ModelCreate(builder);
            Comment.ModelCreate(builder);
            Image.ModelCreate(builder);
        }
    }
}
