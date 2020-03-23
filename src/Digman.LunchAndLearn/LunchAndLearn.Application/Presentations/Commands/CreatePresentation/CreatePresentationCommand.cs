using System.Threading;
using System.Threading.Tasks;
using LunchAndLearn.Domain.Entities;
using LunchAndLearn.Domain.Enum;
using LunchAndLearn.Infrastructure.Persist;
using MediatR;

namespace LunchAndLearn.Application.Presentations.Commands.CreatePresentation
{
    public class CreatePresentationCommand : IRequest<Presentation>
    {
        public class CreatePresentationCommandHandler : IRequestHandler<CreatePresentationCommand, Presentation>
        {
            private readonly ApplicationDbContext _context;
            
            public CreatePresentationCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }
            
            public async Task<Presentation> Handle(CreatePresentationCommand request, CancellationToken cancellationToken)
            {
                var presentation = new Presentation
                {
                    Description = request.Description,
                    Title = request.Title,
                    CreatedByUserId = request.UserId,
                    State = PresentationState.Proposed
                };
                _context.Presentations.Add(presentation);
                await _context.SaveChangesAsync(cancellationToken);
                return presentation;
            }
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}