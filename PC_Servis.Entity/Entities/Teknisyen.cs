using PC_Servis.Entity.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Servis.Entity.Entities
{
    [Table("Teknisyenler")]

        public class Teknisyen
    {
        [Key]
        public string ID { get; set; }
        public string UserID { get; set; }
        [Required]
        public bool BostaMi { get; set; }=false;

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
        public virtual List<ArizaDurum> ArizaDurumlar { get; set; } = new List<ArizaDurum>();

    }
}
