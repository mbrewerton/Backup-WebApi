using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Respositories
{
    public partial interface IApiKeyRepository : IRepository<ApiKey> { }
    public partial class ApiKeyRepository : GenericRepository<ApiKey>
    {
        public ApiKeyRepository(IObjectContext objectContext) : base(objectContext) { }
    }
}
