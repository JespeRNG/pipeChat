using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DAL.Entities
{
    public class Dialog
    {
        public int Id { get; set; }
        public int DialogId { get; set; }
        public int UserId { get; set; }
    }
}
