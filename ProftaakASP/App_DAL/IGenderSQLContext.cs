using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProftaakASP.Models;

namespace ProftaakASP.App_DAL
{
    public interface IGenderSQLContext
    {
        List<Gender> getAllGenders();
        void newGender(Gender g);
        void alterGender(Gender g);
        void deleteGender(Gender g);
    }
}
