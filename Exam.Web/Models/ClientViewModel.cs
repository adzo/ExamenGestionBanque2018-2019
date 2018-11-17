using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class ClientViewModel
    {
        
        public string CIN { get; set; }
        public NomCompletViewModel FullName { get; set; }
        
        public DateTime DateNaissance { get; set; }
        public string Profession { get; set; }
        public AddressViewModel Address { get; set; }
        
        public float Salaire { get; set; }


        public virtual List<CompteViewModel> Comptes { get; set; }
    }
}