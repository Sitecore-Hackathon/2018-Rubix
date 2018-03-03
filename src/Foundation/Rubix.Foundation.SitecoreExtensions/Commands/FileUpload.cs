using Sitecore.Shell.Framework.Commands;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;

namespace GAF.DXP.Web.Framework.Extentions.Commands
{
    public class AzureBlobUpload : Command
    {
        public override void Execute(CommandContext context)
        {
          
            // UrlString url = new UrlString( "open.aspx");
            SheerResponse.ShowModalDialog(new UrlString("/Areas/Custom Pages/UploadFile.aspx").ToString(), "600", "300");

        }
    }
}
