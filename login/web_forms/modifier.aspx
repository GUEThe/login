<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modifier.aspx.cs" Inherits="login.web_forms.modifier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../css/style.css" type="text/css" rel="stylesheet"/>
    <title></title>
</head>
<body>
    <div id="listBox">
        <form action="">
        <center>
        <div id="Container">
            <table id="table_left" style="margin: 25px; float: none;">
                <tbody>
                    <tr>
                        <th style="width: 100px">帐号：</th>
                        <td><%=table.Rows[0]["ID"].ToString() %></td>
                    </tr>
                    <tr>
                        <th style="width: 100px">姓名：</th>
                        <td><input type="text" name="Name" value="<%=table.Rows[0]["Name"].ToString() %>" /></td>
                    </tr>
                    <tr>
                        <th style="width: 100px">性别：</th>
                        <td><input type="radio" name="Gender" value="男" />男<input type="radio" name="Gender" value="女" />女</td>
                    </tr>
                    <tr>
                        <th style="width: 100px">专业：</th>
                        <td><input type="text" name="Major" value="<%=table.Rows[0]["Major"].ToString() %>" /></td>
                    </tr>
                </tbody>
            </table>
            <div style="clear: both;">

            </div>
        </div>
        </center>
        <div id="inputBox">
            <input type="button" name="btnRight" value="提交" onclick="window.location.href = '../handler/modifier.aspx';" />
        </div>
      </form>
    </div>
</body>
</html>
