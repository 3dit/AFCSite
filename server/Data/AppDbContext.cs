using AFCSite.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AFCSite.Server.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<BaseIngredient> BaseIngredients { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryType> CategoryTypes { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<RawPost> RawPosts { get; set; }
    public DbSet<StyleSheet> StyleSheets { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BaseIngredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.BaseIngredient");
            entity.HasOne(d => d.Family).WithMany(p => p.BaseIngredients)
                .HasConstraintName("FK_dbo.BaseIngredient_dbo.Family_Family_Id");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Category");
            entity.HasOne(d => d.CategoryType).WithMany(p => p.Categories)
                .HasConstraintName("FK_dbo.Category_dbo.CategoryType_CategoryType_Id");
        });

        modelBuilder.Entity<CategoryType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.CategoryType");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK_dbo.Contacts");
        });

        modelBuilder.Entity<Family>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Family");
        });

        modelBuilder.Entity<RawPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.RawPost");

            entity.HasMany(d => d.Categories).WithMany(p => p.RawPosts)
                .UsingEntity<Dictionary<string, object>>(
                    "RawPostCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_dbo.RawPostCategory_dbo.Category_Category_Id"),
                    l => l.HasOne<RawPost>().WithMany()
                        .HasForeignKey("RawPostId")
                        .HasConstraintName("FK_dbo.RawPostCategory_dbo.RawPost_RawPost_Id"),
                    j =>
                    {
                        j.HasKey("RawPostId", "CategoryId").HasName("PK_dbo.RawPostCategory");
                        j.ToTable("RawPostCategory");
                        j.HasIndex(new[] { "CategoryId" }, "IX_Category_Id");
                        j.HasIndex(new[] { "RawPostId" }, "IX_RawPost_Id");
                        j.IndexerProperty<int>("RawPostId").HasColumnName("RawPost_Id");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("Category_Id");
                    });
        });

        modelBuilder.Entity<StyleSheet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.StyleSheet");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Tag");

            entity.HasMany(d => d.RawPosts).WithMany(p => p.Tags)
                .UsingEntity<Dictionary<string, object>>(
                    "TagRawPost",
                    r => r.HasOne<RawPost>().WithMany()
                        .HasForeignKey("RawPostId")
                        .HasConstraintName("FK_dbo.TagRawPost_dbo.RawPost_RawPost_Id"),
                    l => l.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_dbo.TagRawPost_dbo.Tag_Tag_Id"),
                    j =>
                    {
                        j.HasKey("TagId", "RawPostId").HasName("PK_dbo.TagRawPost");
                        j.ToTable("TagRawPost");
                        j.HasIndex(new[] { "RawPostId" }, "IX_RawPost_Id");
                        j.HasIndex(new[] { "TagId" }, "IX_Tag_Id");
                        j.IndexerProperty<int>("TagId").HasColumnName("Tag_Id");
                        j.IndexerProperty<int>("RawPostId").HasColumnName("RawPost_Id");
                    });
        });
    }
}
