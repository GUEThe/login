using SqlHelpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace login.handler
{
    /// <summary>
    /// modifier 的摘要说明
    /// </summary>
    public class modifier : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpCookie id = context.Request.Cookies["id"];
            HttpCookie password = context.Request.Cookies["password"];
            long ID = long.Parse(id.Value);
            long Password = long.Parse(password.Value);
            context.Response.SetCookie(new HttpCookie("password", context.Request["Password"].ToString()));
            int row=SqlHelper.ExecuteNonQuery("Update T_Students set Name=@Name,Gender=@Gender,Major=@Major,Password=@Password where ID=@ID and Password=@Psd",
                    new SqlParameter("@Name", context.Request["Name"]),
                    new SqlParameter("@Gender", context.Request["Gender"]),
                    new SqlParameter("@Major", context.Request["Major"]),
                    new SqlParameter("@Password", context.Request["Password"]),
                    new SqlParameter("@ID",ID),
                    new SqlParameter("@Psd", Password));
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