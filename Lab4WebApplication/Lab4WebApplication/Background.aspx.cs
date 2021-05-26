﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Threading.Tasks;
namespace Lab4WebApplication
{
    public partial class Background : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

                //string connectionString = connectionString = (ConfigurationManager.ConnectionStrings["conStrAbdullah"].ConnectionString);
                // removed Persist Security Info=True; 
                DbConnectionStringBuilder csb = new DbConnectionStringBuilder();
                //Throws
                //csb.ConnectionString = "Data Source = (local)\sqle2018; initial Catalog = LoginDB; integrated Security = True; User ID = user1; Password = 123;";
                using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;User Id=user123;Password=123;"))
                 {
                    if (con.State == ConnectionState.Closed)
                    {
                        string query = "SELECT COUNT(1) from tblUser WHERE username=@username and password=@password";
                        SqlCommand  sqlCmd = new SqlCommand(query, con);
                        sqlCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                        con.Open();
                        /*int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                        if(count == 1)
                        {
                            Session["username"] = txtUserName.Text.Trim();
                            Response.Redirect("Dashboard.aspx");
                        }
                        else
                        {
                            lblErrorMessage.Visible = true;
                        }
                        */
                        
                    }
                }
            

        }
    }
}