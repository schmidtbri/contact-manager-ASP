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
        if (Session["logged_in"] != null && (bool)Session["logged_in"] == true)
        {
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    com.database.sforce.SforceService service = new com.database.sforce.SforceService();

                    com.database.sforce.LoginResult result = service.login("bor@veryrealemail.com", "adsf1324wKcXYLUTjBkGwXSxA4e0jv16");

                    com.database.sforce.SessionHeader header = new com.database.sforce.SessionHeader();
                    header.sessionId = result.sessionId;

                    service.SessionHeaderValue = header;
                    service.Url = result.serverUrl;

                    com.database.sforce.QueryResult query_result = service.query("SELECT Name, first_name__c, last_name__c, email__c, home_phone__c, cell_phone__c, owner_id__c FROM contact__c WHERE Name = '" + Request.QueryString["id"] + "'"); //AND owner_id__c = " + Convert.ToInt32(Session["user_id"].ToString()));

                    if (query_result.size == 0)
                    {
                        Label1.Text = "No contacts found";
                    }
                    else
                    {
                        com.database.sforce.sObject[] results = query_result.records.ToArray();

                        com.database.sforce.contact__c contact = (com.database.sforce.contact__c)results[0];

                        if (contact.owner_id__c == (string)Session["user_id"])
                        {
                            Label1.Text = Label1.Text + "<table border=0 ><tr><td>First Name: </td><td>" + contact.first_name__c + "</td></tr>";
                            Label1.Text = Label1.Text + "<tr><td>Last Name: </td><td>" + contact.last_name__c + "</td></tr>";
                            Label1.Text = Label1.Text + "<tr><td>Email: </td><td>" + contact.email__c + "</td></tr>";
                            Label1.Text = Label1.Text + "<tr><td>Home Phone: </td><td>" + contact.home_phone__c + "</td></tr>";
                            Label1.Text = Label1.Text + "<tr><td>Cell Phone:</td><td>" + contact.cell_phone__c + "</td></tr></table>";
                            Label1.Text = Label1.Text + "<br><a href=Search_Contacts.aspx >Return</a><br>";
                        }
                        else
                        {
                            Label1.Text = "You dont have access to this contact.";
                        }
                    }

                    service.logout();
                }
                catch (Exception ex)
                {
                    Label1.Text = "Error in contacting database.com: " + ex.ToString();
                }
            }
        }
        else
        {
            Label1.Text = "You are not logged in";
        }
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

                com.database.sforce.QueryResult query_result;

                if (TextBox1.Text == "" && TextBox2.Text != "")
                {
                    query_result = service.query("SELECT Name, first_name__c, last_name__c, email__c, home_phone__c, cell_phone__c, owner_id__c FROM contact__c WHERE last_name__c = '" + TextBox2.Text + "' AND owner_id__c = '" + (string)Session["user_id"] + "' ");
                }
                else if (TextBox1.Text != "" && TextBox2.Text == "")
                {
                    query_result = service.query("SELECT Name, first_name__c, last_name__c, email__c, home_phone__c, cell_phone__c, owner_id__c FROM contact__c WHERE first_name__c = '" + TextBox1.Text + "' AND owner_id__c = '" + (string)Session["user_id"] + "' ");
                }
                else if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    query_result = service.query("SELECT Name, first_name__c, last_name__c, email__c, home_phone__c, cell_phone__c, owner_id__c FROM contact__c WHERE first_name__c = '" + TextBox1.Text + "' AND last_name__c = '" + TextBox2.Text + "' owner_id__c = '" + (string)Session["user_id"] + "' ");
                }
                else
                {
                    query_result = service.query("SELECT Id, Name, first_name__c, last_name__c, email__c, home_phone__c, cell_phone__c, owner_id__c FROM contact__c WHERE owner_id__c = '" + (string)Session["user_id"] + "' ");
                }

                if (query_result.size == 0)
                {
                    Label1.Text = "No contacts found";
                }
                else
                {
                    Label1.Text = query_result.size + " results found.<br>";

                    com.database.sforce.sObject[] results = query_result.records.ToArray();

                    Label1.Text = Label1.Text + "<table border=1><tr><td>Select</td><td>Name</td></tr>";

                    foreach (com.database.sforce.contact__c contact in results)
                    {
                        Label1.Text = Label1.Text + "<tr><td><a href=\"Search_Contacts.aspx?id=" + contact.Name + "\" > Select</a></td><td>" + contact.first_name__c + " " + contact.last_name__c + "</td></tr>\n";
                    }
                    Label1.Text = Label1.Text + "</table>";
                }

                service.logout();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error in contacting database.com: " + ex.ToString();
            }
        }
        else
        {
            Label1.Text = "You are not logged in.";
        }
    }
}