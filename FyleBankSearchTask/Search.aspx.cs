using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FyleTask
{
    public partial class Serach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> lstbank = new List<string>();
                lstbank.Add("--select--");
                lstbank.Add("ABHYUDAYA COOPERATIVE BANK LIMITED");


                //test commit


                lstbank.Add("THE ROYAL BANK OF SCOTLAND N V");
                lstbank.Add("BASSEIN CATHOLIC COOPERATIVE BANK LIMITED");
                lstbank.Add("CENTRAL BANK OF INDIA");
                lstbank.Add("HDFC BANK");
                ddlselectbank.DataSource = lstbank;
                ddlselectbank.DataBind();

                DataTable dt = GetData();
                gvdisplay.DataSource = dt;
                gvdisplay.DataBind();
                gvdisplay.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


        public DataTable GetData()
        {
            var json = string.Empty;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("https://vast-shore-74260.herokuapp.com/banks?city=MUMBAI");
            }
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);
            Session["data"] = dt;
            return dt;
        }

        protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedbank = ddlselectbank.SelectedValue;
            DataTable dt = (DataTable)Session["data"];
            DataTable dtf = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[7].ToString() == selectedbank)
                {
                    dtf.ImportRow(dr);
                }
            }
            gvdisplay.DataSource = dtf;
            gvdisplay.DataBind();
            gvdisplay.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}