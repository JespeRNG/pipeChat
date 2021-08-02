using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DAL.Entities
{
    public class ProfilePhoto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int UserId { get; set; }
    }
}
