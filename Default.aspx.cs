using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
namespace News
{
   private string connString = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionStringSettings connectionStringSettings =
               ConfigurationManager.ConnectionStrings["ConnectionString"];
            if (connectionStringSettings == null ||
                string.IsNullOrEmpty(connectionStringSettings.ConnectionString))
                throw new ApplicationException("未找到数据库连接字符串。");
            this.connString = connectionStringSettings.ConnectionString;
            if (IsPostBack)
            {
                lbMessage.Visible = true;
            }
            else
            {
                lbMessage.Visible = false;
            }
        }

        protected void on_button(object sender, EventArgs e)
        {
            string sql = 
                //"Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\News.mdf;Integrated Security=True;User Instance=True";
            //string sql =
                "INSERT INTO News(Title, CategoryId, Content, AddTime) " ;
               "VALUES(@Title, @Author, @CategoryId, @Content, @AddTime)";
      using (SqlConnection conn = new SqlConnection(connString))
      {
          using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
            //SqlConnection conn = new SqlConnection(connStr);
          //  SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Title",Text1.Text);
            cmd.Parameters.AddWithValue("@Author",Text2.Text);                                                                                                                                                              
            cmd.Parameters.AddWithValue("@Content",Text3.Text);
            cmd.Parameters.AddWithValue("@AddTime",time.Text);
            cmd.Parameters.AddWithValue("@CategoryId",Select1.SelectedValue);
           try
                    {
                        conn.Open();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            lbMessage.Text = "添加学生信息成功。";
                            lbMessage.Style.Add("color", "green");
                            tbForm.Visible = false;
                        }
                        else
                        {
                            lbMessage.Text = "添加失败。";
                            lbMessage.Style.Add("color", "red");
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        lbMessage.Text = "添加失败。" + ex.Message;
                        lbMessage.Style.Add("color", "red");
                    }
                }
      }
        
        }
    }
}
}
