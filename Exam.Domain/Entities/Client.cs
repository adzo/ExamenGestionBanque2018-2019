using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Client
    {
        [Key]
        public string CIN { get; set; }
        public NomComplet FullName { get; set; }
        [Required]
        public DateTime DateNaissance { get; set; }
        public string Profession { get; set; }
        public Address Address { get; set; }
        [Range(0, float.MaxValue)]
        public float Salaire { get; set; }


        public virtual List<Compte> Comptes { get; set; }
    }
}
