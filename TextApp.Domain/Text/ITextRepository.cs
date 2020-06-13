using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TextApp.Infrastructure;

namespace TextApp.Domain.Text
{
    public interface ITextRepository
    {
        TextEntity Get(int ID);
        Task<List<TextEntity>> GetAll();

        Task<IQueryable<TextEntity>> GetAllByUserId(ClaimsPrincipal user);

        Task Create(TextEntity Text, ClaimsPrincipal user);

        void Delete(int ID);

        void Update(TextEntity Text);


    }
}
