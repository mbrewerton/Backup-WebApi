using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApi.API.Extensions;
using WebApi.Models;

namespace WebApi.API
{
    [RoutePrefix("api/File")]
    public class FileController : WebApiController
    {
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get(int? id, string fileName)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        [HttpPost]
        [Route("PostAsync")]
        /// <summary>
        ///     Post a file to be saved to the backup filesystem.
        /// </summary>
        public async Task<HttpResponseMessage> PostAsync()
        {
            Folder userFolder;
            using (var ctx = new ApplicationDbContext())
            {
                userFolder = ctx.Folders.FirstOrDefault(x => x.ApiKeyId == ApiKey.Key);
            }
            var path = ConfigurationManager.AppSettings.Get("DefaultFolderPath") + "\\" + userFolder.FolderName + "\\" + DateTime.Today.ToString("dd'.'MM'.'yyyy");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            // Setup a stream provider at our folder location
            FileStreamProvider streamProvider = new FileStreamProvider(path);
            try
            {
                // Attempt to read the file data to our stream
                await Request.Content.ReadAsMultipartAsync(streamProvider);
            }
            catch (Exception ex)
            {
                // An error occurred. Throw a generic error as we can't really see what happened.
                throw new HttpResponseException(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content =
                        new StringContent("An error occurred when reading the file.")
                    });
            }

            // File upload went A-OK.
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }
    }
}