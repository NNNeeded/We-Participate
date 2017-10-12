using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProftaakASP.App_DAL;
using ProftaakASP.Models;

namespace ProftaakASP.Controllers
{
    public class FriendsRepository
    {
        private IFriendsContext context;

        public FriendsRepository(IFriendsContext c)
        {
            this.context = c;
        }

        public bool CheckFriends(int x, int y)
        {
            return context.CheckFriends(x, y);
        }

        public void MakeFriends(Account x, Account y)
        {
            context.MakeFriends(x, y);
        }
    }
}