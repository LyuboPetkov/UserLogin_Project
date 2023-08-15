using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String FacNum { get; set; }
        public int Role { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime? validity { get; set; }
        public int UserId { get; set; }
    }
}