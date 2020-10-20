using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IItemBusiness
    {
        bool Create(ItemModel model);
        bool Edit(int id, ItemModel model);
        bool Delete(int id);
        ItemModel GetDatabyID(int id);
        List<ItemModel> GetDataAll();
        List<ItemModel> Search(int pageIndex, int pageSize, out long total, string category_id);
        List<ItemModel> GetProductRelated(int id, string category_id);
    }
}
