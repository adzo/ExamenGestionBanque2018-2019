using System;
using System.Collections.Generic;
using Exam.Domain.Entities;

namespace Exam.Web.Models
{
    public class CompteViewModel
    {
        
        public int RIB { get; set; }
       
        public DateTime DateOuverture { get; set; }
        
        public float Solde { get; set; }

        //foreign Keys
        public string CIN { get; set; }
        public int AgenceKey { get; set; }

        //navigation properties
        public virtual AgenceViewModel Agence { get; set; }
        public virtual ClientViewModel Client { get; set; }
        public virtual List<CreditViewModel> Credits { get; set; }
    }
}