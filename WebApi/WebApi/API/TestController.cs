using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.API
{
    public class MyObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TestController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var data = new List<MyObject> {
                new MyObject { Id = 0, Name = "Hello" },
                new MyObject { Id = 1, Name = "World" }
            };
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}