using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOFOY.Models
{
    public class SendEmailViewModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please input a subject")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please input a subject")]        
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please input the content")]
        public string Content { get; set; }
    }
}