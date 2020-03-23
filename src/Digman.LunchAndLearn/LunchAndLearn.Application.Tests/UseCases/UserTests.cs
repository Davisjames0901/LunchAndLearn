// using System.Threading.Tasks;
// using LunchAndLearn.Application.Tests.Utils;
// using LunchAndLearn.Application.Users.Queries.Login;
// using LunchAndLearn.Web;
// using MediatR;
// using Microsoft.Extensions.DependencyInjection;
// using Xunit;
//
// namespace LunchAndLearn.Application.Tests.UseCases
// {
//     public class UserTests : IClassFixture<TestBootstrapper<Startup>>
//     {
//         private readonly TestBootstrapper<Startup> _factory;
//
//         public UserTests(TestBootstrapper<Startup> factory)
//         {
//             _factory = factory;
//         }
//
//         [Fact]
//         public async Task Create()
//         {
//             using var scope = _factory.Services.CreateScope();
//             var mediator = scope.ServiceProvider.GetService<IMediator>();
//             var userCommand = UserTestData.CreateUser;
//
//             var user = await mediator.Send(userCommand);
//             
//             Assert.Equal(userCommand.FirstName, user.FirstName);
//         }
//         
//         [Fact]
//         public async Task Login()
//         {
//             await Create();
//             using var scope = _factory.Services.CreateScope();
//             var mediator = scope.ServiceProvider.GetService<IMediator>();
//             var createUserCommand = UserTestData.CreateUser;
//
//             var user = await mediator.Send(new LoginQuery(createUserCommand.EmailAddress, createUserCommand.Password));
//
//             Assert.Equal(createUserCommand.FirstName, user.FirstName);
//         }
//         
//         [Fact]
//         public async Task InvalidLoginWrongPassword()
//         {
//             using var scope = _factory.Services.CreateScope();
//             var mediator = scope.ServiceProvider.GetService<IMediator>();
//             var createUserCommand = UserTestData.CreateUser;
//
//             var user = await mediator.Send(new LoginQuery(createUserCommand.EmailAddress, "notthistime"));
//
//             Assert.Null(user);
//         }
//         
//         
//         [Fact]
//         public async Task InvalidLoginBadEmail()
//         {
//             using var scope = _factory.Services.CreateScope();
//             var mediator = scope.ServiceProvider.GetService<IMediator>();
//             var createUserCommand = UserTestData.CreateUser;
//
//             var user = await mediator.Send(new LoginQuery("lame", createUserCommand.Password));
//
//             Assert.Null(user);
//         }
//     }
// }