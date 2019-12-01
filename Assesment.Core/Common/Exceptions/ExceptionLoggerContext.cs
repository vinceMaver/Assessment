using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.Common.Exceptions
{
    public class ExceptionLoggerContext
    {
        public ExceptionContext ExceptionContext { get; set; }
        public bool CanBeHandled { get; set; }
    }
}
