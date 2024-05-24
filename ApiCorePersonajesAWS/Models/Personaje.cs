using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCorePersonajesAWS.Models
{
    [Table("PERSONAJES")]
    public class Personaje
    {
        [Key]
        [Column("IDPERSONAJE")]
        public int IdPersonaje { get; set; }
        [Column("PERSONAJE")]
        public string Nombre { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
    }
}
