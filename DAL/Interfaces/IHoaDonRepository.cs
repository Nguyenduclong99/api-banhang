using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IHoaDonRepository
    {
        bool Create(HoaDonModel model);
        bool Delete(string id);
        List<HoaDonModel> GetAllBill();
        List<ChiTietHoaDonModel> GetBillByID(string id);
    }
}
