using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace GetMailWithAttachment.Models
{
    public class EmailViewModel
    {
        [Required(ErrorMessage = "Recipient email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Recipient { get; set; }

        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Body is required.")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Attachment is required.")]
        public IEnumerable<IFormFile> Attachments { get; set; }
    }
}

