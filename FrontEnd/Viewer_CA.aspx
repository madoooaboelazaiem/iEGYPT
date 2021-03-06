﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viewer_CA.aspx.cs" Inherits="Company.Viewer_CA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title><style>
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

.form button:hover,.form button:active,.form button:focus {
  background: #43A047;
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
 .form button {
  font-family: "Roboto", sans-serif;
  outline: 0;
  background: #4CAF50;
  width: 100%;
  border: 0;
  padding: 15px;
  color:aqua;
  font-size: 14px;
  cursor: pointer;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="login-page">
  <div class="form">
       <input id="fnamet" type="text" placeholder="First Name" required="required" runat="server"/>
      <input id="mnamet" type="text" placeholder="Middle Name"  runat="server" />
      <input id="lnmaet" type="text" placeholder="Last Name" required="required" runat="server"/>
      <input id="dobt" type="text" name="input" placeholder="YYYY-MM-DD"   runat="server"/>
      <input id="Emailt" type="text" placeholder="Email" required="required" runat="server"/>
      <input id="passwordt" type="password" placeholder="password" required="required" runat="server"/>
       <input id="Wt" type="text" placeholder="Working Place"  runat="server"/>
       <input id="Wtypet" type="text" placeholder="Working Place Type" runat="server" />
       <input id="Wdest" type="text" placeholder="Working PLace Description" runat="server" />
            <asp:Button   ID="Button1" runat="server" Text="Submit" BackColor="#006699" forecolor="White"  OnClick="Button1_Click" />
      <asp:Label ID="L1" runat="server" Text="Label"></asp:Label>
   
        </div>
</div>
    </form>
</body>
</html>
