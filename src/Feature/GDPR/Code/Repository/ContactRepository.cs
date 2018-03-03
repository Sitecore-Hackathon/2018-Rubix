#region Usings

using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;
using System;

#endregion

namespace Rubix.Feature.GDPR.Repository
{
    /// <summary>
    /// XDB interaction repository.
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        #region Public Methods

        /// <summary>
        /// This method returns the contact details based on identifier passed.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public Contact GetUserContactDetails(string identifier)
        {
            using (XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var reference = new IdentifiedContactReference("Identifier", identifier);
                    return client.Get<Contact>(reference, new ContactExpandOptions() { });
                }
                catch (XdbExecutionException ex)
                {
                    Sitecore.Diagnostics.Log.Error(message: ex.Message, exception: ex);
                }
            }

            return null;
        }

        /// <summary>
        /// This method adds the contact details in xdb - right now we are passing hardcoded data.
        /// </summary>
        public void AddContactDetails()
        {
            using (Sitecore.XConnect.Client.XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    // New anonymous contact
                    //test
                    var newContact = new Sitecore.XConnect.Contact();
                    client.AddContact(newContact);

                    Guid channelId = Guid.Parse("86c7467a-d019-460d-9fa9-85d6d5d77fc4"); // Replace with real channel ID GUID
                    string userAgent = "Astha Prasad";

                    // Interaction
                    var interaction = new Interaction(newContact, InteractionInitiator.Brand, channelId, userAgent);

                    var fakeItemID = Guid.Parse("5746c4f3-7e16-40d9-ba1d-14c70875724c"); // Replace with real item ID

                    Sitecore.XConnect.Collection.Model.PageViewEvent pageView = new PageViewEvent(DateTime.UtcNow, fakeItemID, 3, "en")
                    {
                        Duration = new TimeSpan(0, 0, 30),
                        Url = "/test/url/test/url?query=testing"
                    };

                    interaction.Events.Add(pageView);

                    client.AddInteraction(interaction);

                    client.Submit();
                }
                catch (XdbExecutionException ex)
                {
                    // Handle exception
                }
            }
        }

        #endregion
    }
}