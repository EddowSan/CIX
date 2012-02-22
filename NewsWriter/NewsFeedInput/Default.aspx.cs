using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Xml.Linq;
using System.IO;

namespace NewsFeedInput
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] filePaths = Directory.GetFiles(@"C:\Users\Student3\Desktop\NewsWriter\datafiles", "*.xml");
            string[] fileNames = filePaths;
            if (IsPostBack)
            {
                if (drpChannels.SelectedIndex < 0 || txtHeadline.Text == "" || txtDescription.Text == "")
                {
                    headerTag.InnerHtml = "Coleman Universty<br />There Are Errors In Your Article!";

                    if (drpChannels.SelectedIndex < 0)
                    {
                        lblChannelError.Text = "A channel needs to be selected!";
                    }
                    else
                    {
                        lblChannelError.Text = "";
                    }
                    if (txtHeadline.Text == "")
                    {
                        lblTitleError.Text = "The headline is required!";
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
                    lblChannelError.Text = "";
                    lblTitleError.Text = "";
                    lblDescriptionError.Text = "";
                    try
                    {
                        // Get post data for request object
                        NameValueCollection nvc = Request.Form;
                        string strHeadline = "";
                        string strDesc = "";

                        // Fill string with post data
                        if (!string.IsNullOrEmpty(nvc["txtHeadline"]))
                        {
                            strHeadline += nvc["txtHeadline"];
                        }
                        if (!string.IsNullOrEmpty(nvc["txtDescription"]))
                        {
                            strDesc += nvc["txtDescription"];
                        }

                        /*// Put data into article format
                        string strArticle = "<?xml version = \"1.0\" encoding = \"UTF-8\" standalone = \"no\"?>\n\n<rss version=\"2.0\">\n\t<channel>\n\t\t<item>\n\t\t\t<title>"
                            + strHeadline + "</title>\n\t\t\t<link></link>\n\t\t\t<description><![CDATA["
                            + strDesc + "]]></description>\n\t\t</item>\n\t</channel>\n</rss>";
                
                        string strTitle =  + DateTime.Today.Month + "-" + DateTime.Today.Day + "-" + DateTime.Today.Year + "H" + DateTime.Now.Hour + "M" + DateTime.Now.Minute + "S" + DateTime.Now.Second + ".xml";
                
                        // Make path with today's date as name
                        string path = @"C:\Users\Student3\Desktop\NewsWriter\datafiles\"+strTitle;
                
                        // Make new file and write to it
                        System.IO.File.WriteAllText(path, strArticle);*/

                        // Open channel
                        XDocument feed = XDocument.Load(filePaths[drpChannels.SelectedIndex]);
                        // Create Elements
                        XElement desc = new XElement("description", new XCData(strDesc));
                        XElement link = new XElement("link", "");
                        XElement title = new XElement("title", new XCData(strHeadline));
                        XElement item = new XElement("item", "");
                        // Place Elements
                        item.AddFirst(desc);
                        item.AddFirst(link);
                        item.AddFirst(title);
                        feed.Element("rss").Element("channel").Element("description").AddAfterSelf(item);
                        // Save Channel
                        feed.Save(filePaths[drpChannels.SelectedIndex]);

                        // Inform user of success
                        headerTag.InnerHtml = "Coleman Universty<br />Congratulation! You made a new article!";
                        txtHeadline.Text = "";
                        txtDescription.Text = "";
                    }
                    catch (Exception error)
                    {
                        headerTag.InnerHtml = "Coleman Universty<br />Oh No!<br />Error: " + error.Message;
                    }
                }
            }

            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = Path.GetFileNameWithoutExtension(fileNames[i]);
            }

            drpChannels.DataSource = fileNames;
            drpChannels.DataBind();
        }
    }
}
