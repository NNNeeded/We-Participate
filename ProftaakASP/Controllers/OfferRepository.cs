using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProftaakASP.App_DAL;
using ProftaakASP.Models;

namespace ProftaakASP.Controllers
{
    public class OfferRepository
    {
        private IOfferContext context;

        public OfferRepository(IOfferContext i)
        {
            this.context = i;
        }

        public List<Offer> GetAllOffers()
        {
            return context.GetAllOffers();
        }

        public bool InsertOffer(Offer o)
        {
            return context.InsertOffer(o);
        }

        public Offer GetOfferInfo(int id)
        {
            return context.GetOfferInfo(id);
        }

        public bool DeleteOffer(int id)
        {
            return context.DeleteOffer(id);
        }
    }
}