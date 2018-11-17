using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Data.Configurations;
using Exam.Domain.Entities;

namespace Exam.Data
{
   public  class ExamContext :DbContext
    {
        public ExamContext(): base("name=Examen")
        {
            
        }

        public DbSet<Compte> Comptes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompteConfiguration());
        }
    }
}
