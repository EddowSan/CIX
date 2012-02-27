using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace NewsFeedInput
{
    public partial class AddChannel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (txtTitle.Text == "" || txtDescription.Text == "")
                {
                    headerTag.InnerHtml = "Coleman University<br />There Are Errors In Your Channel";
                    if (txtTitle.Text == "")
                    {
                        lblTitleError.Text = "The title is required!";
                    }
                    else
                    {
                        lblTitleError.Text = "";
                    }
                    if (txtDescription.Text == "")
                    {
                        lblDescriptionError.Text = "The description is required!";
                    }
                    else
                    {
                        lblDescriptionError.Text = "";
                    }
                }
                else
                {
                    lblTitleError.Text = "";
                    lblDescriptionError.Text = "";
                    try
                    {
                        XDocument feed = new XDocument(
                            new XElement("rss",
                                new XAttribute("version", "2.0"),
                                new XElement("channel",
                                    new XElement("title", new XCData(txtTitle.Text)),
                                    new XElement("link", ""),
                                    new XElement("description", new XCData(txtDescription.Text)))));
                        feed.Save(@"C:\Users\Student3\Desktop\NewsWriter\datafiles\" + txtTitle.Text + ".xml");

                        headerTag.InnerHtml = "Coleman University<br />Congrats! You successfully made a new channel!";
                        txtTitle.Text = "";
                        txtDescription.Text = "";
                    }
                    catch (Exception error)
                    {
                        headerTag.InnerHtml = "Coleman University<br />Oh No! Error: " + error.Message;
                        txtTitle.Text = "";
                        txtDescription.Text = "";
                    }
                }
            }
        }
    }
}