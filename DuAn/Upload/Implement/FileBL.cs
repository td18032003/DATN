using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Upload.Enum;
using Upload.Interface;
using Upload.Models;

namespace Upload.Implement
{
    public class FileBL : BaseBL, IFileBL
    {
        public FileBL(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<object> GetAllPersonal(Dictionary<string, object> param)
        {
            string where = string.Empty;
            if (param.ContainsKey("ParentID"))
            {
                where = $"AND ParentID = {param["ParentID"]};";
            }
            string sql = $"SELECT * FROM file WHERE TenantID = '{param["TenantID"]}' AND CreatedBy = {param["EmployeeID"]}" + where + " Order By TypeFileEnum";
            return await QueryAsync<Models.File>(sql);
        }
        /// <summary>
        /// Hàm lưu file bắn lên
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public object UploadFile(IFormFile file)
        {
            var folderName = Path.Combine("Resources", "Document");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var listName = fileName.Split(".").ToList();
                string typeFile = listName[listName.Count - 1].ToString().ToUpper();
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                //FileName = fileName;
                //data.Type = typeFile;
                //data.Size = (int?)file.Length;
                //data.Path = _configuration.GetConnectionString("HostUpload") + dbPath.Replace("\\", "/");
                //var content = new Object();
                string type = string.Empty;
                int typeFileEnum = 0;
                switch (typeFile)
                {
                    case "XLSX":
                        //content = ReadExcel(dbPath.ToString());
                        //data.Content = JsonConvert.SerializeObject(content);
                        type = "Excel";
                        typeFileEnum = 2;
                        break;
                    case "DOCX":
                        //content = ReadDocx(dbPath.ToString());
                        //data.Content = JsonConvert.SerializeObject(content);
                        type = "Word";
                        typeFileEnum = 1;
                        break;
                    case "PDF":
                        type = "Pdf";
                        typeFileEnum = 3;
                        break;
                    default:
                        break;
                }
                return new Models.File()
                {
                    FileName = fileName,
                    TypeFile = type,
                    Path = _configuration.GetConnectionString("HostUpload") + dbPath.Replace("\\", "/"),
                    Size = (int)file.Length,
                    TypeFileEnum = typeFileEnum
                };
            }
            return null;
        }
    }
}
