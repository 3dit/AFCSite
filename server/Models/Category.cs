using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AFCSite.Server.Models;

[Table("Category")]
[Index("CategoryTypeId", Name = "IX_CategoryType_Id")]
public partial class Category
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Markup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Updated { get; set; }

    [Column("CategoryType_Id")]
    public int? CategoryTypeId { get; set; }

    [ForeignKey("CategoryTypeId")]
    [InverseProperty("Categories")]
    public virtual CategoryType? CategoryType { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Categories")]
    public virtual ICollection<RawPost> RawPosts { get; set; } = new List<RawPost>();
}
