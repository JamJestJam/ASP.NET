using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using ASP.net_Aplication.Models.Rate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP.net_Aplication.Models.Database {
    public class DbConnect : IdentityDbContext<DBModelAccount> {
        public DbSet<DBModelImage> Images { get; set; }
        public DbSet<DBModelRate> Rates { get; set; }
        public DbSet<DBModelComment> Comments { get; set; }

        public DbConnect(DbContextOptions<DbConnect> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            DBModelRate.ModelCreate(builder);
            DBModelImage.ModelCreate(builder);
            DBModelComment.ModelCreate(builder);
            DBModelAccount.ModelCreate(builder);
        }
    }
}
