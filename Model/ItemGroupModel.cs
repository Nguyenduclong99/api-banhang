using System;
using System.Collections.Generic;

namespace Model
{
    public class ItemGroupModel
    {
        public string Parent_id { get; set; }
        public int IDType { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public short? Seq_num { get; set; }
        public List<ItemGroupModel> children { get; set; }
        public string type { get; set; }
    }
}
