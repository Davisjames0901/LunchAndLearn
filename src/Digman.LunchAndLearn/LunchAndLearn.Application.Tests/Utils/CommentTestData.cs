using LunchAndLearn.Application.Comments.Commands.CommentOnPresentation;

namespace LunchAndLearn.Application.Tests.Utils
{
    public static class CommentTestData
    {
        public static CommentOnPresentationCommand CommentOnPresentation => new CommentOnPresentationCommand
        {
            Content = "Test",
            PresentationId = 1,
            UserId = 1
        };
    }
}