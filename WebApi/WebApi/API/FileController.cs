using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApi.API
{
    [RoutePrefix("api/File")]
    public class FileController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get(string fileName)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        [HttpPost]
        [Route("Post")]
        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }
    }
}