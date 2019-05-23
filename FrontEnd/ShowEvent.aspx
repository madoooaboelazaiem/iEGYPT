<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowEvent.aspx.cs" Inherits="Company.ShowEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>8</title>
</head>
<body>
     <h1 class="title">Events </h1>
     <style>h1{
            color:blue;
           text-align: center ;
    }
         </style>  
    <form id="form1" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align: center;width: auto;
    height: auto;font-size:larger">
           
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="200px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"  HorizontalAlign="Center"  Width="100%" >
            <Columns>
                <asp:BoundField DataField="description" HeaderText ="description"  />
                <asp:BoundField DataField="location" HeaderText ="location"  />
                <asp:BoundField DataField="city" HeaderText ="city"  />
                <asp:BoundField DataField="time" HeaderText ="time"  />
                <asp:BoundField DataField="entertainer" HeaderText ="entertainer" /> 
                <asp:BoundField DataField="email" HeaderText ="Viewer's Email" />
                <asp:BoundField DataField="first_name" HeaderText ="Viewer's First Name" />
                <asp:BoundField DataField="middle_name" HeaderText ="Viewer's Middle Name" />
                <asp:BoundField DataField="last_name" HeaderText ="Viewer's Last Name" /> 
                            
                



               
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    
            
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="HomePage" BackColor="#006699" ForeColor="White" Height="56px" style="margin-right: 9px" Width="139px"/>
        </p>
    </form>
</body>
</html>

