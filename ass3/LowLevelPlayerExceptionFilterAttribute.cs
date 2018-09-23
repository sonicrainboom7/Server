using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ass3
{
    public class LowLevelPlayerExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is LowLevelPlayerException)
            {
                var result = new ContentResult();
                result.StatusCode = 400;
                result.Content = context.Exception.Message;
                context.Result = result;

                
                
            }
        }
    }
}