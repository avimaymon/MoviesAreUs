using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    SqlCommand sqlCommand1;//will be availabe for all function
    SqlConnection sqlConnection1;//will be availabe for all function

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnEnter_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlDataReader SqlDataReader1;
        //the connection object
        string constr = @"Data Source=AviMaymon-PC\MYSERVER;Initial Catalog=MoviesAreUsDB;Integrated Security=True";
        sqlConnection1 = new System.Data.SqlClient.SqlConnection(constr);			//the command object
        sqlCommand1 = new SqlCommand("SELECT * FROM Users WHERE Username=@Username AND Password=@Password", sqlConnection1);
        sqlCommand1.Parameters.AddWithValue("@Username", txtUserName.Text);
        sqlCommand1.Parameters.AddWithValue("@Password", txtUserPass.Text);
        sqlCommand1.Connection.Open();					//open the command connection
        SqlDataReader1 = sqlCommand1.ExecuteReader();	//the Reader gets the selected records
        if (SqlDataReader1.Read())
        {
            sqlCommand1.Connection.Close();         //close the command object
            SqlDataReader1.Close();                 //you have to close the Reader in order to use the Command again!
            Session["UserName"] = txtUserName.Text;
            Guid uid = Guid.NewGuid();
            HttpCookie myCookie = new HttpCookie("UniqueID");
            myCookie.Value = uid.ToString();
            Response.Cookies.Add(myCookie);
            Response.Redirect("Buy_A_Ticket.aspx");
        }
        else
        {
            sqlCommand1.Connection.Close();         //close the command object
            SqlDataReader1.Close();
        }
    }
}