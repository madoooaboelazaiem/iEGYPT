<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="milestone3.aspx.cs" Inherits="Company.milestone3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 1941px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create Type" />
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" Width="125px">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Get the original Contents" Width="216px" />
        <br />
&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList9" runat="server">
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="filter" />
        <br />
        <br />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList10" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button19" runat="server" OnClick="Button19_Click" Text="get the original contents " />
        <br />
        <asp:DropDownList ID="DropDownList11" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>0</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button20" runat="server" OnClick="Button20_Click" Text="filter" />
        <br />
        <br />
        <br />
        <br />
        <br />
&nbsp;<asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Create Category" />
        <br />
&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Enter The category"></asp:Label>
        <br />
&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Select Category"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="175px">
        </asp:DropDownList>
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="show" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Enter SubCategory"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Create SubCategory" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Most Req Content" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="number of new and existing requests" />
        <br />
        <br />
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="Button21" runat="server" OnClick="Button21_Click" Text="Order the contributors" />
        <br />
        <asp:GridView ID="GridView3" runat="server">
        </asp:GridView>
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="date" HeaderText="date" ReadOnly="True" SortExpression="date" />
                <asp:BoundField DataField="text" HeaderText="text" ReadOnly="True" SortExpression="text" />
                <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" OnClientClick="" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="SELECT [date], [text] FROM [Comment]" DeleteCommand="DELETE From [Comment] where [date]=date and [text]=text"><DeleteParameters><asp:Parameter name="date" Type="DateTime" /><asp:Parameter name="text" Type="String"/></DeleteParameters></asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList5" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="get the original content" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button14" runat="server" OnClick="Button14_Click" Text="delete the original content" />
        <br />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList6" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button13" runat="server" OnClick="Button13_Click" Text="get the new content" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button15" runat="server" Text="delete the new content" OnClick="Button15_Click" />
        <br />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList7" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button16" runat="server" OnClick="Button16_Click" Text="get contributers" />
        <asp:DropDownList ID="DropDownList8" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button17" runat="server" OnClick="Button17_Click" Text="get new requests" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button18" runat="server" OnClick="Button18_Click" Text="assign" />
    </form>
</body>
</html>
