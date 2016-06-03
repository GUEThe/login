using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace login.handler
{
    /// <summary>
    /// admin_ajax 的摘要说明
    /// </summary>
    public class admin_ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpCookie id = context.Request.Cookies["id"];
            HttpCookie password = context.Request.Cookies["password"];
            long ID = long.Parse(id.Value);
            long Password = long.Parse(password.Value);
            DataTable table=SqlHelpers.SqlHelper.ExecuteDataTable("select * from T_Students where ID=@ID and Password=@Password",
                new SqlParameter("@ID", ID),
                new SqlParameter("@Password",Password));
            int admin_id = int.Parse(table.Rows[0]["Admin"].ToString());
            if (admin_id == 1)
            {
                context.Response.Write("right");
            }
            else if(admin_id==0)
            {
                context.Response.Write("error");
            }
            else
            {
                context.Response.Write("unknow_error");
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