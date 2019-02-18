using MessageBoard.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.Data
{
    public interface IMessageData
    {
       IEnumerable<Message> GetAll();
        Message GetById(int id);
        Message AddPost(Message post);
        int Commit();
        Message AddComment(Message updateMessage);
        int Like(Message updateMessage);
    }
}
