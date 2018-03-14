using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Portal.Models
{
    public class Message
    {
        public string Type { get; set; }
        public string ConnectionId { get; set; }
        public string Content { get; set; }

    }
}