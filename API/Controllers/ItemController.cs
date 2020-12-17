using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemBusiness _itemBusiness;
        private string _path;
        public ItemController(IItemBusiness itemBusiness, IConfiguration configuration)
        {
            _itemBusiness = itemBusiness;
            _path = configuration["AppSettings:PATH"];
        }

        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("create-item")]
        [HttpPost]
        public ItemModel CreateItem([FromBody] ItemModel model)
        {

            if (model.Image != null)
            {
                var arrData = model.Image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"{arrData[0]}";
                    model.Image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _itemBusiness.Create(model);
            return model;
        }
        [Route("update-item/{id}")]
        [HttpPost]
        public ItemModel Edit(int id, [FromBody] ItemModel model)
        {

            if (model.Image != null)
            {
                var arrData = model.Image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"{arrData[0]}";
                    model.Image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _itemBusiness.Edit(id, model);
            return model;
        }
        [HttpGet]
        [Route("delete/{id}")]

        public bool Delete(int id)
        {
            return _itemBusiness.Delete(id);

        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public ItemModel GetDatabyID(int id)
        {
            return _itemBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ItemModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string category_id = "";
                if (formData.Keys.Contains("category_id") && !string.IsNullOrEmpty(Convert.ToString(formData["category_id"]))) { category_id = Convert.ToString(formData["category_id"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize,out total, category_id);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
        [Route("get-item-related/{id}/{category_id}")]
        [HttpGet]
        public IEnumerable<ItemModel> GetProductRelated(int id, string category_id)
        {
            return _itemBusiness.GetProductRelated(id, category_id);
        }

    }
}
