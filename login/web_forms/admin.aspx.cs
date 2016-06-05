using SqlHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace login.web_forms
{
    public partial class admin : System.Web.UI.Page
    {
        public DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie id = Context.Request.Cookies["id"];
            HttpCookie password = Context.Request.Cookies["password"];
            long ID = long.Parse(id.Value);
            long Password = long.Parse(password.Value);
            int admin_ID =int.Parse(SqlHelper.ExecuteScalar("select Admin from T_Students where ID=@ID and Password=@Password",
             new SqlParameter("@ID", ID),
             new SqlParameter("@Password", Password)).ToString());
            if (admin_ID == 1)
            {
                if (Request["ID_del"] != null)
                {
                    long ID_del = long.Parse(Request["ID_Del"]);
                    int row = SqlHelper.ExecuteNonQuery("Delete from T_Students where ID=@ID ",
                        new SqlParameter("@ID", ID_del)
                    );
                }
                table = SqlHelper.ExecuteDataTable("select * from T_Students"); 
            }
        }
    }
}