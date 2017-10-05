using ProftaakASP.App_DAL;
using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Controllers
{
    public class LoginRepository
    {
        //Ik maak gebruik van de account interface omdat in de accountsqlcontext mijn login query staat.
        private readonly IAccountContext context;

        //Implement de account interface in de login repository
        public LoginRepository(IAccountContext context)
        {
            this.context = context;
        }

        //Zorg dat het object doorgestuurd kan worden door de context
        public Account Login(string username, string password)
        {
            return context.Login(username, password);
        }
    }
}