using LunchAndLearn.Application.Presentations.Commands.CreatePresentation;

namespace LunchAndLearn.Application.Tests.Utils
{
    public static class PresentationTestData
    {
        public static CreatePresentationCommand CreatePresentation => new CreatePresentationCommand
        {
            Description = "Test",
            Title = "Test"
        };
        
        
    }
}