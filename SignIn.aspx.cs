using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        resultLabel.Visible = false;

        if (Session["SignedIn"] != null && (bool)Session["SignedIn"] == true)
        {
            resultLabel.Visible = true;
            resultLabel.Text = String.Format("You are already signed in as {0}!", Session["UserName"]);
        }
    }

    protected void loginBtn_Click(object sender, EventArgs e)
    {
        resultLabel.Visible = false;
        XMLAccess xmlAccess = new XMLAccess();
        if (!xmlAccess.SearchUserNode(username.Text, password.Text))
        {
            resultLabel.Text = "We couldn't find that person.";
            resultLabel.Visible = true;
            Session["SignedIn"] = false;
        }
        else
        {
            Session["SignedIn"] = true;
            Session["UserName"] = username.Text;

            Hashtable userInfo = xmlAccess.GetUserNode(username.Text);
            bool isAdmin = ("yes" == (string)userInfo["isAdmin"]) ? true : false;
            Session["isAdmin"] = isAdmin;

            if (isAdmin)
                resultLabel.Text = String.Format("You are now signed in, {0}. Enjoy your stay, administrator!", username.Text);
            else
                resultLabel.Text = String.Format("You are now signed in, {0}. Enjoy your stay!", username.Text);

            resultLabel.Visible = true;
        }
    }
}