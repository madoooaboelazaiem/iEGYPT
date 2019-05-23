<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiveRequests.aspx.cs" Inherits="Company.ReceiveRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>2</title>
</head>
<body>
    <h1 class="title">New Contents </h1>
    <form id="form1" runat="server">
        <div style="margin-left:auto; margin-right:auto; text-align: center; width:auto;
    height: auto;font-size:larger">
             <asp:GridView ID="contents" runat="server" AutoGenerateColumns="False" Height="205px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"  HorizontalAlign="Center"  Width="100%" >
            <Columns>
                <asp:BoundField DataField="link" HeaderText ="Link" />
                <asp:BoundField DataField="uploaded_at" HeaderText ="Uploaded At" />
                <asp:BoundField DataField="category_type" HeaderText ="Category Type" />
                <asp:BoundField DataField="subcategory_name" HeaderText ="Subcategory Name" />
                <asp:BoundField DataField="type" HeaderText ="Type" />

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSelect" Text="Show Request" runat="server" CommandArgument='<%# Eval("new_request_id") %>' OnClick="lnkSelect_Click"/>
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
     <style>h1{
            color:blue;
           text-align: center ;
    }
         </style>
         <h1 class="title2">Requests </h1>
     <div style="margin-left:auto; margin-right:auto; text-align: center; width:auto;
    height: auto;font-size:larger">
           <div style="margin-left:auto; margin-right:auto;"> <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center"  Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <Columns>
                <asp:BoundField DataField="accept_status" HeaderText ="Request Accept Status" />
                <asp:BoundField DataField="specified" HeaderText ="specified" />
                <asp:BoundField DataField="information" HeaderText ="information" />
                <asp:BoundField DataField="accept_at" HeaderText ="Accepted At" />
                <asp:BoundField DataField="email" HeaderText ="Viewer's Email" />

               
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
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView></div>


            
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="HomePage" BackColor="#006699" ForeColor="White" Height="56px" style="margin-right: 9px" Width="139px"/>
    </form>
</body>
</html>

