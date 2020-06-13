using System;
using System.Collections.Generic;
using System.Text;

namespace TextApp.Infrastructure
{
    public class TextEntity
    {
        public int ID { get; set; }
        public string TextContent { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserID { get; set; }

        public string UserName { get; set; }

        public TextEntity()
        {

        }
        public TextEntity(int id, string TextContent, DateTime DateCreated, string UserID)
        {
            this.ID = id;
            this.TextContent = TextContent;
            this.DateCreated = DateCreated;
            this.UserID = UserID;
        }

    }
}
