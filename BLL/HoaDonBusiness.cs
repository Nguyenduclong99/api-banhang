using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class HoaDonBusiness : IHoaDonBusiness
    {
        private IHoaDonRepository _res;
        public HoaDonBusiness(IHoaDonRepository res)
        {
            _res = res;
        }
        public bool Create(HoaDonModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<HoaDonModel> GetAllBill()
        {
            return _res.GetAllBill();
        }

        public List<ChiTietHoaDonModel> GetBillByID(string id)
        {
            return _res.GetBillByID(id);
        }
        public List<ChiTietHoaDonModel> GetAllBillDetails()
        {
            return _res.GetAllBillDetails();
        }
    }

}
