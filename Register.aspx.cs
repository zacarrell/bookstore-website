using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        resultsLabel.Visible = false;
    }

    protected void registerBtn_Click(object sender, EventArgs e)
    {
        resultsLabel.Visible = true;
        XMLAccess xmlAccess = new XMLAccess();

        if (!xmlAccess.SearchUserNode(username.Text))
        {
            Dictionary<string, string> userInfo = new Dictionary<string, string>();
            userInfo.Add("name", username.Text);
            userInfo.Add("password", passwd.Text);
            userInfo.Add("isAdmin", adminRights.Checked ? "yes" : "no");

            if (xmlAccess.AddUserNode(userInfo))
            {
                if (Session["SignedIn"] == null || (bool)Session["SignedIn"] == false)
                {
                    Session["SignedIn"] = true;
                    Session["UserName"] = username.Text;
                    Session["isAdmin"] = adminRights.Checked;
                }
                resultsLabel.Text = "Success! Welcome to the Carrell Books family.";
            }
            else
            {
                resultsLabel.Text = "For some reason, we could not register you.";
            }
        }
        else
        {
            resultsLabel.Text = String.Format("User {0} already exists. Please choose a different name.", username.Text);
        }
    }
}