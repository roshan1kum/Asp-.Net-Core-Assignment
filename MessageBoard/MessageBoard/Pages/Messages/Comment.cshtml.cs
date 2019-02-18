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
    public class CommentModel : PageModel
    {
        private readonly IMessageData messageData;
        [BindProperty]
        public Message Messages { get; set; }
        public CommentModel(IMessageData messageData)
        {
            this.messageData = messageData;
        }
        public IActionResult OnGet(int MessageId)
        {
            Messages = messageData.GetById(MessageId);
            return Page();
        }
        public IActionResult OnPost()
        {
            Messages = messageData.AddComment(Messages);
            messageData.Commit();
            return RedirectToPage("./MessageBox");
        }
    }
}