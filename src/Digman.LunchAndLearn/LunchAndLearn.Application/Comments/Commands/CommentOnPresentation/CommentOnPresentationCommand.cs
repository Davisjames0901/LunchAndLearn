using System.Threading;
using System.Threading.Tasks;
using LunchAndLearn.Domain.Entities;
using LunchAndLearn.Infrastructure.Persist;
using MediatR;

namespace LunchAndLearn.Application.Comments.Commands.CommentOnPresentation
{
    public class CommentOnPresentationCommand : IRequest<Comment>
    {
        public class CommentOnPresentationCommandHandler : IRequestHandler<CommentOnPresentationCommand, Comment>
        {
            private readonly ApplicationDbContext _context;
            
            public CommentOnPresentationCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }
            
            public async Task<Comment> Handle(CommentOnPresentationCommand request, CancellationToken cancellationToken)
            {
                var presentation = await _context.Presentations.FindAsync(request.PresentationId);
                var comment = new Comment
                {
                    Content = request.Content,
                    CreatedByUserId = request.UserId
                };
                presentation.Comments.Add(comment);
                await _context.SaveChangesAsync(cancellationToken);
                return comment;
            }
        }

        public int PresentationId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        
    }
}