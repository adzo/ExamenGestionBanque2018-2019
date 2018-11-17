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
    public class CreditService : Service<Credit>, ICreditService
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);

        public CreditService() : base(unit)
        {
            
        }
    }
}
