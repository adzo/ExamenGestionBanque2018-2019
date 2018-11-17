using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class CompteCourant : Compte
    {
        [Range(0, float.MaxValue)]
        public float DecouvertMax { get; set; }
    }
}
