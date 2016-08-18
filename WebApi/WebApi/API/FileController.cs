using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApi.API
{
    [RoutePrefix("api/File")]
    public class FileController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get(int? id, string fileName)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<HttpResponseMessage> PostAsync()
        {
            FileStreamProvider streamProvider = new FileStreamProvider("c:\\users\\Matt\\Desktop");
            await Request.Content.ReadAsMultipartAsync(streamProvider);

            foreach (var file in streamProvider.FileData)
            {
                if (file != null)
                {

                }
            }
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }
    }
}