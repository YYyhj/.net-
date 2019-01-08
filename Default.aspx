<%@ Page Language="C#" Dubug="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="News._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
     <form id="form1" runat="server">
    <div>
    
        新闻标题：<asp:TextBox runat="server" ID="Text1" /></div>
    <p>
        作者： 
        <asp:TextBox runat="server" ID="Text2" /></p>
    <p>
                内容：
        <asp:TextBox runat="server" ID="Text3" /></p>
    <p>
        发布时间：<asp:TextBox runat="server" ID="time" /></p></form>
<p>
   <asp:DropDownList ID="Select1" runat="server" AppendDataBoundItems="True" 
                    DataSourceID="News" DataTextField="CategoryName" DataValueField="CategoryId">
                    <asp:ListItem disabled Selected>请选择新闻类型</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="Select" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    SelectCommand="SELECT [CategoryId], [CategoryName] FROM [NewsCategoryName]">
                </asp:SqlDataSource></p>
                   
<input id="Button1" type="button" value="button" />  
    </div>
    </form>
</body>
</html>
