using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DgtWeb
{
    public partial class CreateDenuncia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ComplaintType> cts = GetTiposDenuncia();
            foreach (var ct in cts)
            {
                ddlComplaintType.Items.Add(new ListItem(ct.Name, ct.Id.ToString()));
            }            

            if (IsPostBack)
            {
                var email = txtEmail.Text;
                var details = txtDetails.Text;
                var phone = txtPhone.Text;
                var address = txtAddress.Text;
                var complaintDate = DateTime.Now;
                var complaiantType = int.Parse( ddlComplaintType.SelectedValue);

                var json = string.Format(@"{{
                    ""emailuser"":""{0}"",
                    ""details"":""{1}"",
                    ""phone"":""{2}"",
                    ""address"":""{3}"",
                    ""complaintdate"":""{4}"",
                    ""complainttypeid"":{5},
                    ""closed"":false
                }}", email, details, phone, address,complaintDate.ToString("yyyy-MM-dd HH:mm:ss"), complaiantType);
                SendPostJSON(json);
                Response.Redirect("~/",true);
            }
            else
            {
                
            }
        }

        public void SendPostJSON(string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://dgtwebapi.azurewebsites.net/api/Complaints");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public List<ComplaintType> GetTiposDenuncia()
        {            
            string sUrlRequest = "https://dgtwebapi.azurewebsites.net/api/ComplaintTypes";
            var json = new WebClient().DownloadString(sUrlRequest);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<ComplaintType> cts = ser.Deserialize<List<ComplaintType>>(json);            
            return cts;
        }
    }
}