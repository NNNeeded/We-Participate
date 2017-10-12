using System;
using ProftaakASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProftaakASP.App_DAL
{
    public interface ITagContext
    {
        List<Tag> GetAllTags();
        Tag InsertTag(Tag tag);
        bool UpdateTag(Tag tag);
        bool DeleteTag(int id);
        Tag GetTagById(int id);
    }
}