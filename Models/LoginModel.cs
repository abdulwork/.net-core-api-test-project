using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{/// <summary>
/// 
/// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserPassword { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<LoginModel> Userloginvalues()
        {
            List<LoginModel> objModel = new List<LoginModel>
            {
                new LoginModel { UserName = "user1", UserPassword = "password1" },

                new LoginModel { UserName = "user2", UserPassword = "password2" },

                new LoginModel { UserName = "user3", UserPassword = "password3" },

                new LoginModel { UserName = "user4", UserPassword = "password4" },

                new LoginModel { UserName = "user5", UserPassword = "password5" }
            };
            return objModel;
        }

    }
}
