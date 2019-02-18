using System;
using System.Collections.Generic;
using System.Text;
using MessageBoard.core;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Data
{
    public class MessageBoardDbContext : DbContext
    {
        public MessageBoardDbContext(DbContextOptions<MessageBoardDbContext> options)
            : base(options)
        {

        }
        public DbSet<Message> Message { get; set; }
    }
}
