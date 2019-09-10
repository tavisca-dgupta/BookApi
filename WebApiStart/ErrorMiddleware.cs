using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApiStart.Controllers;
using WebApiStart.Errors;
using WebApiStart.Model;

namespace WebApiStart
{
    public class ErrorMiddleware
    {
        private RequestDelegate _next;
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(BooksController));
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            logger.Info("Request ---->  " + context.Request);
            try
            {
                await _next(context);
            }
            catch
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("oops!!! try after some time");
            }


            logger.Info("Request ---->  " + context.Response);
        }
        //private ValidationResult FormatRequest(HttpRequest request)
        //{
        //    var body = request.Body;
        //    request.EnableRewind();
        //    var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        //    request.Body.ReadAsync(buffer, 0, buffer.Length);
        //    var bodyAsText = Encoding.UTF8.GetString(buffer);
        //    Book book = JsonConvert.DeserializeObject<Book>(bodyAsText);
        //    RequestValidator validator = new RequestValidator();
        //    ValidationResult result = validator.Validate(book);
        //    return result;
        //}



    }
}
