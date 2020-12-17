using System;
using System.Collections.Generic;
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
    public class HoaDonController : ControllerBase
    {
        private IHoaDonBusiness _hoaDonBusiness;
        public HoaDonController(IHoaDonBusiness hoaDonBusiness)
        {
            _hoaDonBusiness = hoaDonBusiness;
        }
         
        [Route("create-hoa-don")]
        [HttpPost]
        public HoaDonModel CreateItem([FromBody] HoaDonModel model)
        {
            model.ID = Guid.NewGuid().ToString();
            if (model.listjson_chitiet != null)
            {
                foreach(var item in model.listjson_chitiet)
                    item.ID = Guid.NewGuid().ToString();
            }
            _hoaDonBusiness.Create(model);
            return model;
        }
        [Route("get-bill")]
        [HttpGet]
        public List<HoaDonModel> GetBills()
        {
            return _hoaDonBusiness.GetAllBill();
        }
        [Route("get-bill-detail/{id}")]
        [HttpGet]
        public List<ChiTietHoaDonModel> GetBillDetail(string id)
        {
            return _hoaDonBusiness.GetBillByID(id);
        }
        [Route("get-billdetail")]
        [HttpGet]
        public List<ChiTietHoaDonModel> GetBillDetail()
        {
            return _hoaDonBusiness.GetAllBillDetails();
        }
        [Route("delete-bill/{id}")]
        [HttpGet]
        public bool Delet(string id)
        {
            return _hoaDonBusiness.Delete(id);
        }
        
    }
}
