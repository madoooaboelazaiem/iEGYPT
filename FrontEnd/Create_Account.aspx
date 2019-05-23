<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create_Account.aspx.cs" Inherits="Company.Create_Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
button {
    background-color: rgba(37, 80, 138, 0.85);
    color: white;
    padding: 14px 20px;
    margin: 8px 0;
    border: none;
    cursor: pointer;
    width: 100%;
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
  margin: auto auto 100px;
  padding: 45px;
  text-align: center;
  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
}
.rributton {
  font-family: "Roboto", sans-serif;
border-radius: 12px;
  outline: 0;
  background: rgba(37, 80, 138, 0.85);
  width: 100%;
  border:5px;
  padding: 15px;
  color: #FFFFFF;
  font-size: 14px;

  cursor: pointer;
}
.form button {
  font-family: "Roboto", sans-serif;
border-radius: 12px;
  outline: 0;
  background: rgba(37, 80, 138, 0.85);
  width: 100%;
  border:5px;
  padding: 15px;
  color: #FFFFFF;
  font-size: 14px;

  cursor: pointer;
}
.form button:hover,.form button:active,.form button:focus {
  background: rgba(27, 85, 160, 0.85);
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
}</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="login-page">
  <div class="form">
 
      <p>Select Your Type </p>

            <asp:Button   ID="Button1" runat="server" Text="Viewer" BackColor="#006699" forecolor="White" BorderStyle="None" Height="42px" Width="269px" CssClass="rributton" OnClick="Button1_Click" />

      <br />
      <br />
       <asp:Button   ID="Button2" runat="server" Text="Conributer" BackColor="#006699" forecolor="White" BorderStyle="None" Height="42px" Width="269px" CssClass="rributton" OnClick="Button2_Click" />
    
      <br />
      <br />
       <asp:Button   ID="Button3" runat="server" Text="Autoriezed Reviewer" BackColor="#006699" forecolor="White" BorderStyle="None" Height="42px" Width="269px" CssClass="rributton"  OnClick="Button3_Click"/>
      
      <br />
            <br />
       <asp:Button   ID="Button4" runat="server" Text="Content Manager" BackColor="#006699" forecolor="White" BorderStyle="None" Height="42px" Width="269px" CssClass="rributton" OnClick="Button4_Click" />
     
     
        </div>
</div>
    </form>
    <script>

    </script>
</body>
</html>
