<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadNew.aspx.cs" Inherits="Company.UploadNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>5</title>
</head>
<body>
    <h1 class="title">New Content </h1>
     <style>h1{
            color:blue;
           text-align: center ;
    }
         </style>
     <form id="form1" runat="server">
      <div  display: inline-block> <p style="color:Blue"; font-size:"larger">
	         Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;

	         <asp:TextBox ID="type_id" runat="server"></asp:TextBox>
     &nbsp;&nbsp;&nbsp;Types are: 1) Logo 2) UI&nbsp;&nbsp;
              
		<p style="color:Blue"; font-size:"larger">
		    SubCategory Name&nbsp;&nbsp;&nbsp; <asp:TextBox ID="subcategory_name" runat="server"></asp:TextBox>
		&nbsp;&nbsp;&nbsp; Subcategories are : 1) Medical 2) Teaching 3) high school (with a space at the beggining)
		</p>
		<p style="color:Blue"; font-size:"larger">
	        Category Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="category_id" runat="server"></asp:TextBox>
		&nbsp;&nbsp;&nbsp; Categories are : 1) Tourism 2) Investment 3) Educational
		</p>
		<p style="color:Blue"; font-size:"larger">
			Link&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="link" runat="server"></asp:TextBox>
		</p>
          <p style="color:Blue"; font-size:"larger">
			  &nbsp;</p>
         </div>
         <p>
			<asp:Button ID="Button1" OnClick="upload" runat="server" Text="Upload"  BackColor="#006699" ForeColor="White" Height="43px" Width="96px" />
		</p>
         <p>
             <asp:Button ID="Button2" runat="server" Text="HomePage" OnClick="Button2_Click1"   BackColor="#006699" ForeColor="White" Height="47px" Width="126px"/>
         </p>
    </form>
</body>
</html>
