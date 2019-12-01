using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.Common.Exceptions
{
    public interface IExceptionHandler
    {
        Task HandleAsync(ExceptionHandlerContext context);
    }
}
