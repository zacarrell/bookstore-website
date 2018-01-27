using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditBooks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsAdmin"] == null || (bool)Session["IsAdmin"] == false)
        {
            Label1.Visible = true;
            Label1.Text = "Only administrators can access this page.";
            theEditControls.Visible = false;

        }
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        XMLAccess xmlAccess = new XMLAccess();
        Hashtable bookInfo = new Hashtable();
        bookInfo = xmlAccess.GetBookNodeByTitle(TitleTextBox.Text);
        
        if (bookInfo != null)
        {
            AuthorTextBox.Text = bookInfo["Author"].ToString();
            IllustratorTextBox.Text = bookInfo["Illustrator"].ToString();
            GenreTextBox.Text = bookInfo["Genre"].ToString();
            PriceTextBox.Text = bookInfo["Price"].ToString();
            YearTextBox.Text = bookInfo["Year"].ToString();
            IsbnTextBox.Text = bookInfo["ISBN"].ToString();
            Label1.Visible = false;
        }
        else
        {
            Label1.Text = "We don't seem to have that book.";
            Label1.Visible = true;
        }
    }

    protected void AddBookButton_Click(object sender, EventArgs e)
    {
        Label1.Visible = true;
        XMLAccess xmlAccess = new XMLAccess();

        if (xmlAccess.GetBookNodeByISBN(IsbnTextBox.Text) == null)
        {
            Dictionary<string, string> bookInfo = new Dictionary<string, string>();
            bookInfo.Add("Title", TitleTextBox.Text);
            bookInfo.Add("Author", AuthorTextBox.Text);
            bookInfo.Add("Illustrator", IllustratorTextBox.Text);
            bookInfo.Add("Genre", GenreTextBox.Text);
            bookInfo.Add("Price", PriceTextBox.Text);
            bookInfo.Add("Year", YearTextBox.Text);
            bookInfo.Add("ISBN", IsbnTextBox.Text);

            if (xmlAccess.AddBookNode(bookInfo))
            {
                Label1.Text = String.Format("Success: Added {0} to database", IsbnTextBox.Text);
            }
            else
            {
                Label1.Text = String.Format("Failure: Unable to add {0} to database", IsbnTextBox.Text);
            }
        }
        else
        {
            Label1.Text = String.Format("Failure: {0} already exists in database", IsbnTextBox.Text);
        }
    }

    protected void SearchByIsbnButton_Click(object sender, EventArgs e)
    {
        XMLAccess xmlAccess = new XMLAccess();
        Hashtable bookInfo = new Hashtable();
        bookInfo = xmlAccess.GetBookNodeByISBN(IsbnTextBox.Text);

        if (bookInfo != null)
        {
            AuthorTextBox.Text = bookInfo["Author"].ToString();
            IllustratorTextBox.Text = bookInfo["Illustrator"].ToString();
            GenreTextBox.Text = bookInfo["Genre"].ToString();
            PriceTextBox.Text = bookInfo["Price"].ToString();
            YearTextBox.Text = bookInfo["Year"].ToString();
            TitleTextBox.Text = bookInfo["Title"].ToString();
            Label1.Visible = false;
        }
        else
        {
            Label1.Text = "We don't seem to have that book.";
            Label1.Visible = true;
        }
    }

    protected void RemoveBookButton_Click(object sender, EventArgs e)
    {
        Label1.Visible = true;
        XMLAccess xmlAccess = new XMLAccess();
        if (xmlAccess.RemoveBookNode(IsbnTextBox.Text))
        {
            Label1.Text = String.Format("Success: Removed {0} from database", IsbnTextBox.Text);
        }
        else
        {
            Label1.Text = String.Format("Failure: Unable to remove {0} from database", IsbnTextBox.Text);
        }
    }
}