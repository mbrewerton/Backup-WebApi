using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.API
{
    [RoutePrefix("api/ApiKey")]
    public class ApiKeyController : ApiController
    {
        [HttpPost]
        [Route("GenerateKey")]
        public HttpResponseMessage GenerateKey()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var key = Guid.NewGuid();
                var newApiKey = new ApiKey { Key = key };
                ctx.ApiKeys.Add(newApiKey);
                ctx.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, newApiKey);
            }
        }
    }
}