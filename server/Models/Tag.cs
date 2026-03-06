using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFCSite.Server.Models;

[Table("Tag")]
public partial class Tag
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [ForeignKey("TagId")]
    [InverseProperty("Tags")]
    public virtual ICollection<RawPost> RawPosts { get; set; } = new List<RawPost>();
}
