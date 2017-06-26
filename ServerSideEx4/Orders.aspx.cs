using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Orders : System.Web.UI.Page
{
    SqlCommand sqlCommand1,sqlCommand2;//will be availabe for all function
    SqlConnection sqlConnection1,sqlConnection2;//will be availabe for all function
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlDataReader SqlDataReader1,SqlDataReader2;
        string constr = @"Data Source=AviMaymon-PC\MYSERVER;Initial Catalog=MoviesAreUsDB;Integrated Security=True";
        sqlConnection1 = new System.Data.SqlClient.SqlConnection(constr);
        sqlConnection2 = new System.Data.SqlClient.SqlConnection(constr);
        string snackStr="";
        if (Request.Cookies["UniqueID"] == null)
            Response.Redirect("Home.aspx");
        if (Session["PhoneNumber"]!=null)
        {
            lblPhoneNumber.Text ="Your phone number : " +  (string)Session["PhoneNumber"];
        }
        OrdersTable.InnerHtml = "<table class='ordersTable center' runat='server'>" +
                "<tr class='ordersRowCol'>" +
                    "<td class='ordersRowCol'>Title</td>" +
                    "<td class='ordersRowCol'>Poster</td>" +
                    "<td class='ordersRowCol'>Seats</td>" +
                    "<td class='ordersRowCol'>Credit Card</td>" +
                    "<td class='ordersRowCol'>Snacks</td></tr>";
        //get all records of user from orders table
        sqlCommand1 = new SqlCommand("SELECT *,Orders.Id AS Oid FROM Orders INNER JOIN Users ON Orders.UserId = Users.Id AND Users.Id=@UserId INNER JOIN Films ON Orders.FilmId=Films.Id ", sqlConnection1);
        sqlCommand1.Parameters.AddWithValue("@UserId", Int32.Parse(Session["UserId"].ToString()));
        sqlCommand1.Connection.Open();                  //open the command connection
        SqlDataReader1 = sqlCommand1.ExecuteReader();   //the Reader gets the selected records
        while(SqlDataReader1.Read())
        {
            sqlCommand2 = new SqlCommand("SELECT  Food.FoodId, Food.OrderId, Food.OrderQuantity, Orders.Id FROM Food INNER JOIN Orders ON Food.OrderId = Orders.Id AND Orders.Id=@OrderId", sqlConnection2);
            sqlCommand2.Parameters.AddWithValue("@OrderId", Int32.Parse(SqlDataReader1["Oid"].ToString()));
            sqlCommand2.Connection.Open();                  //open the command connection
            SqlDataReader2 = sqlCommand2.ExecuteReader();   //the Reader gets the selected records
            int snackTypes=0;
            while (SqlDataReader2.Read())
            {
                if(Int32.Parse(SqlDataReader2["FoodId"].ToString())==1)
                {
                    if (snackTypes != 0)
                        snackStr += ",";
                    snackTypes++;
                    snackStr += "Popcorn:" + SqlDataReader2["OrderQuantity"].ToString();
                }
                if (Int32.Parse(SqlDataReader2["FoodId"].ToString()) == 2)
                {
                    if (snackTypes != 0)
                        snackStr += ",";
                    snackTypes++;
                    snackStr += "Nachos:" + SqlDataReader2["OrderQuantity"].ToString();
                }
                if (Int32.Parse(SqlDataReader2["FoodId"].ToString()) == 3)
                {
                    if (snackTypes != 0)
                        snackStr += ",";
                    snackTypes++;
                    snackStr += "Drinks:" + SqlDataReader2["OrderQuantity"].ToString();
                }
            }
            //fill table
            var seatCount = SqlDataReader1["Seats"].ToString().Split(new string[] { "True" }, StringSplitOptions.None).Length - 1;
            OrdersTable.InnerHtml += "<tr class='ordersRowCol'>" +
                    "<td class='ordersRowCol'>" + SqlDataReader1["Title"].ToString() + "</td>" +
                    "<td class='ordersRowCol'><img width='108' src='graphics/" + SqlDataReader1["Poster"].ToString() + "' /></td>" +
                    "<td class='ordersRowCol'>" + seatCount + "</td>" +
                    "<td class='ordersRowCol'>" + SqlDataReader1["Payment"].ToString() + "</td>" +
                    "<td class='ordersRowCol'>" + snackStr + "</td></tr>";
            snackStr = "";
            sqlCommand2.Connection.Close();         //close the command object
            SqlDataReader2.Close();
        }
        OrdersTable.InnerHtml += "</table>";
        sqlCommand1.Connection.Close();         //close the command object
        SqlDataReader1.Close();
    }
}