<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteContent.aspx.cs" Inherits="Company.DeleteContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>6</title>
</head>
<body>
    <h1 class="title">Contents </h1>
     <style>h1{
            color:blue;
           text-align: center ;
    }
         </style>
    <form id="form1" runat="server">
   <div style="margin-left:auto; margin-right:auto; text-align: center;width: auto;
    height: auto;font-size:larger"> 

        <asp:GridView ID="contents" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center"  Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="258px" >
            <Columns>
                <asp:BoundField DataField="link" HeaderText ="Link" />
                <asp:BoundField DataField="uploaded_at" HeaderText ="Uploaded At" />
                <asp:BoundField DataField="category_type" HeaderText ="Category Type" />
                <asp:BoundField DataField="subcategory_name" HeaderText ="Subcategory Name" />
                <asp:BoundField DataField="type" HeaderText ="Type" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSelect" Text="Delete" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="lnkSelect_Click"/>
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
                            <RowStyle HorizontalAlign="Center" />

        </asp:GridView>
    </div>
        <p>
        <asp:Button ID="Button2" runat="server" Text="HomePage" OnClick="Button2_Click" BackColor="#006699" ForeColor="White" Height="56px" style="margin-right: 9px" Width="139px"/>
      
        </p>
      
    </form>
</body>
</html>
