using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotaraPhotographyAssociation.DomainEntities;

namespace TotaraPhotographyAssociation.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string keyInSesn = "cart";

        public object BindModel(ControllerContext ctrlCtxt, ModelBindingContext mCtxt)
        {
            Cart c = null;
            if (ctrlCtxt.HttpContext.Session != null)   // grab cart from session
            {
                c = (Cart)ctrlCtxt.HttpContext.Session[keyInSesn];
            }
            if (c == null)  // there is no cart in session, create it then
            {
                c = new Cart();
                if (ctrlCtxt.HttpContext.Session != null)
                {
                    ctrlCtxt.HttpContext.Session[keyInSesn] = c;
                }
            }
            return c;
        }

    }
}