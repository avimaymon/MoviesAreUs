using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Buy_A_Ticket : System.Web.UI.Page
{
    SqlCommand sqlCommand1;//will be availabe for all function
    SqlConnection sqlConnection1;//will be availabe for all function
    public static string FilmName = "";
    CheckBox[,] Seats = new CheckBox[5, 5];
    //bool[,] seatsData = new bool[5, 5];
    bool[,] selectedSeatsData = new bool[5, 5];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UniqueID"] == null)
            Response.Redirect("Home.aspx");
        string constr = @"Data Source=AviMaymon-PC\MYSERVER;Initial Catalog=MoviesAreUsDB;Integrated Security=True";
        sqlConnection1 = new System.Data.SqlClient.SqlConnection(constr);			//the command object
        System.Data.SqlClient.SqlDataReader SqlDataReader1;
        //get user id and save with Session
        sqlCommand1 = new SqlCommand("SELECT Id FROM Users WHERE Username=@Username", sqlConnection1);
        sqlCommand1.Parameters.AddWithValue("@Username", (string)Session["Username"]);
        sqlCommand1.Connection.Open();					//open the command connection
        SqlDataReader1 = sqlCommand1.ExecuteReader();	//the Reader gets the selected records
        SqlDataReader1.Read();
        Session["UserId"] = Int32.Parse(SqlDataReader1["Id"].ToString());
        sqlCommand1.Connection.Close();         //close the command object
        SqlDataReader1.Close();
        //LOADING MOVIES FROM DATABASE AND MAKING LINK BUTTONS 
        sqlCommand1 = new SqlCommand("SELECT * FROM Films", sqlConnection1);
        sqlCommand1.Connection.Open();					//open the command connection
        SqlDataReader1 = sqlCommand1.ExecuteReader();	//the Reader gets the selected records
        while (SqlDataReader1.Read())
        {
            LinkButton lnk = new LinkButton();
            lnk.ID = SqlDataReader1["Poster"].ToString().Substring(0, SqlDataReader1["Poster"].ToString().Length - 4);
            lnk.Text = SqlDataReader1["Title"].ToString();
            lnk.CssClass = "list-group-item list-group-item-action posterLink";
            string str = SqlDataReader1["Poster"].ToString().Substring(0, SqlDataReader1["Poster"].ToString().Length - 4) + "_Click";
            lnk.Click += new EventHandler(link_Click);
            movieList.Controls.Add(lnk);
        }
        sqlCommand1.Connection.Close();         //close the command object
        SqlDataReader1.Close();
        //binding
        Seats[0, 0] = check0_0;
        Seats[0, 1] = check0_1;
        Seats[0, 2] = check0_2;
        Seats[0, 3] = check0_3;
        Seats[0, 4] = check0_4;
        Seats[1, 0] = check1_0;
        Seats[1, 1] = check1_1;
        Seats[1, 2] = check1_2;
        Seats[1, 3] = check1_3;
        Seats[1, 4] = check1_4;
        Seats[2, 0] = check2_0;
        Seats[2, 1] = check2_1;
        Seats[2, 2] = check2_2;
        Seats[2, 3] = check2_3;
        Seats[2, 4] = check2_4;
        Seats[3, 0] = check3_0;
        Seats[3, 1] = check3_1;
        Seats[3, 2] = check3_2;
        Seats[3, 3] = check3_3;
        Seats[3, 4] = check3_4;
        Seats[4, 0] = check4_0;
        Seats[4, 1] = check4_1;
        Seats[4, 2] = check4_2;
        Seats[4, 3] = check4_3;
        Seats[4, 4] = check4_4;
    }
    protected void btnSubmit_Click(object sender, System.EventArgs e)
    {
        string seatsInfo = "";
        for (int row = 0; row < 5; row++)
            for (int col = 0; col < 5; col++)
                seatsInfo += Seats[row, col].Checked + ",";
        seatsInfo = seatsInfo.Substring(0, seatsInfo.Length - 1);
        FilmName = tmpFilmName.Text;
        Session["FilmName"] = FilmName;
        Session["SeatsInfo"] = seatsInfo;
        Response.Redirect("Pay.aspx");
    }
    protected void link_Click(object sender, System.EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        string id = btn.ID;
        System.Data.SqlClient.SqlDataReader SqlDataReader1;
        //the connection object
        string constr = @"Data Source=AviMaymon-PC\MYSERVER;Initial Catalog=MoviesAreUsDB;Integrated Security=True";
        sqlConnection1 = new System.Data.SqlClient.SqlConnection(constr);			//the command object
        //CHANGE POSTER AND FILM NAME LABEL
        sqlCommand1 = new SqlCommand("SELECT * FROM Films WHERE Poster=@poster", sqlConnection1);
        sqlCommand1.Parameters.AddWithValue("@Poster", id + ".jpg");
        sqlCommand1.Connection.Open();					//open the command connection
        SqlDataReader1 = sqlCommand1.ExecuteReader();	//the Reader gets the selected records
        SqlDataReader1.Read();
        posterImg.ImageUrl = "~/graphics/" + SqlDataReader1["Poster"];
        int FilmId = Int32.Parse(SqlDataReader1["Id"].ToString()); //for use in the next part
        tmpFilmName.Text = FilmName = SqlDataReader1["Title"].ToString();
        sqlCommand1.Connection.Close();         //close the command object
        SqlDataReader1.Close();
        //ENABLING CHECKBOXES THAT WERE DISABLED FOR OTHER FILM
        if (selectedSeatsData != null)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Seats[row, col].Enabled = true;
                }
            }
        }
        //DISABLING PURCHASED TICKET PER MOVIE
        sqlCommand1 = new SqlCommand("SELECT Seats FROM Orders WHERE FilmId=@FilmId", sqlConnection1);
        sqlCommand1.Parameters.AddWithValue("@FilmId", FilmId);
        sqlCommand1.Connection.Open();					//open the command connection
        SqlDataReader1 = sqlCommand1.ExecuteReader();	//the Reader gets the selected records
        while (SqlDataReader1.Read()) //for every order of the current film
        {   //build array of seats from Seats string in database
            string str = SqlDataReader1["Seats"].ToString();
            string[] seatArr = str.Split(',');
            //build seats matrix from seat array
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    selectedSeatsData[i, j] = Convert.ToBoolean(seatArr[i * 5 + j]);
                }
            }
            //disabling purchased seats for specific film
            if (selectedSeatsData != null)
            {
                for (int row = 0; row < 5; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        if (selectedSeatsData[row, col])
                        {
                            Seats[row, col].Checked = false;
                            Seats[row, col].Enabled = false;
                        }
                    }
                }
            }
        }
        sqlCommand1.Connection.Close();         //close the command object
        SqlDataReader1.Close();
    }
}