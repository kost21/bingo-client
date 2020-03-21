using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoClient
{
    public class MailItem
    {
        public MailItem()
        {

        }

        public string Subject { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;
    }
}
