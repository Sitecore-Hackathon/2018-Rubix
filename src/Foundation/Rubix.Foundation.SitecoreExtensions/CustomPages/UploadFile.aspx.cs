using System;
using System.IO;
using GAF.DXP.Web.Framework.Extentions.Actions;
using Sitecore.Pipelines.Attach;
using System.Web;

namespace GAF.DXP.Web.Areas
{
    public partial class UploadFile : System.Web.UI.Page
    {



        protected void UploadButton_Click(object sender, EventArgs e)
        {
          
            if (FileUploadControl.HasFile)
            {
                HttpPostedFile postedFile = FileUploadControl.PostedFile;
                AzureStorageUpload azureUpload = new AzureStorageUpload();
               string outPut= azureUpload.UploadMediaToAzure(postedFile);
                StatusLabel.Text = "Document URL:" + outPut  ;
            }

            
        }
    }
}