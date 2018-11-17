using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Credit
    {
        [Key]
        [Range(0, int.MaxValue)]
        public int CreditKey { get; set; }
        [Range(0, float.MaxValue)]
        public float SommeCredit { get; set; }
        [Required]
        public DateTime DateCredit { get; set; }
        [Range(0, float.MaxValue)]
        public float TauxInteret { get; set; }

        public Type TypeCredit { get; set; }

        public virtual List<Compte> Comptes { get; set; }

    }
}
