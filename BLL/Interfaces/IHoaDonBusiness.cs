using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IHoaDonBusiness
    {
        bool Create(HoaDonModel model);
        bool Delete(string id);
        List<HoaDonModel> GetAllBill();
        List<ChiTietHoaDonModel> GetBillByID(string id);
    }
}
