using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["logged_in"] == null)
        {
            Session["logged_in"] = false;
        }

        if ((bool)Session["logged_in"] == false)
        {
            Table1.Visible = true;
            Button1.Visible = true;
        }
        else
        {
            Label1.Text = "Welcome, " + Session["name"]; ;
            Table1.Visible = false;
            Button1.Visible = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            com.database.sforce.SforceService service = new com.database.sforce.SforceService();

            com.database.sforce.LoginResult result = service.login("bor@veryrealemail.com", "adsf1324wKcXYLUTjBkGwXSxA4e0jv16");

            com.database.sforce.SessionHeader header = new com.database.sforce.SessionHeader();
            header.sessionId = result.sessionId;

            service.SessionHeaderValue = header;
            service.Url = result.serverUrl;

            com.database.sforce.QueryResult query_result = service.query("SELECT Id, Name, name__c, user_name__c, password__c FROM users__c WHERE user_name__c = '" + Username.Text + "' AND password__c = '" + Password.Text + "' ");

            if (query_result.size == 0)
            {
                Label1.Text = "Login failed";
            }
            else
            {
                com.database.sforce.sObject[] results = query_result.records.ToArray();

                com.database.sforce.users__c user = (com.database.sforce.users__c)results[0];

                Session["logged_in"] = true;
                Session["name"] = user.name__c;
                Session["user_id"] = user.Name;
                Response.Redirect("Homepage.aspx");
            }

            service.logout();
        }
        catch (Exception ex)
        {
            Label1.Text = "Error in contacting database.com: " + ex.ToString();
        }
    }
}

        
