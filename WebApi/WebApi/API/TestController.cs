using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.API.Extensions;
using WebApi.Models;

namespace WebApi.API
{
    public class MyObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [RoutePrefix("api/Test")]
    public class TestController : WebApiController
    {
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            var data = new List<MyObject> {
                new MyObject { Id = 0, Name = "Hello" },
                new MyObject { Id = 1, Name = "World" }
            };
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("CreateApiKeyFolderLink")]
        public HttpResponseMessage CreateApiKeyFolderLink(string folderName)
        {
            Folder newFolder;
            using (var ctx = new ApplicationDbContext())
            {
                var exists = ctx.Folders.SingleOrDefault(x => x.ApiKey.Key == ApiKey.Key);
                if (exists != null)
                {
                    exists.FolderName = folderName;
                    newFolder = exists;
                }
                else
                {
                    var folder = new Folder
                    {
                        Id = Guid.NewGuid(),
                        ApiKeyId = ApiKey.Key,
                        ApiKey = ApiKey,
                        FolderName = folderName
                    };
                    newFolder = folder;
                    ctx.Folders.Add(folder);
                }
                ctx.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, newFolder);
            }
        }
    }
}