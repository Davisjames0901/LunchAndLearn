using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LunchAndLearn.Infrastructure.Persist;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LunchAndLearn.Application.Users.Queries.GetUser
{
    public class GetUserByEmailQuery : IRequest<IdentityUser>
    {
        public class CreatePresentationCommandHandler : IRequestHandler<GetUserByEmailQuery, IdentityUser>
        {
            private readonly ApplicationDbContext _context;
            public CreatePresentationCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }
            
            public Task<IdentityUser> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
            {
                return _context.Users.FirstOrDefaultAsync(x => x.Email == request._email, cancellationToken);
            }
        }
        
        
        public GetUserByEmailQuery(string email)
        {
            _email = email;
        }

        private readonly string _email;
    }
}