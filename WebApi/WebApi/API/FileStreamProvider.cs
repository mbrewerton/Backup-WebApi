using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WebApi.API
{
    public class FileStreamProvider : MultipartFormDataStreamProvider
    {
        public FileStreamProvider(string path) :base(path)
        { }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            string fileName = headers.ContentDisposition.FileName;

            return fileName.Replace("\"", string.Empty);
        }
    }
}