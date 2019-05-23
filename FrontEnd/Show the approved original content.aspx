<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show the approved original content.aspx.cs" Inherits="Company.Show_the_approved_original_content" %>

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

.searchTerm {
  float: left;
  width: 97%;
  border: 3px ;
  padding: 5px;
  height: 20px;
  border-radius: 5px;
  outline: none;
  color: #9DBFAF;
}

.searchTerm:focus{
  color: #00B4CC;
}

.searchButton {
  position: absolute;  
  right: -50px;
  width: 80px;
  height: 31px;
  border: 1px  ;
  background: rgba(37, 80, 138, 0.85);
  text-align: center;
  color: #fff;
  border-radius: 5px;
  cursor: pointer;
  font-size: 20px;
}
   .list .itemsOne
        {
            background-color: #eee;
            color:cadetblue;
              padding: 10px;

            
        }
      .list .itemsOne
        {
            background-color: #eee;
            color:cadetblue;
              padding: 10px;
        width:40px;
            height:60px;
        }
 .list .itemsOne:hover {
  background: #eee;

}

        .list
        {
            font-size: x-large;
   border: 0;
           list-style-type: none;
             border-radius: 5px;
            overflow:auto;
        }

/*Resize the wrap to see the search bar change!*/
.wrap{
  width: 80%;
  position: absolute;
  top: 5%;
  left: 50%;
  transform: translate(-50%, -50%);
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
      <input  id="tfullname1" type="text" class="searchTerm" placeholder="Full Name.."  runat="server" >
       <asp:Button id="button2" runat="server" Text="Search" OnClick="button2Clicked" CssClass="searchButton" />
     
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
