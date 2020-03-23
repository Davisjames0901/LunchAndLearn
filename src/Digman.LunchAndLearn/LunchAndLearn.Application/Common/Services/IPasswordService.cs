namespace LunchAndLearn.Application.Common.Services
{
    public interface IPasswordService
    {
        (string Hash, byte[] Salt) SaltAndHashPassword(string password);
        bool ComparePasswordHash(string password, string hash, byte[] salt);
        bool ComparePasswordHash(string password, string hash);
    }
}