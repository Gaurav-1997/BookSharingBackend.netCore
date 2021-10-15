using BookSharing.ComponentHelper;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSharing.Middlewares
{
    public class ExceptionMiddlewares
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddlewares> logger;
        private readonly ILog Logger = Log4netHelper.GetLogger(typeof(ExceptionMiddlewares));

        public ExceptionMiddlewares(RequestDelegate next, ILogger<ExceptionMiddlewares> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                
                logger.LogError(ex, ex.Message); // for showing the error in console
                Logger.Error(ex.Message);

                // handling all the unhandled exxception here
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ex.Message);
                
            }
        }
    }
}
