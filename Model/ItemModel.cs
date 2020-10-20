using System;
using System.Collections.Generic;

namespace Model
{
    public class ItemModel
    {
        public int ID_product{ get; set; }
        public string Catergory_id { get; set; }
        public string Name { get; set; }
        public float Unit_price { get; set; }
        public float Promotion_price { get; set; }
        public string Description { get; set; }
        //public DateTime Created_at { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
    }
}
