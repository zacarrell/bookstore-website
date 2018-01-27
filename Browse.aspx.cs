using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class browse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XMLAccess xmlAccess = new XMLAccess();
        DataSet data = xmlAccess.GetBookNodes();
        BooksGridView.DataSource = data.Tables[0];
        BooksGridView.DataBind();
    }
}