<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show the contributors.aspx.cs" Inherits="Company.Show_the_contributors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
        @import url(https://fonts.googleapis.com/css?family=Open+Sans);

        .lbb {
            background-color: white;
              border: none;
        color:steelblue;
        width: 100%;
                          text-align:left;
                  font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                  font-size:large
        }
.search {
  width: 100%;
  position: relative
}



.searchButton {
  position: absolute;  
  
  width: 100%;
  height: 31px;
  border: 1px  ;
  background: rgba(37, 80, 138, 0.85);
  text-align: center;
  color: #fff;
  border-radius: 5px;
  cursor: pointer;
  font-size: 20px;
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
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="wrap">
   <div class="search">
       <asp:Button id="button2" runat="server" Text="Show the Contributer" OnClick="button2Clicked" CssClass="searchButton" />     
   </div>
</div>
        	    <br />
        <br />
        <br />

        <br />
        <asp:Label ID="Label1" runat="server" CssClass="lb" BackColor="White"></asp:Label>
    </form>
</body>
</html>
