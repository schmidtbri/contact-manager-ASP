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
        Label1.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["logged_in"] != null && (bool)Session["logged_in"] == true)
        {
            try
            {
                com.database.sforce.SforceService service = new com.database.sforce.SforceService();

                com.database.sforce.LoginResult result = service.login("bor@veryrealemail.com", "adsf1324wKcXYLUTjBkGwXSxA4e0jv16");

                com.database.sforce.SessionHeader header = new com.database.sforce.SessionHeader();
                header.sessionId = result.sessionId;

                service.SessionHeaderValue = header;
                service.Url = result.serverUrl;

                com.database.sforce.contact__c new_contact = new com.database.sforce.contact__c();

                new_contact.first_name__c = FirstName.Text;
                new_contact.last_name__c = LastName.Text;
                new_contact.email__c = Email.Text;
                new_contact.home_phone__c = HomePhone.Text;
                new_contact.cell_phone__c = CellPhone.Text;
                new_contact.owner_id__c = (string)Session["user_id"];

                com.database.sforce.contact__c[] contacts = new com.database.sforce.contact__c[1];
                contacts[0] = new_contact;

                com.database.sforce.SaveResult[] saveresult = service.create(contacts);

                if (saveresult[0].success)
                {
                    Label1.Text = "Saved contact";
                }
                else
                {
                    Label1.Text = "Failed to save contact.";
                }

                service.logout();
            }
            catch(Exception ex)
            {
                Label1.Text = "Error in contacting database.com" + ex.Message;
            }
        }
        else
        {            
            Label1.Text = "You are not logged in";
        }
    }
}