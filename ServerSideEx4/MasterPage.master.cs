using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = (string)Session["UserName"] ?? "Not signed in";
        FullNameHeader = userName;
    }
    public string FullNameHeader
    {
        get
        {
            return lblFullName.InnerText;
        }
        set
        {
            lblFullName.InnerText = "  Hello " + value + " !";
        }
    }
}
