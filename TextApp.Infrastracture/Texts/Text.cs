using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TextApp.Infrastructure.Users;

namespace TextApp.Infrastructure.Texts
{
    [Table("Texts")]
    public class Text
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string TextContent { get; set; }

        public DateTime DateCreated { get; set; }
        [Required]
        public string UserID { get; set; }

        public User User { get; set; }

    }
}
