<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="login.web_forms.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/style.css" type="text/css" rel="stylesheet">
    <script type="text/javascript">
        function Confirm_del(id){
            var DelOrNot = confirm("请确认是否删除该用户？");
            if (DelOrNot == true) {
                window.location.href = "Admin.aspx?ID_del=" + id;
            }
            else {
                window.location.href = "Admin.aspx";
            }
        }
    </script>
</head>
<body>
    <div id="listBox">
        <div id="Container">
            <table id="table_left" style="margin:25px;float:none;">
                <tbody>
                    <tr>
                        <th class="t1">序号</th>
                        <th class="t2">帐号</th>
                        <th class="t3">姓名</th>
                        <th class="t3">性别</th>
                        <th class="t3">专业</th>
                    </tr>
                 <% for (int i = 0; i < table.Rows.Count; i++)
               { %>
            <tr>
                <td><%=i+1 %></td>
                <td id="id_<%=i+1 %>"><%=table.Rows[i]["ID"].ToString() %></td>
                <td><%=table.Rows[i]["Name"].ToString() %></td>
                <td><%=table.Rows[i]["Gender"].ToString() %></td>
                <td><%=table.Rows[i]["Major"].ToString() %></td>
                <% long ID = long.Parse(table.Rows[i]["ID"].ToString()); %>
                <th><input type="button" value="删除" onclick="Confirm_del(<%=ID%>)" /></th>
            </tr>
            <%} %>  

                </tbody>
            </table>
            <div style="clear:both;"></div>
        </div>
    </div>
</body>
</html>
