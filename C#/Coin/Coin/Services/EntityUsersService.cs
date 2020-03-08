using System.Linq;
using Coin.API;
using Coin.DataBaseLayer;
using Coin.Models;

namespace Coin.Services
{
    public class EntityUsersService : IUsersService
    {
        public bool Login(LoginModel loginModel)
        {
            using (var context = new UserContext())
            {
                var user = context.LoginModels.FirstOrDefault(x => x.Email == loginModel.Email);
                if (user == null)
                {
                    return false;
                }
                if (user.Password == loginModel.Password) return true;
                return false;
            }
        }

        public bool Register(LoginModel loginModel)
        {
            using (var context = new UserContext())
            {
                var user = context.LoginModels.FirstOrDefault(x => x.Email == loginModel.Email);
                if (user == null)
                {
                    context.LoginModels.Add(loginModel);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Datum[] GetAllCoins()
        {
            var coinmodel = CMC.MakeAPICall();
            return coinmodel.data;
        }
    }
}