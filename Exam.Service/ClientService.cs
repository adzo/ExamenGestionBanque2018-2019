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
    public class ClientService : Service<Client>, IClientService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);

        public ClientService() : base(unit)
        {
            
        }

        public float CreditMaximum(Client C)
        {
            int ageRestant = 60 - (DateTime.Now.Year - C.DateNaissance.Year);
            float result = 0.4f * C.Salaire * 12 * ageRestant;
            return result;
        }

        
    }
}
