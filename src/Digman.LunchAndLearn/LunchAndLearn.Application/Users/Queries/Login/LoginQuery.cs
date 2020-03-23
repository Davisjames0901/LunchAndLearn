using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LunchAndLearn.Application.Common.Services;
using LunchAndLearn.Infrastructure.Persist;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LunchAndLearn.Application.Users.Queries.Login
{
    public class LoginQuery : IRequest<IdentityUser>
    {
        public class CreatePresentationCommandHandler : IRequestHandler<LoginQuery, IdentityUser>
        {
            private readonly ApplicationDbContext _context;
            private readonly IPasswordService _passwordService;
            public CreatePresentationCommandHandler(ApplicationDbContext context, IPasswordService passwordService)
            {
                _context = context;
                _passwordService = passwordService;
            }
            
            public async Task<IdentityUser> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request._email, cancellationToken);
                if (user == null) return null;
                return _passwordService.ComparePasswordHash(request._password, user.PasswordHash) ? user : null;
            }
        }
        
        
        public LoginQuery(string email, string password)
        {
            _email = email;
            _password = password;
        }

        private readonly string _email;
        private readonly string _password;
    }
}