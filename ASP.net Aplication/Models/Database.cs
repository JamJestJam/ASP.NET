using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ASP.net_Aplication.Models {

    public interface IRep {
        IQueryable<ModelImage> Images { get; }
        IQueryable<ModelRate> Rates { get; }
        IQueryable<ModelComment> Comments { get; }
    }

    public class Rep : IRep {
        private readonly DB context;

        public IQueryable<ModelImage> Images => context.Images;
        public IQueryable<ModelRate> Rates => context.Rates;
        public IQueryable<ModelComment> Comments => context.Comments;

        public Rep(DB context) {
            this.context = context;
        }
    }

    public class DB : IdentityDbContext<ModelAccount> {
        public DbSet<ModelImage> Images { get; set; }
        public DbSet<ModelRate> Rates { get; set; }
        public DbSet<ModelComment> Comments { get; set; }

        public DB(DbContextOptions<DB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            ModelImage.ModelCreate(builder);
            ModelRate.ModelCreate(builder);
            ModelComment.ModelCreate(builder);
        }
    }
}
