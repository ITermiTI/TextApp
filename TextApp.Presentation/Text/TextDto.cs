using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TextApp.Presentation.Text
{
    public class TextDto
    {
        public int ID { get; set; }
        [DisplayName("Content")]
        [MaxLength(50, ErrorMessage = "Your text has a maximum length of 50 characters")]
        [MinLength(1, ErrorMessage = "Please, specify your input for text")]
        public string TextContent { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string CreatorName { get; set; }
    }
}
