using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Darovanje")]
public class Darovanje
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("TK_Krvodajalec")]
    public int KrvodajalecId { get; set; }

    [Column("TK_Termin")]
    public int TerminId { get; set; }

    [Required]
    [AllowedValues("rezervirano", "opravljeno", "preklicano")]
    [Column("status", TypeName = "enum('rezervirano','opravljeno','preklicano')")]
    public string Status { get; set; } = StatusiDarovanja.Rezervirano;

    [Column("potrdilo_izdano_ob")]
    public DateTime PotrdiloIzdanoOb { get; set; }

    [Column("potrdil_zdravnik")]
    public int? PotrdilZdravnikId { get; set; }

    [ForeignKey(nameof(KrvodajalecId))]
    public Krvodajalec Krvodajalec { get; set; } = null!;

    [ForeignKey(nameof(TerminId))]
    public Termin Termin { get; set; } = null!;

    [ForeignKey(nameof(PotrdilZdravnikId))]
    public Zdravnik? PotrdilZdravnik { get; set; }
}