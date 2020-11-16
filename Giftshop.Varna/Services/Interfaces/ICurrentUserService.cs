namespace Giftshop.Varna.Services
{
    public interface ICurrentUserService
    {
        long GetCurrentUserId();
        bool IsAdministrator();
    }
}