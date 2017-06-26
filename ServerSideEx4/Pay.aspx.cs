using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pay : System.Web.UI.Page
{
    SqlCommand sqlCommand1;//will be availabe for all function
    SqlConnection sqlConnection1;//will be availabe for all function
    string  SeatesInfoStr; int counter ;
    static string snackStr;
    bool[,] seatesData = new bool[5, 5];
    const int moviePrice= 30,popcornPrice=15,nachosPrice=10,drinkPrice=8;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UniqueID"] == null)
            Response.Redirect("Home.aspx");
        if (Session["FilmName"] != null && Session["SeatsInfo"]!=null)
        {
            string FilmName = (string)Session["FilmName"];
            SeatesInfoStr = (string)Session["SeatsInfo"];
            if (SeatesInfoStr != null)
            {
                var data = SeatesInfoStr.Split(',');
                int _row = 0;
                counter = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    seatesData[_row, i % 5] = Convert.ToBoolean(data[i]);
                    if (i % 5 == 4)
                        _row++;
                }
                SeatesInfoStr = "";
                for (int row = 0; row < 5; row++)
                {
                    string RowStr = "";
                    for (int col = 0; col < 5; col++)
                    {
                        if (seatesData[row, col])
                        {
                            if (RowStr != "")
                                RowStr += ", ";
                            RowStr += "<a class=\"Pay_SeatStyle\">Seat: " + (col + 1) + "</a>";
                            counter++;
                        }
                    }
                    if (RowStr != "")
                    {
                        if (SeatesInfoStr != "")
                            SeatesInfoStr += "<br />";
                        SeatesInfoStr += "<u><b> Row: " + (row + 1) + " </b> > " + RowStr + "</u>";
                    }
                }
                SeatesInfoStr += "<br />";
                SeatesInfoStr += "Total <u>" + counter * moviePrice + "</u>$" + " for your ticket(s)";
            }
            lblTransactionInfo.InnerHtml = "You're paying for " + FilmName + "<br />" + SeatesInfoStr;
            DD_CardType.Enabled = true;
            TxtCardNumber.Enabled = true;
            txtPhoneNumber.Enabled = true;
            RB_Coupon_No.Enabled = true;
            RB_Coupon_Yes.Enabled = true;
            Quantity1.Enabled = true;
            Quantity2.Enabled = true;
            Quantity3.Enabled = true;
            Size1.Enabled = true;
            Size2.Enabled = true;
            Size3.Enabled = true;
        }
    }
    protected void ddl_Change(object sender, EventArgs e)
    {
        snackStr = "";
        string quant1 = Quantity1.SelectedItem.ToString();
        string quant2 = Quantity2.SelectedItem.ToString();
        string quant3 = Quantity3.SelectedItem.ToString();
        string size1 = Size1.SelectedItem.ToString();
        string size2 = Size2.SelectedItem.ToString();
        string size3 = Size3.SelectedItem.ToString();
        int intQuant1 = Int32.Parse(quant1);
        int intQuant2 = Int32.Parse(quant2);
        int intQuant3 = Int32.Parse(quant3);
        if (quant1 != "0" || quant2 != "0" 
            || quant3 != "0")
        {
            string str = "<u>Snack & Drinks:</u>" + "<br/>";
            if (quant1 != "0")
            {
                str += "Popcorn  " + quant1 + "  " + size1 +
                    " will cost " + intQuant1 + "*" + popcornPrice +
                    "=<u>" + intQuant1 * popcornPrice + "$</u><br/>";
                snackStr += "Popcorn:  " + quant1 + "  " + size1; 
            }
            if (quant2 != "0")
            {
                str += "Nachos  " + quant2 + "  " + size2 +
                    " will cost " + intQuant2 + "*" + nachosPrice + "=<u>" +
                    intQuant2 * nachosPrice + "$</u><br/>";
                if (snackStr != "")
                    snackStr += ", ";
                snackStr += "Nachos:  " + quant2 + "  " + size2; 
            }
            if (quant3 != "0")
            {
                str += "Drinks  " + quant3 + "  " + size3 +
                    " will cost " + intQuant3 + "*" + drinkPrice + "=<u>" +
                    intQuant3 * drinkPrice + "$</u><br/>";
                if (snackStr != "")
                    snackStr += "<br/>";
                snackStr += "Drinks:  " + quant3 + "  " + size3;
            }
            int snackTotal = intQuant3 * drinkPrice + intQuant2 * nachosPrice + intQuant1 * popcornPrice;
            str += "Total for snacks: <u> " + snackTotal + "$</u><br/>";
            int allTogether = snackTotal + counter * moviePrice;
            str += "<b>Summary : " + "<u>" + allTogether + "$</u></b><br/>";
            lblSnacksInfo.InnerHtml = str;
        }
    }
    protected void btnPay_Click(object sender, EventArgs e)
    {
        string Seats, Payment, DateNTime;
        int FilmId, UserId;
        System.Data.SqlClient.SqlDataReader SqlDataReader1;
        string constr = @"Data Source=AviMaymon-PC\MYSERVER;Initial Catalog=MoviesAreUsDB;Integrated Security=True";
        sqlConnection1 = new System.Data.SqlClient.SqlConnection(constr);			//the command object
        //get filmId
        sqlCommand1 = new SqlCommand("SELECT Id FROM Films WHERE Title=@Title", sqlConnection1);
        sqlCommand1.Parameters.AddWithValue("@Title", (string)Session["FilmName"]);
        sqlCommand1.Connection.Open();					//open the command connection
        SqlDataReader1 = sqlCommand1.ExecuteReader();	//the Reader gets the selected records
        SqlDataReader1.Read();
        FilmId = Int32.Parse(SqlDataReader1["Id"].ToString());
        sqlCommand1.Connection.Close();         //close the command object
        SqlDataReader1.Close();
        UserId = Int32.Parse(Session["UserId"].ToString()); //get user id
        //get the rest
        Seats = (string)Session["SeatsInfo"];
        Payment = DD_CardType.Text;
        DateNTime= DateTime.Now.ToString();
        //insert to orders table
        sqlCommand1 = new SqlCommand("INSERT Orders (FilmId,UserId,Seats,Payment,DateNTime) VALUES (@FilmId,@UserId,@Seats,@Payment,@DateNTime) SELECT SCOPE_IDENTITY() ", sqlConnection1);
        sqlCommand1.Parameters.AddWithValue("@FilmId", FilmId);
        sqlCommand1.Parameters.AddWithValue("@UserId", UserId);
        sqlCommand1.Parameters.AddWithValue("@Seats", Seats);
        sqlCommand1.Parameters.AddWithValue("@Payment", Payment);
        sqlCommand1.Parameters.AddWithValue("@DateNTime", DateNTime);
        sqlCommand1.Connection.Open();                  //open the command connection
        int OrderId = Convert.ToInt32(sqlCommand1.ExecuteScalar());
        sqlCommand1.Connection.Close();         //close the command object
        SqlDataReader1.Close();
        //insert to Food table
        if(Int32.Parse(Quantity1.SelectedItem.ToString())!=0)
        {
            sqlCommand1 = new SqlCommand("INSERT Food (FoodId,OrderId,OrderQuantity) VALUES (@FoodId,@OrderId,@OrderQuantity) ", sqlConnection1);
            sqlCommand1.Parameters.AddWithValue("@FoodId", 1);
            sqlCommand1.Parameters.AddWithValue("@OrderId", OrderId);
            sqlCommand1.Parameters.AddWithValue("@OrderQuantity", Quantity1.SelectedItem.ToString());
            sqlCommand1.Connection.Open();                  //open the command connection
            SqlDataReader1 = sqlCommand1.ExecuteReader();   //the Reader gets the selected records
            sqlCommand1.Connection.Close();         //close the command object
            SqlDataReader1.Close();
        }
        if (Int32.Parse(Quantity2.SelectedItem.ToString()) != 0)
        {
            sqlCommand1 = new SqlCommand("INSERT Food (FoodId,OrderId,OrderQuantity) VALUES (@FoodId,@OrderId,@OrderQuantity) ", sqlConnection1);
            sqlCommand1.Parameters.AddWithValue("@FoodId", 2);
            sqlCommand1.Parameters.AddWithValue("@OrderId", OrderId);
            sqlCommand1.Parameters.AddWithValue("@OrderQuantity", Quantity2.SelectedItem.ToString());
            sqlCommand1.Connection.Open();                  //open the command connection
            SqlDataReader1 = sqlCommand1.ExecuteReader();   //the Reader gets the selected records
            sqlCommand1.Connection.Close();         //close the command object
            SqlDataReader1.Close();
        }
        if (Int32.Parse(Quantity3.SelectedItem.ToString()) != 0)
        {
            sqlCommand1 = new SqlCommand("INSERT Food (FoodId,OrderId,OrderQuantity) VALUES (@FoodId,@OrderId,@OrderQuantity) ", sqlConnection1);
            sqlCommand1.Parameters.AddWithValue("@FoodId", 3);
            sqlCommand1.Parameters.AddWithValue("@OrderId", OrderId);
            sqlCommand1.Parameters.AddWithValue("@OrderQuantity", Quantity3.SelectedItem.ToString());
            sqlCommand1.Connection.Open();                  //open the command connection
            SqlDataReader1 = sqlCommand1.ExecuteReader();   //the Reader gets the selected records
            sqlCommand1.Connection.Close();         //close the command object
            SqlDataReader1.Close();
        }
        Session["PhoneNumber"] = txtPhoneNumber.Text;
        Session["UserId"] = UserId;
        Response.Redirect("Orders.aspx");
    }
}