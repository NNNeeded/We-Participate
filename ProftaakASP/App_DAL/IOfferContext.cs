using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProftaakASP.Models;

namespace ProftaakASP.App_DAL
{
    public interface IOfferContext
    {
        List<Offer> GetAllOffers();
        bool InsertOffer(Offer offer);
        Offer GetOfferInfo(int id);
        bool DeleteOffer(int id);

    }
}
