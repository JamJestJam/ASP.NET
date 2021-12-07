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
        IQueryable<Comment> Comments { get; }
        IQueryable<Image> Images { get; }
        IQueryable<Rate> Rates { get; }
    }

    public class Ef : IDB
    {
        private DB context;

        public Ef(DB context)
        {
            this.context = context;
        }

        public IQueryable<User> Users { get => context.Users; }
        public IQueryable<Comment> Comments { get => context.Comments; }
        public IQueryable<Image> Images { get => context.Images; }
        public IQueryable<Rate> Rates { get => context.Rates; }
    }

    public class DB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Rate> Rates { get; set; }

        public DB(DbContextOptions<DB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            User.ModelCreate(builder);
            Comment.ModelCreate(builder);
            Image.ModelCreate(builder);
            Rate.ModelCreate(builder);
        }
    }
}
