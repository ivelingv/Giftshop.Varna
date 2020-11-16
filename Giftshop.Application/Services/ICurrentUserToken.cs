namespace Giftshop.Application.Services
{
    public interface ICurrentUserTokenService
    {
        string GetToken();
        void SetToken(string token);
    }
}