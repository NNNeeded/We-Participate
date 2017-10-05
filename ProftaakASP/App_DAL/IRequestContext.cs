using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProftaakASP.App_DAL
{
    public interface IRequestContext
    {
        List<Request> GetAllRequests();
        Request InsertRequest(Request request);
        bool UpdateRequest(Request request);
        bool DeleteRequest(int id);
        Request GetRequestById(int id);
    }
}
