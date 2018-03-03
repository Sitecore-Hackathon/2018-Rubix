#region Usings

using Sitecore.XConnect;

#endregion

namespace Rubix.Feature.GDPR.Repository
{
    public interface IContactRepository
    {
        #region Methods

        /// <summary>
        /// This method returns the contact details based on identifier passed.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        Contact GetUserContactDetails(string identifier);

        /// <summary>
        /// This method is used to add contact details.
        /// </summary>
        void AddContactDetails();

        #endregion
    }
}
