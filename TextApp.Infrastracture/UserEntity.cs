using System;
using System.Collections.Generic;
using System.Text;

namespace TextApp.Infrastructure
{
    public class UserEntity
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<int> UserTexts { get; set; }

        public UserEntity()
        {

        }
        public UserEntity(string ID, string UserName, string Password, List<int> UserTexts)
        {
            this.ID = ID;
            this.UserName = UserName;
            this.Password = Password;
            this.UserTexts = UserTexts;
        }
    }
}
