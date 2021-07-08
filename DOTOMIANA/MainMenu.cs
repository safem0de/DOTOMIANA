using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOTOMIANA.Models;
using Newtonsoft.Json;

namespace DOTOMIANA
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            callWebServices();
        }

        public string webGetMethod(string URL)
        {
            string jsonString = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            request.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";
            request.Accept = "/";
            request.UseDefaultCredentials = true;
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.ContentType = "application/x-www-form-urlencoded";

            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            jsonString = sr.ReadToEnd();
            sr.Close();
            return jsonString;
        }

        private void callWebServices()
        {
            string URL = "https://api.opendota.com/api/heroes";

            var getData = webGetMethod(URL);
            var result = JsonConvert.DeserializeObject<List<Heroes>>(getData);
            result.ForEach(x => { MessageBox.Show(x.localized_name); });
        }
    }
}
