using System;
using ProftaakASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProftaakASP.App_DAL
{
    public interface IRequestTagContext
    {
        List<RequestTag> GetAllRequestTags();
        RequestTag InsertRequestTag(RequestTag requesttag);
        bool UpdateRequestTag(RequestTag requesttag);
        bool DeleteRequestTag(int id);
        RequestTag GetRequestTagById(int id);
    }
}