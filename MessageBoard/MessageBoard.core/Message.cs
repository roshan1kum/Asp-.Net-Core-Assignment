using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MessageBoard.core
{
    
   public class Message
    {
        [Required]
        public string message { get; set; }
        public int Id { get; set; }
        public string comments { get; set; }
        public int count { get; set; }
    }
}
