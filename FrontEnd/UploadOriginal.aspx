<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadOriginal.aspx.cs" Inherits="Company.UploadOriginal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>1</title>
</head>
<body>
    <h1 class="title">Original Content </h1>
     <style>h1{
            color:blue;
           text-align: center ;
    }
        </style>
     <form id="form1" runat="server">
        <div  display: inline-block> <p style="height: 33px" style="color:Blue"; font-size:"larger">
	      <p style="color:Blue"; font-size:"larger">  Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		 <asp:TextBox ID="type_id" runat="server"></asp:TextBox>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Types are: 1) Logo 2) UI&nbsp;&nbsp;
     </p>
		<p style="color:Blue"; font-size:"larger">
		    SubCategory Name&nbsp;&nbsp;&nbsp; <asp:TextBox ID="subcategory_name" runat="server"></asp:TextBox>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Subcategories are : 1) Medical 2) Teaching 3) high school (with a space at the beggining)
		</p>
		<p style="color:Blue"; font-size:"larger">
	        Category Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="category_id" runat="server"></asp:TextBox>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Categories are : 1) Tourism 2) Investment 3) Educational
		</p>
		<p  style="color:Blue"; font-size:"larger">
			Link&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="link" runat="server"></asp:TextBox>
		</p>
         </div>
		<p>
			<asp:Button ID="Button1" OnClick="upload" runat="server" Text="Upload"  BackColor="#006699" ForeColor="White" Height="40px" Width="97px"/>
		</p>
         <p>
             <asp:Button ID="Button2" runat="server" Text="HomePage" OnClick="Button2_Click1"  BackColor="#006699" ForeColor="White" Height="41px" Width="116px"/>
         </p>
    </form>
</body>
</html>
