using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProftaakASP.App_DAL;
using ProftaakASP.Models;

namespace ProftaakASP.Controllers
{
    public class GenderRepository
    {
        IGenderSQLContext context;

        public GenderRepository(IGenderSQLContext c)
        {
            context = c;
        }

        public List<Gender> getAllGenders()
        {
            return context.getAllGenders();
        }
        public void newGender(Gender g)
        {
            context.newGender(g);
        }

        public void alterGender(Gender g)
        {
            context.alterGender(g);
        }

        public void deleteGender(Gender g)
        {
            context.deleteGender(g);
        }
    }
}