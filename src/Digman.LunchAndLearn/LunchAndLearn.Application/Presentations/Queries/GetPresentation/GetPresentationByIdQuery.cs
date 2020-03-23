    using System.Threading;
    using System.Threading.Tasks;
    using LunchAndLearn.Domain.Entities;
    using LunchAndLearn.Infrastructure.Persist;
    using MediatR;

    namespace LunchAndLearn.Application.Presentations.Queries.GetPresentation
    {
        public class GetPresentationByIdQuery : IRequest<Presentation>
        {
            public class CreatePresentationCommandHandler : IRequestHandler<GetPresentationByIdQuery, Presentation>
            {
                private readonly ApplicationDbContext _context;
            
                public CreatePresentationCommandHandler(ApplicationDbContext context)
                {
                    _context = context;
                }
            
                public Task<Presentation> Handle(GetPresentationByIdQuery request, CancellationToken cancellationToken)
                {
                    return _context.Presentations.FindAsync(request._id).AsTask();
                }
            }

            public GetPresentationByIdQuery(int id)
            {
                _id = id;
            }

            private readonly int _id;
        }
    }