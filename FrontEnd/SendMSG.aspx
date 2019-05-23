<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMSG.aspx.cs" Inherits="Company.SendMSG" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>4</title>
</head>
<body>
     <h1 class="title"> Messages </h1>
     
     <style>h1{
            color:blue;
           text-align: center ;
    }
         </style>

    <form id="form1" runat="server">
        <div style="margin-left:auto; margin-right:auto; text-align: center;width: auto;
    height: auto;font-size:larger">
        <asp:GridView ID="MSG" runat="server" AutoGenerateColumns="False" Height="200px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" HorizontalAlign="Center"  Width="100%" >
            <Columns>
                <asp:BoundField DataField="email" HeaderText ="Viewer's Email" />
                <asp:BoundField DataField="first_name" HeaderText ="First Name" />
                <asp:BoundField DataField="middle_name" HeaderText ="Middle Name" />
                <asp:BoundField DataField="last_name" HeaderText ="Last Name" />

                
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSelect" Text="Select Destination of MSG" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="Select"/>

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
     <div> <p style="height: 178px; width: 398px;">

	 &nbsp;<asp:TextBox id="msgcontent" TextMode="multiline" Columns="50" Rows="5" runat="server" Height="166px" style="margin-top: 0px" Width="383px" />
         
			&nbsp;&nbsp;
        
     
    </div> 
     
         <p>
             <asp:Button ID="Send" runat="server" Text="Send" OnClick="upload" BackColor="#006699" ForeColor="White" Height="56px" style="margin-right: 9px" Width="139px"/>
         </p>
        <p>
             &nbsp;</p>
        <h1 class="title"> Received MSGs </h1>
        <div style="margin-left:auto; margin-right:auto; text-align: center;width: auto;
    height: auto;font-size:larger">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="200px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" HorizontalAlign="Center"  Width="100%" >
            <Columns>
                <asp:BoundField DataField="email" HeaderText ="From" />
                <asp:BoundField DataField="sent_at" HeaderText ="Received At" />
                <asp:BoundField DataField="read_at" HeaderText ="Read At" />
                <asp:BoundField DataField="text" HeaderText ="Content of MSG" />                

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
             <asp:Button ID="Button2" runat="server" Text="HomePage" OnClick="Button2_Click1" BackColor="#006699" ForeColor="White" Height="56px" style="margin-right: 9px" Width="139px"/>
         </p>
    </form>
</body>
</html>
