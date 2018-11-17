using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Entities;
using Service.Pattern;

namespace Exam.Service
{
    public interface IClientService : IService<Client>
    {
    }
}
