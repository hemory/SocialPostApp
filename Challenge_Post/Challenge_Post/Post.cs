using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Post
{
    class Post
    {
        public string  Title { get; set; }

        public string Message { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public Post(string title, string message, string author)
        {
            Title = title;
            Message = message;
            Author = author;
            Date = DateTime.Now;
        }

       

        public string GetCompletePostString()
        {
            return $"Title: {Title} Message: {Message} Author {Author} Created On: {Date.ToLongDateString()}";
        }

        public void UpdateTitle(string newTitle)
        {
            Title = newTitle; 
        }

        public void UpdateMessage(string newMessage)
        {
            Message = newMessage;
        }

        public void UpdateAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        
    }
}
