using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Folder : Entity
    {
        public ApiKey ApiKey { get; set; }
        public Guid ApiKeyId { get; set; }

        public string FolderName { get; set; }
    }
}