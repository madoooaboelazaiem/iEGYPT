<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcceptRejectRequest.aspx.cs" Inherits="Company.AcceptRejectRequest" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <h1 class="title">New Requests </h1>
     <style>h1{
            color:blue;
           text-align: center ;
    }
         </style>
    <form id="form1" runat="server">
     <div style="margin-left:auto; margin-right:auto; text-align: center;width: auto;
    height: auto;font-size:larger">
        <asp:GridView ID="Requests" runat="server" AutoGenerateColumns="False" Height="200px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" HorizontalAlign="Center"  Width="100%" >
            <Columns>
                <asp:BoundField DataField="accept_status" HeaderText ="Accept Status" />
                <asp:BoundField DataField="specified" HeaderText ="Specified" />
                <asp:BoundField DataField="information" HeaderText ="Information" />
                <asp:BoundField DataField="accept_at" HeaderText ="Accept At" />
                <asp:BoundField DataField="email" HeaderText ="Viewer's Email" />

                
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSelect" Text="Accept" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="Accept_Click"/>
                        <asp:LinkButton ID="lnkSelect2" Text="Reject" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="Reject_Click"/>

                    </ItemTemplate>
                </asp:TemplateField>
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
        <asp:Button ID="Button2" runat="server" Text="HomePage" OnClick="Button2_Click" BackColor="#006699" ForeColor="White" Height="56px" style="margin-right: 9px" Width="139px"/>
      
        </p>
      
    </form>
</body>
</html>

