using MessageBoard.core;
using System.Collections.Generic;
using System.Linq;

namespace MessageBoard.Data
{
    public class InMemoryMessageData : IMessageData
    {
        List<Message> message;
        public InMemoryMessageData()
        {
            message = new List<Message>()
            {
            new Message{Id=1, message = "fefhefhehbobffhf",comments= "",count=1},
            new Message{Id=2,message="dbjdbjbkndnnk",comments= "",count=1}
            };
        }
        public Message GetById(int id)
        {
            return message.SingleOrDefault(r => r.Id == id);
        }
        public Message AddPost(Message Post)
        {
            message.Add(Post);
            Post.Id = message.Max(r => r.Id) + 1;
            return Post;
        }
        public Message AddComment(Message updateMessage)
        {
            var messages = message.SingleOrDefault(r => r.Id == updateMessage.Id);
            messages.comments = messages.comments+" "+updateMessage.comments;
            return messages;
        }
        public int Like(Message updateMessage)
        {
            var messages = message.SingleOrDefault(r => r.Id == updateMessage.Id);
            messages.count = messages.count + 1;
            return messages.count;
        }
        public int Commit()
        {
            return 0;
        }
       
        public IEnumerable<Message> GetAll()
        {
            return from m in message
                   orderby m.Id
                   select m;
        }
    }
}
