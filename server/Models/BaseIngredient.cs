using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AFCSite.Server.Models;

[Table("BaseIngredient")]
[Index("FamilyId", Name = "IX_Family_Id")]
public partial class BaseIngredient
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreateDateTime { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(100)]
    public string? LongName { get; set; }

    [Column("Family_Id")]
    public int? FamilyId { get; set; }

    [ForeignKey("FamilyId")]
    [InverseProperty("BaseIngredients")]
    public virtual Family? Family { get; set; }
}
