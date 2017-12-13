using ProftaakASP.App_DAL;
using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Controllers
{
    public class AccountRepository
    {
        //Roep de interface aan die je wilt gebruiken in je repository
        private IAccountContext context;

        //Implement de account interface in de repository
        public AccountRepository (IAccountContext context)
        {
            this.context = context;
        }

        //Zorg dat de lijst van objecten doorgestuurd kan worden door de context
        public List<Account> GetAllAccounts()
        {
            return context.GetAllAccounts();
        }

        public Account InsertAccount(Account account)
        {
            return context.InsertAccount(account);
        }

        public bool UpdateAccount(Account account)
        {
            return context.UpdateAccount(account);
        }

        public bool DeleteAccount(int id)
        {
            return context.DeleteAccount(id);
        }

        public Account GetAccountById(int id)
        {
            return context.GetAccountById(id);
        }

        public Account Login(string username, string password)
        {
            return context.Login(username, password);
        }

        public List<Account> GetAllFriendedAccounts(int id)
        {
            return context.GetAllFriendedAccounts(id);
        }
    }
}