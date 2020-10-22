using System;
using System.Collections.Generic;

namespace Model
{
    public class ChiTietHoaDonModel
    {
        public string ID { get; set; }
        public string ID_bill { get; set; }
        public int ID_product { get; set; }
        public float Unit_price { get; set; }
        public int quantity_sale { get; set; }      
        public string name { get; set; }
    }
}
