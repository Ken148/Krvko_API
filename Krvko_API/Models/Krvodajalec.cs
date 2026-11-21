using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Krvodajalec")]
public class Krvodajalec
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

    [Required]
    [AllowedValues("A+", "A-", "B+", "B-", "AB+", "AB-", "0+", "0-")]
    [Column("krvna_skupina", TypeName = "enum('A+','A-','B+','B-','AB+','AB-','0+','0-')")]
    public string KrvnaSkupina { get; set; } = string.Empty;

    [Required, MaxLength(20)]
    [Column("telefon")]
    public string Telefon { get; set; } = string.Empty;

    [Column("TK_Uporabnik")]
    public int UporabnikId { get; set; }

    [ForeignKey(nameof(UporabnikId))]
    public Uporabnik Uporabnik { get; set; } = null!;

    public ICollection<Darovanje> Darovanja { get; set; } = new List<Darovanje>();
}