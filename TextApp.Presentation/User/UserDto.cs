using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TextApp.Presentation.User
{
    public class UserDto
    {
        public string ID { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Your login should have at least 3 characters")]
        [MaxLength(20, ErrorMessage = "Your login can be of maximum 20 characters length")]
        [DisplayName("Login")]
        public string UserName { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Your password should have at least 6 characters")]
        [MaxLength(20, ErrorMessage = "Your password can be of maximum 20 characters length")]
        [DisplayName("Password")]
        public string Password { get; set; }

        public UserDto()
        {

        }

        public UserDto(string Username, string Password)
        {
            this.UserName = Username;
            this.Password = Password;
        }
    }
}
