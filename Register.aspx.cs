using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Login_page
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=PRAKASHAM-PC;Database=radha;Trusted_Connection=true";
            con.Open();
            SqlCommand com = new SqlCommand("select name from user1 where name='" + TextBox1.Text + "'", con);
            SqlDataReader dr = com.ExecuteReader();

            if (dr.Read())
            {
                Label6.Visible = true;
                Label6.Text = "User Already existed";
            }
            else
            {
                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = "Server=PRAKASHAM-PC;Database=radha;Trusted_Connection=true";
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("insert into user1 values ('" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "','" + TextBox4.Text + "')", con1);
                int rows1 = cmd1.ExecuteNonQuery();
                if (rows1 != 0)
                {
                    Label6.Visible = true;
                    Label6.Text = "User Registerd successfully";
                }
                else
                {
                    Label6.Visible = true;
                    Label6.Text = "Something went wrong. Please regsiter again";
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label6.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");

        }
    }
}