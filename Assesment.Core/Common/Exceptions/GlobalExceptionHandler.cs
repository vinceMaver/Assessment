using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.Common.Exceptions
{
    public class GlobalExceptionHandler: IExceptionHandler
    {
        public Task HandleAsync(ExceptionHandlerContext context)
        {
            throw new NotImplementedException();
        }

        //public override void HandleCore(ExceptionHandlerContext context)
        //{
        //    context.Result = new TextPlainErrorResult
        //    {
        //        Request = context.ExceptionContext.Request,
        //        Content = "Pizza Down! We have an Error! Please call the parlor to complete your order."
        //    };
        //}
    }
}
