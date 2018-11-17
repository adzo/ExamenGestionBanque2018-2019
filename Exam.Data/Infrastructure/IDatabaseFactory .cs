
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ExamContext DataContext { get; }
    }

}
