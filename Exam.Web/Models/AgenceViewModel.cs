using System.Collections.Generic;
using Exam.Domain.Entities;

namespace Exam.Web.Models
{
    public class AgenceViewModel
    {

        public int AgenceKey { get; set; }
        public string NomAgence { get; set; }
        public AddressViewModel AddressAgence { get; set; }
       
        public int NombreEmploye { get; set; }


        //navigation properties
        public virtual List<CompteViewModel> Comptes { get; set; }
    }
}