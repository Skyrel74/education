using Coin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Coin.DataBaseLayer
{
    public class UserContext : DbContext
    {
        public UserContext() : base("Coin")
        {

        }
        public DbSet<LoginModel> LoginModels { get; set; }
    }
}