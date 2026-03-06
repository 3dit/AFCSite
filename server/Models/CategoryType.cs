using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFCSite.Server.Models;

[Table("CategoryType")]
public partial class CategoryType
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

    [InverseProperty("CategoryType")]
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
