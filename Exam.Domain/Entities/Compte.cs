using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Compte
    {
        [Key]
        [Range(0, int.MaxValue)]
        public int RIB { get; set; }
        [Required]
        public DateTime DateOuverture { get; set; }
        [Range(0, float.MaxValue)]
        public float Solde { get; set; }

        //foreign Keys
        public  string CIN { get; set; }
        public int AgenceKey { get; set; }

        //navigation properties
        public virtual Agence Agence { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<Credit> Credits { get; set; }
    }
}
