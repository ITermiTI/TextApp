using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TextApp.Domain.Text;
using TextApp.Infrastructure;

namespace TextApp.Presentation.Text
{
    public class TextPresentationRepository : ITextPresentationRepository
    {

        public ITextRepository TextRepository { get; }
        public TextPresentationRepository(ITextRepository textRepository)
        {
            TextRepository = textRepository;
        }


        public async Task AddText(TextDto textDto, ClaimsPrincipal user)
        {
            await TextRepository.Create(new Infrastructure.TextEntity { TextContent = textDto.TextContent, DateCreated = DateTime.Now }, user);
        }

        public void DeleteText(int ID)
        {
            TextRepository.Delete(ID);
        }

        public TextDto Get(int ID)
        {
            TextApp.Infrastructure.TextEntity text = TextRepository.Get(ID);
            return new TextDto
            {
                ID = text.ID,
                TextContent = text.TextContent,
                DateCreated = text.DateCreated,
            };
        }

        public async Task<IEnumerable<TextDto>> GetAll()
        {
            List<TextEntity> texts = await TextRepository.GetAll();
            List<TextDto> textDtos = new List<TextDto>();
            foreach (TextEntity text in texts)
            {
                textDtos.Add(new TextDto { ID = text.ID, DateCreated = text.DateCreated, TextContent = text.TextContent, CreatorName = text.UserName });


            }
            return textDtos;

        }

        public async Task<IEnumerable<TextDto>> GetAllUsersText(ClaimsPrincipal user)
        {
            IQueryable<TextApp.Infrastructure.TextEntity> texts = await TextRepository.GetAllByUserId(user);
            List<TextDto> textDtos = new List<TextDto>();
            foreach (Infrastructure.TextEntity text in texts.ToList())
            {
                textDtos.Add(new TextDto { ID = text.ID, DateCreated = text.DateCreated, TextContent = text.TextContent, CreatorName = text.UserName });


            }
            return textDtos;
        }
    }
}
