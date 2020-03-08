using Coin.Models;

namespace Coin.Services
{
    public interface IUsersService
    {
        bool Register(LoginModel loginModel);
        bool Login(LoginModel loginModel);

        Datum[] GetAllCoins();
    }
}