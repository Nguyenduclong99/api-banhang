using System;
using System.Collections.Generic;

namespace Model
{
    public class HoaDonModel
    { 
        public string ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public float Total { get; set; }
        public string Note { get; set; }
        
         public DateTime DateOrder { get; set; }
        public List<ChiTietHoaDonModel> listjson_chitiet { get; set; }
    }
}
