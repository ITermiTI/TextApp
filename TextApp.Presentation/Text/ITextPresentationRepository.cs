using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TextApp.Presentation.Text
{
    public interface ITextPresentationRepository
    {
        Task AddText(TextDto textDto, ClaimsPrincipal user);
        TextDto Get(int ID);
        Task<IEnumerable<TextDto>> GetAll();
        Task<IEnumerable<TextDto>> GetAllUsersText(ClaimsPrincipal user);

        void DeleteText(int ID);

    }
}
