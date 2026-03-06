using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFCSite.Server.Models;

[Table("RawPost")]
public partial class RawPost
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Updated { get; set; }

    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PublishDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PostDate { get; set; }

    public bool Publish { get; set; }

    [ForeignKey("RawPostId")]
    [InverseProperty("RawPosts")]
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    [ForeignKey("RawPostId")]
    [InverseProperty("RawPosts")]
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
