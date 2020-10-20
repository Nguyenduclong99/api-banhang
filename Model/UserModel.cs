using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UserModel
    {
        public string ID { get; set; }
        
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string image_url { get; set; }
    }
}
