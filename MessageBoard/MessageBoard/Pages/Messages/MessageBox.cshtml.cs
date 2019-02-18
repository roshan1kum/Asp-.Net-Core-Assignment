using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBoard.core;
using MessageBoard.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessageBoard.Pages.Messages
{
    public class MessageBoxModel : PageModel
    {
        private readonly IMessageData messageData;
        public IEnumerable<Message> Messages { get; set; }
        [BindProperty]
        public Message Message { get; set; }

        public MessageBoxModel(IMessageData messageData)
        {
            this.messageData = messageData;
        }
        public void OnGet(int MessageId)
        {
            Messages = messageData.GetAll();
        }
       public IActionResult OnPost(int MessageId)
        {
            Message = messageData.GetById(MessageId);
            Message.count = messageData.Like(Message);
            messageData.Commit();
            return RedirectToPage("./MessageBox");
        }
    }
}