using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Data.Infrastructure;
using Exam.Domain.Entities;
using Service.Pattern;

namespace Exam.Service
{
    public class CompteService : Service<CompteCourant>, ICompteService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        CompteService CS = new CompteService();
        public CompteService() : base(unit)
        {
            
        }

        public List<CompteCourant> listeCourant()
        {
            List < CompteCourant > result = new List<CompteCourant>();
            foreach (var item in CS.GetAll())
            {
                if (item.Credits != null)
                {
                    foreach (var credit in item.Credits)
                    {
                        if (credit.SommeCredit > 10000)
                        {
                            result.Add(item);
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
