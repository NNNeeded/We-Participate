using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Controllers
{
    public class ViewModelCreateMessage
    {
        public Message message;
        public List<Account> accounts = new List<Account>();
        public Account account;
    }
}