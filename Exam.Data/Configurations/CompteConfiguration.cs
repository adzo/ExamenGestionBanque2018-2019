using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Entities;

namespace Exam.Data.Configurations
{
    public class CompteConfiguration : EntityTypeConfiguration<Compte>
    {
        public CompteConfiguration()
        {


            HasMany<Credit>(y => y.Credits).WithMany(o => o.Comptes).Map(t => t.ToTable("CompteCredit"));


            Map<CompteEpargne>(c =>
            {
                c.Requires("Type").HasValue(0); //Type is the descriminator
            });
            Map<CompteCourant>(c =>
            {
                c.Requires("Type").HasValue(1);
            });
        }
    }
}
