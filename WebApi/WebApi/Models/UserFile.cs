using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class UserFile : Entity
    {
        public ApiKey ApiKey { get; set; }
        public Guid ApiKeyId { get; set; }

        public string FileName { get; set; }
        public string Folder { get; set; }
    }
}