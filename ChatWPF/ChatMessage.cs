using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWPF
{
    internal class ChatMessage
    {
        public string Content { get; set; }
        public bool IsBotMessage { get; set; }

        public override string ToString()
        {
            return Content;
        }
    }
}
