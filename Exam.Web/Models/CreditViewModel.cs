using System;
using System.Collections.Generic;
using Exam.Domain.Entities;
using Type = System.Type;

namespace Exam.Web.Models
{
    public class CreditViewModel
    {
        public int CreditKey { get; set; }
        
        public float SommeCredit { get; set; }
       
        public DateTime DateCredit { get; set; }
        
        public float TauxInteret { get; set; }

        public TypeViewModel TypeCredit { get; set; }

        public virtual List<CompteViewModel> Comptes { get; set; }
    }
}