using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload.Entity;
using Upload.Interface;
using Upload.Models;

namespace Upload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseController<File>
    {
        public IFileBL _fileBL;
        public FileController(IFileBL fileBL, IBaseBL baseBL) : base(baseBL)
        {
            baseBL.SetTableName("file");
            this.BL = fileBL;
            _fileBL = fileBL;
            this.curentType = typeof(File);
        }
        [HttpPost("personal")]
        public async Task<ServiceResponse> GetAllPersonal(Dictionary<string, object> param)
        {
            ServiceResponse res = new ServiceResponse() { };
            try
            {
                res.Data = await _fileBL.GetAllPersonal(param);
            }
            catch (Exception ex)
            {
                return _baseBL.Error(ex);
            }
            return res;
        }

        [HttpPost("search")]
        public async Task<ServiceResponse> SearchFile([FromBody] string param)
        {
            ServiceResponse res = new ServiceResponse() { };
            try
            {
                res.Data = await _fileBL.SearchFile(param);
            }
            catch (Exception ex)
            {
                return _baseBL.Error(ex);
            }
            return res;
        }

        [HttpPost("insert-personal")]
        public async Task<ServiceResponse> InsertPersonal(Models.File file)
        {
            ServiceResponse res = new ServiceResponse() { };
            try
            {
                res.Data = await _fileBL.InsertPersonal(file);
            }
            catch (Exception ex)
            {
                return _baseBL.Error(ex);
            }
            return res;
        }

        [HttpPost("upload-file"), DisableRequestSizeLimit]
        public ServiceResponse UploadFile()
        {
            ServiceResponse res = new ServiceResponse();
            try
            {
                FileInfomation data = new FileInfomation();
                var file = Request.Form.Files[0];
                res.Data = _fileBL.UploadFile(file);
            }
            catch(Exception e)
            {
                return _baseBL.Error(e);
            }
            return res;
        }
    }
}
