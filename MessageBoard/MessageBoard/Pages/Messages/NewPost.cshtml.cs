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
    public class NewPostModel : PageModel
    {
        private readonly IMessageData messageData;
        [BindProperty]
        public Message Message { get; set; }
        public NewPostModel(IMessageData messageData)
        {
            this.messageData = messageData;
        }
        public IActionResult OnGet(int? MessageId)
        {
            Message = new Message();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = messageData.AddPost(Message);
                messageData.Commit();
                return RedirectToPage("./MessageBox");
            }
            return Page();
        }
    }
}