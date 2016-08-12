using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    public static string vCard = "";
    public string RIA = "0";
    public string fullname = "";
    public string firstname = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string[] columnNames1 = { "first", "last", "title", "phone", "credentials", "email", "bio", "region", "RIA" };
            string[] columnTypes1 = { "System.String" };
            SqlParameter[] parameters1 = { new SqlParameter("first", SQLCleaner.clean2(Request.QueryString["a"])) };
            string Message1 = string.Empty;
            DataTable DT = Web_DAL.GetDataTable(null, "OMITTED STORED PROCEDURE NAME", columnNames1, columnTypes1, parameters1, ref Message1);

            if (DT != null)
            {
                if (DT.Rows.Count > 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        RIA = DT.Rows[i]["RIA"].ToString();
                        string[] phones = DT.Rows[i]["phone"].ToString().Split('|');
                        string[] favorites = DT.Rows[i]["favorites"].ToString().Split('|');
                        string credentials = ", " + DT.Rows[i]["credentials"].ToString().Replace("AIF", "AIF&reg;").Replace("CFP", "CFP&reg;").Replace("CFS", "CFS&reg;");
                        string title = DT.Rows[i]["title"].ToString();
                        firstname = DT.Rows[i]["first"].ToString();
                        fullname = firstname + " " + DT.Rows[i]["last"].ToString();
                        string photoName = DT.Rows[i]["first"].ToString();
                        string region = DT.Rows[i]["region"].ToString();
                        
			vCard = "/ajax/vcard.aspx?name_first=" + DT.Rows[i]["first"].ToString() + "&name_last=" + DT.Rows[i]["last"].ToString() + "&name_full=" + fullname + "&email=" + DT.Rows[i]["email"].ToString() + "&title=" + DT.Rows[i]["title"].ToString() + "&phone_work=" + DT.Rows[i]["phone"].ToString();
                        LiteralTitle.Text = "<title>" + fullname + " - Index Fund Advisors, Inc.</title>";
                        LiteralTitle.Text += "<meta name='description' content='" + DT.Rows[i]["bio"].ToString() + "' />";
                        AdvisorName.Text = "<span><div class='col-xs-12 col-md-9 pull-right pad-l-0'><h1 class='font-d-blue font-bree font-40 marg-t-0 advisor-name'>Tell Your Friends About Me</h1>";
                        AdvisorName.Text += "</div></span>";
			AdvisorPhone.Text += "<strong>" + fullname + "</strong><div class='advisor-creds font-14'>" + (title + credentials).TrimEnd(' ', ',') + "</div>";

			if (region != "" && region != null)
                        {
                            AdvisorPhone.Text += "<div class='advisor-creds'>" + region + "</div>";
                        }

                        foreach (string phone in phones)
                        {
                            AdvisorPhone.Text += "<div class='row'><div class='font-14 advisor-phones font-open-h col-xs-5'>" + phone.Split(':')[0] + ": </div><div class='text-right font-14 advisors-comma col-xs-7 pad-l-0'>" + phone.Split(':')[1].Replace(" ", "").Replace("/", "<br />or ") + "</div></div>";
                        }

                        AdvisorImage.Text = "<img class='width-100 advisor-image' src='/images/about/team/" + photoName + ".jpg' />";
                        AdvisorEmail.Text += "<script>CryptMailto('" + DT.Rows[i]["email"].ToString() + "', 'Email " + DT.Rows[i]["first"].ToString() + "')</script>";
                    }
                }
            }
        }
    }
}
