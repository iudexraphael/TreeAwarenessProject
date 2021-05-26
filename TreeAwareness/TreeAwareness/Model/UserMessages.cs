using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace TreeAwareness.Model
{
  public  class UserMessages
    {
        [Key]

        public int messageID { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }

        public string Image { get; set; }
    }
}
