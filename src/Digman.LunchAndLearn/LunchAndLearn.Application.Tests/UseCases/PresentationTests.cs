using System.Threading.Tasks;
using LunchAndLearn.Application.Presentations.Commands.CreatePresentation;
using LunchAndLearn.Application.Presentations.Queries.GetPresentation;
using LunchAndLearn.Application.Tests.Utils;
using LunchAndLearn.Web;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LunchAndLearn.Application.Tests.UseCases
{
    public class PresentationTests : IClassFixture<TestBootstrapper<Startup>>
    {
        private readonly TestBootstrapper<Startup> _factory;
        public PresentationTests(TestBootstrapper<Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task Create()
        {
            using var scope = _factory.Services.CreateScope();
            var mediator = scope.ServiceProvider.GetService<IMediator>();
            var presentationCommand = PresentationTestData.CreatePresentation;
            var response = await mediator.Send(presentationCommand);
            Assert.Equal(presentationCommand.Title, response.Title);
        }

        [Fact]
        public async Task Get()
        {
            using var scope = _factory.Services.CreateScope();
            var mediator = scope.ServiceProvider.GetService<IMediator>();
            var response = await mediator.Send(new GetPresentationByIdQuery(1));
            Assert.NotNull(response);
        }
    }
}