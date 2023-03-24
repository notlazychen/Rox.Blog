using BlazorBlog.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog
{
    public class BlogDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=data.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>(t =>
            {
                t.HasIndex(x => x.PublishAt);
                t.HasOne(x => x.Author).WithMany().HasForeignKey(x=>x.AuthorId);
                t.HasOne(x => x.Category).WithMany(y=>y.Posts).HasForeignKey(x => x.CategoryId);
                t.HasMany(x => x.Tags).WithMany(y => y.Posts);
            });
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categorys { get; set; }
    }
}
