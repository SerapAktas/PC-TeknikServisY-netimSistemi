using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Servis.Entity.Entities
{
    [Table("ArizaRaporlar")]
    public class ArizaRapor
    {
        [Key]
        public string ID { get; set; }
        public string ArizaDurumID { get; set; }
        [Required]
        [StringLength(250)]
        public string Rapor { get; set; }

        [ForeignKey("ArizaDurumID")]
        public virtual ArizaDurum ArizaDurum { get; set; }
    }
}
