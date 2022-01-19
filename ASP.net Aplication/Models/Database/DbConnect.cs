using ASP.net_Aplication.Models.Comment;
using ASP.net_Aplication.Models.Identity;
using ASP.net_Aplication.Models.Image;
using ASP.net_Aplication.Models.Rate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Models.Database {
    public class DbConnect : IdentityDbContext<DBModelAccount> {
        public DbSet<DBModelImage> Images { get; set; }
        public DbSet<DBModelRate> Rates { get; set; }
        public DbSet<DBModelComment> Comments { get; set; }

        public DbConnect(DbContextOptions<DbConnect> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            DBModelImage.ModelCreate(builder);
            DBModelRate.ModelCreate(builder);
            DBModelComment.ModelCreate(builder);
        }
    }
}
