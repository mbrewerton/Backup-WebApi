using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebApi.Models;

namespace WebApi.API.Extensions
{
    public class WebApiController : ApiController
    {
        public ApiKey ApiKey;
        public WebApiController()
        {
        }
        public HttpResponseMessage CreateErrorResponse()
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError("An error occurred carrying out your request. Please try again."));
        }

        public HttpResponseMessage CreateErrorResponse(string message)
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError(message));
        }

        public HttpResponseMessage CreateForbiddenResponse()
        {
            return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "You are not authorised to make that call.");
        }

        public HttpResponseMessage CreateForbiddenResponse(string message)
        {
            return Request.CreateErrorResponse(HttpStatusCode.Forbidden, new HttpError(message));
        }

        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var headers = controllerContext.Request.Headers;
            IEnumerable<string> values;
            if (headers.TryGetValues("X-ApiKey", out values))
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var apiKeyFromHeader = values.FirstOrDefault();
                    var key = ctx.ApiKeys.FirstOrDefault(x => x.Key.ToString() == apiKeyFromHeader);
                    // Our key does not exist in the DB. It is invalid. return error.
                    if (key == null)
                    {
                        response.StatusCode = HttpStatusCode.Forbidden;
                        response.Content = new StringContent($"The key '{apiKeyFromHeader}' is invalid.");
                        throw new HttpResponseException(response);
                    }
                    else
                    {
                        ApiKey = key;
                    }
                }
            }
            else // Our header doesn't exist.
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent("You must supply an ApiKey in the 'X-ApiKey' header.");
                throw new HttpResponseException(response);
            }
            // All of our error checks pass. The ApiKey is supplied and correct. Continue Execution.
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }
    }
}