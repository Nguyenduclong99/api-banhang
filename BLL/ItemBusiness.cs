using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class ItemBusiness : IItemBusiness
    {
        private IItemRepository _res;
        public ItemBusiness(IItemRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(ItemModel model)
        {
            return _res.Create(model);
        }
        public bool Edit(int id, ItemModel model)
        {
            return _res.Edit(id, model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public ItemModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ItemModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<ItemModel> Search(int pageIndex, int pageSize, out long total, string category_id)
        {
            return _res.Search(pageIndex, pageSize, out total, category_id);
        }
        public List<ItemModel> GetProductRelated(int id, string category_id)
        {
            return _res.GetProductRelated(id, category_id);
        }
        public List<ItemModel> SanPhamBanChay()
        {
            return _res.SanPhamBanChay();
        }
        public List<ItemModel> SanPhamBanCham()
        {
            return _res.SanPhamBanCham();
        }
    }

}
