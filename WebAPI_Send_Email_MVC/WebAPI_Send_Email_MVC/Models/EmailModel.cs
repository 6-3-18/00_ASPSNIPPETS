using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Send_Email_MVC.Models
{
        public class EmailModel
        {
            public string Email { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
        }
}