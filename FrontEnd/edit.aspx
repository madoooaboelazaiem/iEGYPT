<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Company.edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Email</p>
            <asp:TextBox id="emailTB" runat="server"/>
            <br>
            <p>Password</p>
            <asp:TextBox id="passwordTB" runat="server"/>
            <br>
            <p>First Name</p>
            <asp:TextBox id="fnameTB" runat="server"/>
            <br>
            <p>Middle Name</p>
            <asp:TextBox id="mnameTB" runat="server"/>0
            <br>
            <p>Last Name</p>
            <asp:TextBox id="lnameTB" runat="server"/>
            <br>
            <p>Birth Date</p>
            <asp:TextBox id="birthdateTB" runat="server"/>
            <br>
            <p>Working Place Name</p>
            <asp:TextBox id="worknameTB" runat="server"/>
            <br>
            <p>Working Place Type</p>
            <asp:TextBox id="worktypeTB" runat="server"/>
            <br>
            <p>Working Place Description</p>
            <asp:TextBox id="workdiscTB" runat="server"/>
            <br>
            <p>Specilization</p>
            <asp:TextBox id="specilizationTB" runat="server"/>
            <br>
            <p>portofolio Link</p>
            <asp:TextBox id="portofolio_linkTB" runat="server"/>
            <br>
            <p>Years Experience</p>
            <asp:TextBox id="years_experienceTB" runat="server"/>
            <br>
            <p>Hire Date</p>
            <asp:TextBox id="hire_dateTB" runat="server"/>
            <br>
            <p>Working Hours</p>
            <asp:TextBox id="working_hoursTB" runat="server"/>
            <br>
            <p>Payment Rate</p>
            <asp:TextBox id="payment_rateTB" runat="server"/>
            <br>
            
            <asp:Button id="B1" runat="server" OnClick="Editing" Text="Save"/>
            <asp:Button id="B2" runat="server" OnClick="deactivate" Text="Deactivate"/>
            <asp:Label id="L1" runat="server"  />
        </div>
    </form>
</body>
</html>
