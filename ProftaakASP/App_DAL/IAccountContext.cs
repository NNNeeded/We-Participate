using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProftaakASP.App_DAL
{
    public interface IAccountContext
    {
        //In de interface geef je alle methodes aan die gebruikt worden in de SQLContext en de repository
        List<Account> GetAllAccounts();
        Account InsertAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(int id);
        Account GetAccountById(int id);
        Account Login(string username, string password);
    }
}
