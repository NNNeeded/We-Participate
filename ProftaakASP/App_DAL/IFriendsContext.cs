using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProftaakASP.App_DAL;
using ProftaakASP.Models;

namespace ProftaakASP.App_DAL
{
    public interface IFriendsContext
    {
        bool CheckFriends(int x, int y);
        void MakeFriends(Account x, Account y);
    }
}
