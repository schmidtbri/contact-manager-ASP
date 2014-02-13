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

            com.database.sforce.users__c new_user = new com.database.sforce.users__c();

            new_user.name__c = TextBox1.Text;
            new_user.user_name__c = TextBox2.Text;
            new_user.password__c = TextBox3.Text;

            com.database.sforce.users__c[] users = new com.database.sforce.users__c[1];
            users[0] = new_user;

            com.database.sforce.SaveResult[] saveresult = service.create(users);

            if (saveresult[0].success)
            {
                Label1.Text = "Registration Succesful";
            }
            else
            {
                Label1.Text = "Failed to register.";
            }

            service.logout();
        }
        catch
        {
            Label1.Text = "Error in contacting database.com";
        }
    }
}