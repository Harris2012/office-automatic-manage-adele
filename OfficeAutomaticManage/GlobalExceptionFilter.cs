using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Canos.OfficeAutomatic
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var loggerFactory = context.HttpContext.RequestServices.GetService(typeof(ILoggerFactory)) as ILoggerFactory;
            if (loggerFactory != null)
            {
                var logger = loggerFactory.CreateLogger<GlobalExceptionFilter>();
                logger.LogError(context.Exception, context.Exception.Message ?? "NA");
            }

            throw context.Exception;
        }
    }
}
