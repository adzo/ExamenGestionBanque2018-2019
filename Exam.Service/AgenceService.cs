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
    public class AgenceService : Service<Agence> , IAgenceService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        AgenceService AS = new AgenceService();

        public AgenceService() : base(unit)
        {
            
        }





        public int nombreClient(Agence A)
        {
            int result = 0;
            Agence found = AS.GetById(A.AgenceKey);
            if (found != null)
            {
                foreach (var compte in found.Comptes)
                {
                    if (compte.Credits.Count != 0)
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }
}
