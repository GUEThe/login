using SqlHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication
{
    /// <summary>
    /// signHandler 的摘要说明
    /// </summary>
    public class signHandler : IHttpHandler
    {
        public string Name;

        public void ProcessRequest(HttpContext context)
        {         
            context.Response.ContentType = "text/html";
            if (context.Request["id"] == "" || context.Request["password"] == "")
            {
                context.Response.Write("<center>帐号或密码输入错误，请重新输入！</center>");
                context.Response.Write("<center><a href='Sign_in.html'><input type='button' value='返回' /></a></center>");
                return;
            }
            if (context.Request["admin"] == "登录")
            {
                long id = Convert.ToInt64(context.Request["id"]);
                long password = Convert.ToInt64(context.Request["password"]);
                DataTable table = SqlHelper.ExecuteDataTable("select * from T_Teachers where ID=@ID and Password=@Password",
                    new SqlParameter("@ID", id),
                    new SqlParameter("@Password", password));
                if (table.Rows.Count == 0)
                {
                    context.Response.Write("<center>帐号或密码输入错误，请重新输入！<br/></center>");
                    context.Response.Write("<center><a href='Sign_in.html'><input type='button' value='返回' /></a></center>");
                }
                else
                {
                    long ID = (long)table.Rows[0]["ID"];
                    string name = (string)table.Rows[0]["Name"];
                    string gender = (string)table.Rows[0]["Gender"];
                    string Position = (string)table.Rows[0]["Position"];
                    context.Response.Write("<center>帐号：" + ID + "<br/><br/>姓名：" + name + "<br/><br/>性别：" + gender + "<br/><br/>职位：" + Position + "<br/><br/></center>");
                    context.Response.Write("<center><a href='Sign_in.html'><input type='button' value='返回登录' /><br/><br/></a><a href='Admin.aspx'><input type='button' value='启用管理员权限' /></a></center>");
                }
                return;
            }
            else
            {
                long id = Convert.ToInt64(context.Request["id"]);
                long password = Convert.ToInt64(context.Request["password"]);
                DataTable table = SqlHelper.ExecuteDataTable("select * from T_Students where ID=@ID and Password=@Password",
                    new SqlParameter("@ID", id),
                    new SqlParameter("@Password", password));
                if (table.Rows.Count == 0)
                {
                    context.Response.Write("<center>帐号或密码输入错误，请重新输入！</center>");
                    context.Response.Write("<center><a href='Sign_in.html'><input type='button' value='返回' /></a></center>");
                }
                else
                {
                    long ID = (long)table.Rows[0]["ID"];
                    string name = (string)table.Rows[0]["Name"];
                    string gender = (string)table.Rows[0]["Gender"];
                    string major = (string)table.Rows[0]["Major"];
                    context.Response.SetCookie(new HttpCookie("id", id.ToString()));
                    context.Response.SetCookie(new HttpCookie("password", password.ToString()));
                    context.Response.Write("<center>帐号：" + ID + "<br/><br/>姓名：" + name + "<br/><br/>性别：" + gender + "<br/><br/>专业：" + major + "<br/><br/></center>");
                    context.Response.Write("<center><a href='Sign_in.html'><input type='button' value='返回登录' /><br/><br/></a><form action='Modifier.ashx' method='post'><input type='submit' name='btn' value='修改信息' /></form><a href='Del.html'><input type='button' value='注销个人帐号' /></a></center>");
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}