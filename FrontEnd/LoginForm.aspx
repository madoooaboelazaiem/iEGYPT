<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Company.LoginForm" %>

<!DOCTYPE html>

<html >
<head runat="server">
    <title></title>
    <script>
/* When the user clicks on the button,
toggle between hiding and showing the dropdown content */
function myFunction() {
  document.getElementById("myDropdown").classList.toggle("show");
}
    
</script>
    <style>
        @import url(https://fonts.googleapis.com/css?family=Roboto:300);
.dropbtn {
    background-color: rgba(37, 80, 138, 0.85);
        border-radius: 60%;

   width: 100%;
  color: white;
  padding: 16px;
  font-size: 16px;
  border: none;
  cursor: pointer;
}

.dropdown {
  position: relative;
  display: inline-block;
            top: 0px;
            left: 0px;
            height: 44px;
        }

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f9f9f9;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  z-index: 1;
}

.dropdown-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}
.ber {
    background-color: rgba(37, 80, 138, 0.85);
    color: white;
    padding: 14px 20px;
    margin: 8px 0;
    border: none;
    cursor: pointer;
    width: 100%;
}

button:hover {
    opacity: 0.8;
}
.dropdown-content a:hover {background-color: #f1f1f1}

.dropdown:hover .dropdown-content {
  display: block;
}

.dropdown:hover .dropbtn {
  background-color: rgba(18, 80, 128, 0.85);
}
.login-page {
  width: 360px;
  padding: 8% 0 0;
  margin: auto;
}
.form {
  position: relative;
  z-index: 1;
  background: #FFFFFF;
  max-width: 360px;
  margin: 0 auto 100px;
  padding: 45px;
  text-align: center;
  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
}
.form input {
  font-family: "Roboto", sans-serif;
  outline: 0;
  background: #f2f2f2;
  width: 100%;
  border: 0;
  margin: 0 0 15px;
  padding: 15px;
  box-sizing: border-box;
  font-size: 14px;
}
.form button {
  font-family: "Roboto", sans-serif;
  text-transform: uppercase;
  outline: 0;
  background: rgba(37, 80, 138, 0.85);
  width: 100%;
  border: 0;
  padding: 15px;
  color: #FFFFFF;
  font-size: 14px;

  cursor: pointer;
}
.form button:hover,.form button:active,.form button:focus {
  background: rgba(18, 80 ,127, 0.85);
}
.form .message {
  margin: 15px 0 0;
  color: #b3b3b3;
  font-size: 12px;
}
.form .message a {
  color: rgba(37, 80, 138, 0.85);
  text-decoration: none;
}

body {
  background: rgba(37, 80, 138, 0.85); /* fallback for old browsers */
  background: -webkit-linear-gradient(right,rgba(37, 80, 138, 0.85), rgba(27, 85, 120, 0.85));
  background: -moz-linear-gradient(right,rgba(37, 80, 138, 0.85), rgba(27, 85, 120, 0.85));
  background: -o-linear-gradient(right,rgba(37, 80, 138, 0.85), rgba(27, 85, 120, 0.85));
  background: linear-gradient(to left, rgba(37, 80, 138, 0.85), rgba(27, 85, 120, 0.85));
  font-family: "Roboto", sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;      
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dropdown">
  <button onclick="myFunction()" class="dropbtn">Menu</button>
  <div id="myDropdown" class="dropdown-content">
          <asp:HyperLink ID="HyperLink1" 
          navigateurl="original_content.aspx" runat="server">Search_Orignail_Content</asp:HyperLink>
          <asp:HyperLink ID="HyperLink2" 
          navigateurl="Show the approved original content.aspx"  runat="server">the approved original content</asp:HyperLink>
          <asp:HyperLink ID="HyperLink4" 
          navigateurl="Show the contributors.aspx" runat="server">the contributors</asp:HyperLink>
          <asp:HyperLink ID="HyperLink5" 
          navigateurl="Search_Contributor.aspx"  runat="server">Search_Contributor</asp:HyperLink>
  </div>
</div>
    <div class="login-page">
  <div class="form">
 
      <input id="email_login" type="text" placeholder="Email" runat="server"/>
      <input id="Password1" type="password" placeholder="password" runat="server"/>
              <asp:Button  class="dropbtn" id="button2" runat="server" Text="Login" OnClick="button2Clicked" CssClass="ber" BackColor="#336699" />




      <p class="message">Not registered? <asp:HyperLink ID="HyperLink8" 
          navigateurl="Create_Account.aspx"  runat="server">Create Account</asp:HyperLink></p>
      <p class="message">


      </p>
      <asp:Label  id="L1" runat="server" CssClass="message"/>
        </div>
</div>

    </form>


</body>
</html>
