#region Usings

using Rubix.Feature.GDPR.Repository;
using Sitecore.Mvc.Controllers;
using Sitecore.XConnect;
using System;
using System.Web.Mvc;

#endregion

namespace Rubix.Feature.GDPR.Controller
{
    public class GDPRController : SitecoreController
    {
        #region Private Variables

        private IContactRepository _contactRepository;

        #endregion

        #region Constructor
        public GDPRController()
        {
            _contactRepository = new ContactRepository();
        }
        #endregion

        #region Action Methods

        [HttpPost]
        /// <summary>
        /// Get user interaction details.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public ActionResult GetUserInteractionDetails(string identifier)
        {
            try
            {

                if (!string.IsNullOrEmpty(identifier))
                {
                    _contactRepository.AddContactDetails();
                    Contact contactDetails = _contactRepository.GetUserContactDetails(identifier);
                    if (contactDetails != null)
                    {
                        return PartialView("~/Views/GDPR/UserInteractionDetails.cshtml", contactDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(message: ex.Message, exception: ex);
            }
            return View("~/Views/GDPR/UserInteractionDetails.cshtml");
        }

        #endregion

    }
}