<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        string JQueryVer = "1.7.1";
    ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
    {
        Path = "~/Scripts/jquery-" + JQueryVer + ".min.js",
        DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js",
        CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
        CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
        CdnSupportsSecureConnection = true,
        LoadSuccessExpression = "window.jQuery"
    });



        //Session["SelectedSeats"] = null;
       // Session["SeatsInfo"] = null;
    }

   /* void Application_End(object sender, EventArgs e)
    {
        if (Session["SelectedSeats"] != null)
        {
            //   Session["SelectedSeats"] = null;
            //Request.Cookies["orderDe.Expires.AddSeconds(0);
        }

    } */
    void CurrentDomain_DomainUnload(object sender, EventArgs e)
    {
        // Cleanup code here
    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }


</script>
