using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string DialogId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public bool Edited { get; set; }
        public DateTime CreationTime { get; set; }
        public int? AlbumId { get; set; }
    }
}