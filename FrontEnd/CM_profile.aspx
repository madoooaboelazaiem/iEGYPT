<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CM_profile.aspx.cs" Inherits="Company.CM_profile" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
body {
  font-family: "Lato", sans-serif;
}

.sidenav {
  height: 100%;
  width: 160px;
  position: fixed;
  z-index: 1;
  top: 0;
  left: 0;
    background: rgba(37, 80, 138, 0.85);
  background: -webkit-linear-gradient(right,rgba(37, 80, 138, 0.85), rgba(27, 85, 120, 0.85));
  background: -moz-linear-gradient(right,rgba(37, 80, 138, 0.85), rgba(27, 85, 120, 0.85));
  background: -o-linear-gradient(right,rgba(37, 80, 138, 0.85), rgba(27, 85, 120, 0.85));
  background: linear-gradient(to left, rgba(37, 80, 138, 0.85), rgba(27, 85, 120, 0.85));
  overflow-x: hidden;
  padding-top: 20px;
}

.sidenav .linka {
  padding: 6px 8px 6px 16px;
  text-decoration: none;
  font-size: 16px;
  color:#f1f1f1 ;
  display: block;
}
.sidenav .logout {
  padding: 6px 8px 6px 16px;
  text-decoration: none;
  font-size: 16px;
  color:#f1f1f1 ;
  display: block;
}
.sidenav .logout:hover {
  color: red;
}
.sidenav a:hover {
  color: #818181;
}
.imgcontainer {
  text-align: center;
  margin: 24px 0 12px 0;
}
        .info {
              text-align: center;
                text-decoration: none;
                color:rgba(37, 80, 138, 0.85);
                          font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    
                }
img.avatar {
  width: 40%;
  border-radius: 50%;
}

@media screen and (max-height: 450px) {
  .sidenav {padding-top: 15px;}
  .sidenav a {font-size: 18px;}
}
</style>
</head>
<body>
    <form id="form1" runat="server">
          <div class="imgcontainer">
    <img src="imd.jpg" alt="Avatar" class="avatar">
  </div>
<div class="sidenav">
               <asp:HyperLink ID="HyperLink13" 
          navigateurl="ShowNotification.aspx"  CssClass="linka" runat="server">Show Notification</asp:HyperLink>
    
               <asp:HyperLink ID="HyperLink1" 
          navigateurl="milestone3.aspx"  CssClass="linka" runat="server">Funtions</asp:HyperLink>   

              <asp:HyperLink ID="HyperLink5" 
          navigateurl="original_content.aspx" CssClass="linka" runat="server">Search Orignail Content</asp:HyperLink>
          <asp:HyperLink ID="HyperLink6" 
          navigateurl="Show the approved original content.aspx" CssClass="linka" runat="server">the approved original content</asp:HyperLink>
          <asp:HyperLink ID="HyperLink7" 
          navigateurl="Show the contributors.aspx"  CssClass="linka" runat="server">the contributors</asp:HyperLink>
          <asp:HyperLink ID="HyperLink8" 
          navigateurl="Search_Contributor.aspx"  CssClass="linka" runat="server">Search Contributor</asp:HyperLink>
<asp:HyperLink ID="HyperLink9" 
          navigateurl="editcm.aspx"  CssClass="linka" runat="server">Edit</asp:HyperLink>
          <asp:HyperLink ID="HyperLink10" 
          navigateurl="LoginForm.aspx"  CssClass="logout" runat="server">Log out</asp:HyperLink>
</div>
        <asp:Label ID="L1" runat="server" CssClass=""></asp:Label>
        <br>
    <asp:Label id="L2" CssClass=""  runat="server"></asp:Label>
     <br>   <asp:Label id="L3" CssClass="" runat="server"></asp:Label>
       <br> <asp:Label id="L4" CssClass="" runat="server"></asp:Label>
      <br>  <asp:Label id="L5" CssClass="" runat="server"></asp:Label>
         <br>  <asp:Label id="L6" CssClass="" runat="server"></asp:Label>


    </form>
</body>
</html>

