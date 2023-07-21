using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChatWPF
{
    internal class ChatMessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BotMessageTemplate { get; set; }
        public DataTemplate UserMessageTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ChatMessage chatMessage)
            {
                return chatMessage.IsBotMessage ? BotMessageTemplate : UserMessageTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
