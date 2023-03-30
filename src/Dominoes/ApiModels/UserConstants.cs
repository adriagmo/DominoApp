using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominoes.ApiModels
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
        {
            new UserModel() { Username = "userTest", Password = "password" }
        };
    }
}
