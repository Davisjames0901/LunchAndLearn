using System.Linq;
using System.Threading.Tasks;
using LunchAndLearn.Application.Presentations.Queries.GetPresentation;
using LunchAndLearn.Application.Tests.Utils;
using LunchAndLearn.Web;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LunchAndLearn.Application.Tests.UseCases
{
    public class CommentTests : IClassFixture<TestBootstrapper<Startup>>
    {
        private readonly TestBootstrapper<Startup> _factory;
        public CommentTests(TestBootstrapper<Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task Create()
        {
            using var scope = _factory.Services.CreateScope();
            var mediator = scope.ServiceProvider.GetService<IMediator>();
            var commentCommand = CommentTestData.CommentOnPresentation;
            
            var presentation = await mediator.Send(PresentationTestData.CreatePresentation);
            commentCommand.PresentationId = presentation.Id;
            
            var comment = await mediator.Send(commentCommand);
            presentation = await mediator.Send(new GetPresentationByIdQuery(presentation.Id));
            
            Assert.Single(presentation.Comments);
            Assert.Equal(comment.Id, presentation.Comments.First().Id);
        }

    }
}