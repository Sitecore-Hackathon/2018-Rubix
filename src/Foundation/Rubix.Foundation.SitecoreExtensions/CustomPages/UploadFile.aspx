<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="GAF.DXP.Web.Areas.UploadFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:FileUpload id="FileUploadControl" runat="server" />
    <asp:Button runat="server" id="UploadButton" text="Upload Document" onclick="UploadButton_Click" />
          <br /><br />
    <asp:Label runat="server" id="StatusLabel" text="Document URL: " />
   
    </form>
</body>
</html>
