using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for XMLAccess
/// </summary>
public class XMLAccess
{
    private string xmlBooksPath
    {
        get
        {
            return ConfigurationManager.AppSettings["XMLBooksPath"];
        }
    }

    private string xmlUsersPath
    {
        get
        {
            return ConfigurationManager.AppSettings["XMLUsersPath"];
        }
    }

    public XMLAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool AddBookNode(Dictionary<String, String> bookInfo)
    {
        try
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlBooksPath);
            
            XmlNode newBook = xmlDocument.CreateNode(XmlNodeType.Element, "Book", null);
            foreach (KeyValuePair<string, string> entry in bookInfo)
            {
                XmlElement node = xmlDocument.CreateElement(entry.Key.ToString());
                node.InnerText = entry.Value.ToString();
                newBook.AppendChild(node);
            }
            
            XmlNode root = xmlDocument.DocumentElement;
            root.AppendChild(newBook);

            xmlDocument.Save(xmlBooksPath);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool RemoveBookNode(String ISBN)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlBooksPath);

        XmlNode node = xmlDocument.SelectSingleNode(String.Format("Books/Book[ISBN='{0}']", ISBN));
        if (node != null)
        {
            node.ParentNode.RemoveChild(node);
            xmlDocument.Save(xmlBooksPath);
            return true;
        }
        else
        {
            return false;
        }

    }

    // for signing in
    public bool SearchUserNode(String name, string pwd)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlUsersPath);

        XmlNode node = xmlDocument.SelectSingleNode(String.Format("Users/User[name='{0}' and password='{1}']", name, pwd));
        if (node != null)
            return true;
        else
            return false;

    }

    // for registering
    public bool SearchUserNode(String name)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlUsersPath);

        XmlNode node = xmlDocument.SelectSingleNode(String.Format("Users/User[name='{0}']", name));
        if (node != null)
            return true;
        else
            return false;
    }

    public bool AddUserNode(Dictionary<string, string> userInfo)
    {
        try
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlUsersPath);
            
            XmlNode newUser = xmlDocument.CreateNode(XmlNodeType.Element, "User", null);

            foreach (KeyValuePair<string, string> entry in userInfo)
            {
                XmlElement node = xmlDocument.CreateElement(entry.Key.ToString());
                node.InnerText = entry.Value.ToString();
                newUser.AppendChild(node);
            }
            
            XmlNode root = xmlDocument.DocumentElement;
            root.AppendChild(newUser);

            xmlDocument.Save(xmlUsersPath);

            return true;
        }
        catch
        {
            return false;
        }
    }

    // for searching books
    public Hashtable GetBookNodeByTitle(String title)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlBooksPath);

        Hashtable hashtable = new Hashtable();

        XmlNode node = xmlDocument.SelectSingleNode(String.Format("Books/Book[Title='{0}']", title));
        if (node != null)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                hashtable.Add(child.Name, child.InnerText);
            }

            return hashtable;
        }

        else
            return null;

    }

    public Hashtable GetBookNodeByISBN(String ISBN)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlBooksPath);

        Hashtable hashtable = new Hashtable();

        XmlNode node = xmlDocument.SelectSingleNode(String.Format("Books/Book[ISBN='{0}']", ISBN));
        if (node != null)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                hashtable.Add(child.Name, child.InnerText);
            }

            return hashtable;
        }

        else
            return null;

    }

    public Hashtable GetUserNode(String username)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlUsersPath);

        Hashtable hashtable = new Hashtable();

        XmlNode node = xmlDocument.SelectSingleNode(String.Format("Users/User[name='{0}']", username));
        if (node != null)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                hashtable.Add(child.Name, child.InnerText);
            }

            return hashtable;
        }

        else
            return null;
    }

    public DataSet GetBookNodes()
    {
        DataSet data = new DataSet();
        data.ReadXml(xmlBooksPath);
        return data;
    }

}