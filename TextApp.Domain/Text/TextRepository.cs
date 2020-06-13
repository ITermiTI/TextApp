using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TextApp.Infrastructure;
using TextApp.Infrastructure.Texts;

namespace TextApp.Domain.Text
{
    public class TextRepository : ITextRepository
    {
        private readonly TextDBContext _context;
        private readonly UserManager<Infrastructure.Users.User> userManager;

        public TextRepository(TextDBContext context, UserManager<Infrastructure.Users.User> userManager)
        {
            this._context = context;
            this.userManager = userManager;
        }
        public async Task Create(TextEntity Text, ClaimsPrincipal user)
        {
            var UserEntity = await userManager.FindByNameAsync(user.Identity.Name);
            this._context.Add(new TextApp.Infrastructure.Texts.Text
            {
                TextContent = Text.TextContent,
                DateCreated = Text.DateCreated,
                UserID = UserEntity.Id,
            }
                );
            this._context.SaveChanges();

        }

        public void Delete(int ID)
        {
            Infrastructure.Texts.Text text = this._context.Texts.FirstOrDefault(x => x.ID == ID);
            if (text != null)
            {
                this._context.Remove(text);
                this._context.SaveChanges();
            }

        }

        public TextEntity Get(int ID)
        {
            var Text = this._context.Texts.Select(x => new TextEntity()
            {
                ID = x.ID,
                TextContent = x.TextContent,
                DateCreated = x.DateCreated,
                UserID = x.UserID,
            }).FirstOrDefault(x => x.ID == ID);
            return Text;
        }

        public async Task<List<TextEntity>> GetAll()
        {
            var Texts = this._context.Texts.Select(x => new TextEntity()
            {
                ID = x.ID,
                TextContent = x.TextContent,
                DateCreated = x.DateCreated,
                UserID = x.UserID,
            }).OrderByDescending(x => x.DateCreated);
            List<TextEntity> textWithAuthors = new List<TextEntity>();
            foreach (TextEntity text in Texts)
            {
                var creator = await userManager.FindByIdAsync(text.UserID);
                text.UserName = creator.UserName;
                textWithAuthors.Add(text);
            }
            return textWithAuthors;
        }

        public async Task<IQueryable<TextEntity>> GetAllByUserId(ClaimsPrincipal user)
        {
            var UserEntity = await userManager.FindByNameAsync(user.Identity.Name);
            var Texts = this._context.Texts.Where(x => x.UserID == UserEntity.Id).Select(x => new TextEntity()
            {
                ID = x.ID,
                TextContent = x.TextContent,
                DateCreated = x.DateCreated,
                UserID = x.UserID,
            }).OrderByDescending(x => x.DateCreated);
            return Texts;
        }

        public void Update(TextEntity TextModified)
        {
            TextApp.Infrastructure.Texts.Text textToModify = new TextApp.Infrastructure.Texts.Text
            {
                ID = TextModified.ID,
                TextContent = TextModified.TextContent,
                DateCreated = TextModified.DateCreated,
                UserID = TextModified.UserID
            };
            {
                this._context.Texts.Update(textToModify);

            }
        }
    }
}
