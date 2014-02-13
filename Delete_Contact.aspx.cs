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


                    //searching for this contact
                    com.database.sforce.QueryResult query_result;

                    query_result = service.query("SELECT Id, Name, first_name__c, last_name__c, email__c, home_phone__c, cell_phone__c, owner_id__c FROM contact__c WHERE Id = '" + (string)Request.QueryString["id"] + "' ");

                    if (query_result.size == 0)
                    {
                        Label1.Text = "No contact found to delete.";
                    }
                    else
                    {
                        com.database.sforce.sObject[] results = query_result.records.ToArray();

                        com.database.sforce.contact__c search_result = (com.database.sforce.contact__c)results[0];

                        if (search_result.owner_id__c == (string)Session["user_id"])
                        {
                            string[] ids = { Request.QueryString["id"].ToString() };

                            com.database.sforce.DeleteResult[] delete_result = service.delete(ids);

                            if (delete_result[0].success)
                            {
                                Label1.Text = "Contact deleted.<br><br><a href=Delete_Contact.aspx >Return</a>";
                            }
                            else
                            {
                                Label1.Text = "No contacts deleted.<br>";
                                Label1.Text = Label1.Text + delete_result[0].id + "<br>";
                                Label1.Text = Label1.Text + delete_result[0].errors.ToArray()[0].message;

                            }

                        }
                        else
                        {
                            Label1.Text = "You dont have access to this contact.";
                        }
                        service.logout();
                    }
                }
                catch ( System.Web.Services.Protocols.SoapException ex)
                {
                    Label1.Text = "Unknown contact id.";
                }    
                catch (Exception ex)
                {
                    Label1.Text = "Error in contacting database.com: " + ex.GetType();
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
                    Label1.Text = query_result.size + " results found.";

                    com.database.sforce.sObject[] results = query_result.records.ToArray();

                    Label1.Text = Label1.Text + "<table border=1><tr><td>Select</td><td>Name</td></tr>";

                    foreach (com.database.sforce.contact__c contact in results)
                    {
                        Label1.Text = Label1.Text + "<tr><td><a href=\"Delete_Contact.aspx?id=" + contact.Id + "\" >Delete</a></td><td>" + contact.first_name__c + " " + contact.last_name__c + "</td></tr>\n";
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
            Label1.Text = "You are not logged in";
        }
    }
}