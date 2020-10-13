﻿using System;
using System.Collections.Generic;

namespace Model
{
    public class HoaDonModel
    {
        public string ID { get; set; }
        public string Payment { get; set; }
        public int Total { get; set; }
        public DateTime DateOrder { get; set; }
        public List<ChiTietHoaDonModel> listjson_chitiet { get; set; }
    }
}
