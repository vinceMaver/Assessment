using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.Common.Exceptions
{
    public interface IExceptionLogger
    {
        Task LogAsync(ExceptionLoggerContext context);
    }
}
