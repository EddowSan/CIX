using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;

namespace NewsFeedInput
{
    public partial class DeletionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                try
                {
                    populateBoxes();

                }
                catch (Exception error)
                {
                    headerTag.InnerHtml = "Coleman Universty<br />Oh No! Error: " + error.Message;
                }
            }
        }

        private void populateBoxes()
        {
            string[] filePaths = Directory.GetFiles(@"C:\Users\Student3\Desktop\NewsWriter\datafiles", "*.xml");
            string[] fileNames = Directory.GetFiles(@"C:\Users\Student3\Desktop\NewsWriter\datafiles", "*.xml");
            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = Path.GetFileNameWithoutExtension(fileNames[i]);
            }

            drpChannels.DataSource = fileNames;
            drpChannels.DataBind();
            
            listItems.Items.Clear();
            XDocument feed = XDocument.Load(filePaths[drpChannels.SelectedIndex]);
            List<XElement> items = feed.Element("rss").Element("channel").Elements("item").ToList();
            listItems.DataSource = items.Elements("title");
            listItems.DataTextField = "value";
            listItems.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] filePaths = Directory.GetFiles(@"C:\Users\Student3\Desktop\NewsWriter\datafiles", "*.xml");
                XDocument feed = XDocument.Load(filePaths[drpChannels.SelectedIndex]);
                if (feed.Element("rss").Element("channel").Elements("item").ElementAtOrDefault(listItems.SelectedIndex).Element("title").Value == listItems.SelectedItem.Value)
                {
                    feed.Element("rss").Element("channel").Elements("item").ElementAtOrDefault(listItems.SelectedIndex).Remove();
                    feed.Save(filePaths[drpChannels.SelectedIndex]);
                }
                else
                {
                    headerTag.InnerHtml = "Coleman Universty<br />That article was already deleted";
                }
                populateBoxes();
            }
            catch (NullReferenceException)
            {
                headerTag.InnerHtml = "Coleman Universty<br />You need to select an article to delete";
            }
            catch (Exception error)
            {
                headerTag.InnerHtml = "Coleman Universty<br />Oh no! Error: " + error.Message;
            }
        }

        protected void drpChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] filePaths = Directory.GetFiles(@"C:\Users\Student3\Desktop\NewsWriter\datafiles", "*.xml");
                listItems.Items.Clear();
                XDocument feed = XDocument.Load(filePaths[drpChannels.SelectedIndex]);
                List<XElement> items = feed.Element("rss").Element("channel").Elements("item").ToList();
                listItems.DataSource = items.Elements("title");
                listItems.DataTextField = "value";
                listItems.DataBind();
            }
            catch (Exception error)
            {
                headerTag.InnerHtml = "Coleman Universty<br />Oh no! Error: " + error.Message;
            }
        }

    }
}