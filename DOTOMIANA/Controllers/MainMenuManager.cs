using DOTOMIANA.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOTOMIANA.Controllers
{
    class MainMenuManager
    {
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

        public void addComboBox(ComboBox comboBox, Dictionary<int,string> item)
        {
            comboBox.DataSource = new BindingSource(item, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public Boolean checkURLImg(string URL)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
            request.Method = "HEAD";

            bool exists;
            try
            {
                request.GetResponse();
                exists = true;
            }
            catch
            {
                exists = false;
            }

            return exists;
        }

        public void addComboBoxTeam(ComboBox comboBox)
        {
        //https://stackoverflow.com/questions/17461367/can-linq-foreach-have-if-statement/17461394
            
            string URL = "https://api.opendota.com/api/teams";
            var item = new Dictionary<int, string>();
            item.Add(0, "Pls. Select Team");
            var getData = webGetMethod(URL);
            var result = JsonConvert.DeserializeObject<List<Teams>>(getData);
            //result.ForEach(x => { MessageBox.Show(x.team_id.ToString(),x.name); });
            //result.Where(x => !x.name.Equals("")).ToList()
            //    .ForEach(x => { MessageBox.Show(x.team_id.ToString(), x.name); });
            result.Where(x => !x.name.Equals("")).ToList()
                .ForEach(x => {
                    item.Add(x.team_id, x.name);
                });

            //List<int> keyList = new List<int>(item.Keys);

            //foreach (int entry in keyList)
            //{
            //    // do something with entry.Value or entry.Key
            //    //MessageBox.Show(entry.Key.ToString() + " : " + entry.Value);
            //    string URL2 = "https://api.opendota.com/api/teams/"+entry.ToString()+"/players";
            //    MessageBox.Show(URL2);
            //    var getData2 = webGetMethod(URL2);
            //    var result2 = JsonConvert.DeserializeObject<List<Players>>(getData2, settings);
            //    var count = 0;
            //    result2.Where(y => !String.IsNullOrEmpty(y.name) &&
            //                        !y.name.Equals("")).ToList()
            //        .ForEach(y =>
            //        {
            //            if (y.is_current_team_member)
            //            {
            //            //MessageBox.Show(y.account_id.ToString() + " : " + x.name + " : " + y.is_current_team_member);
            //            count++;
            //            }

            //            if (count < 5)
            //            {
            //                //MessageBox.Show(x.name +" : "+ count.ToString());
            //                item.Remove(entry);
            //            }
            //        });
            //}

            //comboBox.DataSource = new BindingSource(item, null);
            //comboBox.DisplayMember = "Value";
            //comboBox.ValueMember = "Key";
            addComboBox(comboBox, item);

        }

        public void addToComboBoxHeroes(ComboBox comboBox)
        {
            string URL = "https://api.opendota.com/api/heroes";
            var getData = webGetMethod(URL);
            var result = JsonConvert.DeserializeObject<List<Heroes>>(getData);
            var item = new Dictionary<int, string>();
            item.Add(0, "Pls. Select Hero");
            result.ForEach(x => {
                item.Add(x.id, x.localized_name);
            });

            comboBox.DataSource = new BindingSource(item, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            //addComboBox(comboBox, item);
        }

        public Dictionary<int,string> checkTeamAvailable(int team_id)
        {
            var settings = new JsonSerializerSettings
            {
                //https://stackoverflow.com/questions/31813055/how-to-handle-null-empty-values-in-jsonconvert-deserializeobject
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            string URL = "https://api.opendota.com/api/teams/" + team_id.ToString() + "/players";
            var getData = webGetMethod(URL);
            var result = JsonConvert.DeserializeObject<List<Players>>(getData, settings);

            var item = new Dictionary<int, string>();
            item.Add(0, "Pls. Select Player");

            result.Where(y => !String.IsNullOrEmpty(y.name) &&
                                !y.name.Equals("")).ToList()
                .ForEach(y =>
                {
                    if (y.is_current_team_member)
                    {
                        //MessageBox.Show(y.account_id.ToString() + " : " + x.name + " : " + y.is_current_team_member);
                        item.Add(y.account_id, y.name);
                    }
                });
            return item;
        }
    }
}
