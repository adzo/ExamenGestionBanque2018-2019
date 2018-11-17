using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Agence
    {
        [Key]
        [Range(0, int.MaxValue)]
        public int AgenceKey { get; set; }
        public string NomAgence { get; set; }
        public Address AddressAgence { get; set; }
        [Range(0, int.MaxValue)]
        public int NombreEmploye { get; set; }


        //navigation properties
        public virtual List<Compte> Comptes { get; set; }
    }
}
