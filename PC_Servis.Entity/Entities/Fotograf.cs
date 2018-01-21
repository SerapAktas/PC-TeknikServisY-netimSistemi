using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Servis.Entity.Entities
{
    [Table("Fotograflar")]
    public class Fotograf
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string DosyaYol { get; set; }
        public int ArizaID { get; set; }

        [ForeignKey("ArizaID")]
        public virtual Ariza Ariza { get; set; }
    }
}
