using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<ChatMessage> chatMessages = new ObservableCollection<ChatMessage>();

        private readonly List<string> responses = new List<string>
        {
            "Привіт!",
            "Як справи?",
            "Чим можу допомогти?",
            "Я зайнятий, але все одно відповім.",
            "Це цікаво!",
            "Не розумію про що ти, але звучить кумедно.",
            "Скажи ще щось.",
            "Привіт, чим можу допомогти?",
            "Слава України!",
            ":))"
        };

        public MainWindow()
        {
            InitializeComponent();
            chatMessages = new ObservableCollection<ChatMessage>();
            listBoxChat.ItemsSource = chatMessages;
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            string message = textBoxText.Text.Trim();
            if (!string.IsNullOrWhiteSpace(message))
            {
                AddToChat(new ChatMessage { Content = "Ви: " + message, IsBotMessage = false });
                string botResponse = GetRandomResponse(message.ToLower());
                AddToChat(new ChatMessage { Content = "Бот: " + botResponse, IsBotMessage = true });
                textBoxText.Text = string.Empty;
            }

        }

        private void AddToChat(ChatMessage chatMessage)
        {
            chatMessages.Add(chatMessage);
            listBoxChat.ScrollIntoView(chatMessage);
        }

        private string GetRandomResponse(string userMessage)
        {
            if (userMessage.Contains("привіт") || userMessage.Contains("вітаю"))
            {
                return "Привіт, чим можу допомогти?";
            }
            else if (userMessage.Contains("справи") || userMessage.Contains("як життя"))
            {
                return "У мене все добре, дякую!";
            }
            else if (userMessage.Contains("допомога") || userMessage.Contains("що ти вмієш"))
            {
                return "Я можу відповідати на запитання та підтримувати розмови.";
            }
            else if (userMessage.Contains("слава") || userMessage.Contains("Україна"))
            {
                return ":)";
            }
            else
            {
                Random random = new Random();
                int index = random.Next(responses.Count);
                return responses[index];
            }
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void textBoxText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonSend_Click(sender, e);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxText.Focus();
        }
    }
}
