using System.Collections.Generic;
using MessageBoard.core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Data
{
    public class SqlMessageData : IMessageData
    {
        private readonly MessageBoardDbContext db;

        public SqlMessageData(MessageBoardDbContext db)
        {
            this.db = db;
        }
        public Message AddComment(Message updateMessage)
        {
            var messages = db.Message.SingleOrDefault(r => r.Id == updateMessage.Id);
            messages.comments = messages.comments + "," + updateMessage.comments;
            return messages;
        }

        public Message AddPost(Message post)
        {
            db.Add(post);
            return post;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public IEnumerable<Message> GetAll()
        {
            var query = from r in db.Message
                        orderby r.message
                        select r;
            return query;
        }

        public Message GetById(int id)
        {
            return db.Message.Find(id);
        }
       public int Like(Message updateMessage)
        {
            var Messages = db.Message.SingleOrDefault(r => r.Id == updateMessage.Id);
            Messages.count = Messages.count + 1;
            return Messages.count;
        }
    }
}
