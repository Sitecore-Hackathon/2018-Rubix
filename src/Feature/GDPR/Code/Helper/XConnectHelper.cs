using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rubix.Feature.GDPR.Helper
{
    public static class XConnectHelper
    {
        public static Contact GetContactByIdentifier()
        {
            using (XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var reference = new IdentifiedContactReference("twitter", "myrtlesitecore");

                    return client.Get<Contact>(reference, new ContactExpandOptions() { });
                }
                catch (XdbExecutionException ex)
                {
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }
            }
            return null;
        }
    }
}