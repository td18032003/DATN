using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upload.Interface
{
    public interface IFileBL : IBaseBL
    {
        public Task<object> GetAllPersonal(Dictionary<string, object> param);

        public object UploadFile(IFormFile file);

        public Task<object> InsertPersonal(Models.File file);

        public Task<List<Models.File>> SearchFile(string param);
    }
}
