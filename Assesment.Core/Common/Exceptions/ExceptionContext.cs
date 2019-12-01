using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.Common.Exceptions
{
    public class ExceptionContext
    {
            public Exception Exception { get; set; }

            public HttpRequestMessage Request { get; set; }

            //public HttpRequestContext RequestContext { get; set; }

            //public HttpControllerContext ControllerContext { get; set; }

            //public HttpActionContext ActionContext { get; set; }

            public HttpResponseMessage Response { get; set; }

            public string CatchBlock { get; set; }

            public bool IsTopLevelCatchBlock { get; set; }
    }
}
