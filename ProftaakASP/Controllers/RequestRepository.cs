using ProftaakASP.App_DAL;
using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Controllers
{
    public class RequestRepository
    {
        //Roep de interface aan die je wilt gebruiken in je repository
        private IRequestContext context;

        //Implement de request interface in de repository
        public RequestRepository(IRequestContext context)
        {
            this.context = context;
        }

        public List<Request> GetAllRequests()
        {
            return context.GetAllRequests();
        }

        public Request InsertRequest(Request request)
        {
            return context.InsertRequest(request);
        }

        public bool UpdateRequest(Request request)
        {
            return context.UpdateRequest(request);
        }

        public bool DeleteRequest(int id)
        {
            return context.DeleteRequest(id);
        }

        public Request GetRequestById(int id)
        {
            return context.GetRequestById(id);
        }
    }
}