using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Admin")]
public class Admin
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    [Column("ime")]
    public string Ime { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    [Column("priimek")]
    public string Priimek { get; set; } = string.Empty;

    [Column("TK_Uporabnik")]
    public int UporabnikId { get; set; }

    [ForeignKey(nameof(UporabnikId))]
    public Uporabnik Uporabnik { get; set; } = null!;
}