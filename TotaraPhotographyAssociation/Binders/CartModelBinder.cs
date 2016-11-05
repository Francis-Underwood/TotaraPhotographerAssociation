using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotaraPhotographyAssociation.DomainEntities;

namespace TotaraPhotographyAssociation.Binders
{
    /*
     * Vincent: a customized model binder 
     * On each request, it automatically grabs Cart object from session,
     * and bind it to the cart parameter in the controllers execution context 
     */ 
    public class CartModelBinder : IModelBinder
    {
        private const string keyInSesn = "cart";

        public object BindModel(ControllerContext ctrlCtxt, ModelBindingContext mCtxt)
        {
            Cart c = null;

            // Vincent: try to grab the cart object from session
            if (ctrlCtxt.HttpContext.Session != null)   
            {
                c = (Cart)ctrlCtxt.HttpContext.Session[keyInSesn];
            }

            // Vincent: there is no cart in session 
            if (c == null)  
            {
                // Vincent: create it then
                c = new Cart();
                // Vincent: and store it in the session
                if (ctrlCtxt.HttpContext.Session != null)
                {
                    ctrlCtxt.HttpContext.Session[keyInSesn] = c;
                }
            }
            return c;
        }

    }
}