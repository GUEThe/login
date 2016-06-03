using SqlHelpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication.login
{
    /// <summary>
    /// GL_login 的摘要说明
    /// </summary>
    public class GL_login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            long ID=long.Parse(context.Request["ID"]);
            string Password = context.Request["Password"];
            int count=(int)SqlHelper.ExecuteScalar("select count(*) from T_Students where ID=@ID", new SqlParameter("@ID", ID));
            if (count <= 0)
            {
                context.Response.Write("error_ID");
            }
            else
            {
                int count_2 = (int)SqlHelper.ExecuteScalar("select count(*) from T_Students where ID=@ID and Password=@Password", 
                    new SqlParameter("@ID", ID),
                    new SqlParameter("@Password",Password));
                if (count_2 <= 0)
                {
                    context.Response.Write("error_Pwd");
                }
                else if(count_2==1)
                {
                    context.Response.SetCookie(new HttpCookie("id",ID.ToString()));
                    context.Response.SetCookie(new HttpCookie("password", Password.ToString()));
                    context.Response.Write("right");
                }
                else
                {
                    context.Response.Write("unknow_error");
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