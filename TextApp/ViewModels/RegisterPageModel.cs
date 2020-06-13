using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextApp.Presentation.User;

namespace TextApp.Web.ViewModels
{
    public class RegisterPageModel


    {
        public UserDto userDto { get; set; }
        public bool ShouldBeAdmin { get; set; }
    }
}
