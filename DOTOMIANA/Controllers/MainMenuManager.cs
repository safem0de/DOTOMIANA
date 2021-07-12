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

            try
            {
                WebResponse response = request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                jsonString = sr.ReadToEnd();
                sr.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return jsonString;
        }

        public void addComboBox(ComboBox comboBox, Dictionary<int,string> item)
        {
            comboBox.DataSource = new BindingSource(item, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public void addComboBoxTeam(ComboBox comboBox)
        {
        //https://stackoverflow.com/questions/17461367/can-linq-foreach-have-if-statement/17461394
            
            string URL = "https://api.opendota.com/api/teams";
            var item = new Dictionary<int, string>();
            item.Add(0, "Pls. Select Team");
            var getData = webGetMethod(URL);

            var result = JsonConvert.DeserializeObject<List<Teams>>(getData);

            if (result != null)
            {
                result.Where(x => !x.name.Equals("")).ToList()
                .ForEach(x => {
                    item.Add(x.team_id, x.name);
                });

                addComboBox(comboBox, item);
            }

        }

        public void addToComboBoxHeroes(ComboBox comboBox)
        {
            var settings = new JsonSerializerSettings
            {
                //https://stackoverflow.com/questions/31813055/how-to-handle-null-empty-values-in-jsonconvert-deserializeobject
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            string URL = "https://api.opendota.com/api/heroes";
            var getData = webGetMethod(URL);
            var result = JsonConvert.DeserializeObject<List<Heroes>>(getData,settings);
            var item = new Dictionary<int, string>();
            item.Add(0, "Pls. Select Hero");

            if (result != null)
            {
                result.ForEach(x => {
                    item.Add(x.id, x.localized_name);
                });

                addComboBox(comboBox, item);
            }
            
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
                        item.Add(y.account_id, y.name);
                    }
                });
            return item;
        }

        public void getImagefromComboBox(ComboBox cmb,PictureBox pic)
        {
            if (cmb.SelectedIndex > 0)
            {
                var Hero = cmb.Text.Replace("-", "").Replace(" ", "_").ToString().ToLower();
                //MessageBox.Show(Hero);
                switch (Hero)
                {
                    case "shadow_fiend":
                        Hero = "nevermore";
                        break;
                    case "queen_of_pain":
                        Hero = "queenofpain";
                        break;
                    case "vengeful_spirit":
                        Hero = "vengefulspirit";
                        break;
                    case "windranger":
                        Hero = "windrunner";
                        break;
                    case "zeus":
                        Hero = "zuus";
                        break;
                    case "necrophos":
                        Hero = "necrolyte";
                        break;
                    case "wraith_king":
                        Hero = "skeleton_king";
                        break;
                    case "nature's_prophet":
                        Hero = "furion";
                        break;
                    case "clockwerk":
                        Hero = "rattletrap";
                        break;
                    case "io":
                        Hero = "wisp";
                        break;
                    case "lifestealer":
                        Hero = "life_stealer";
                        break;
                    case "doom":
                        Hero = "doom_bringer";
                        break;
                    case "outworld_destroyer":
                        Hero = "obsidian_destroyer";
                        break;
                    case "treant_protector":
                        Hero = "treant";
                        break;
                    case "centaur_warrunner":
                        Hero = "centaur";
                        break;
                    case "magnus":
                        Hero = "magnataur";
                        break;
                    case "timbersaw":
                        Hero = "shredder";
                        break;
                    case "underlord":
                        Hero = "abyssal_underlord";
                        break;
                }
                string URL = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/" + Hero + ".png";
                pic.ImageLocation = URL;
                pic.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pic.Image = null;
                pic.Refresh();
            }
        }

        public void checkDuplicateHero(ComboBox[] Rad,ComboBox[] Dire,int HeroNum, bool RadiantSide)
        {
            int x = HeroNum - 1;
            if (RadiantSide == true)
            {
                for (int i = 0; i < Rad.Length; i++)
                {
                    if (i != x)
                    {
                        if (Rad[x].SelectedIndex > 0 && Rad[i].SelectedIndex > 0)
                        {
                            if (Rad[x].Text.Equals(Rad[i].Text))
                            {
                                MessageBox.Show(Rad[x].Text + " Already Pick");
                                Rad[x].SelectedIndex = 0;
                            }
                        }
                    }
                }

                for (int i = 0; i < Dire.Length; i++)
                {
                    if (Rad[x].SelectedIndex > 0 && Dire[i].SelectedIndex > 0)
                    {
                        if (Rad[x].Text.Equals(Dire[i].Text))
                        {
                            MessageBox.Show(Rad[x].Text + " Already Pick");
                            Rad[x].SelectedIndex = 0;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Dire.Length; i++)
                {
                    if (i != x)
                    {
                        if (Dire[x].SelectedIndex > 0 && Dire[i].SelectedIndex > 0)
                        {
                            if (Dire[x].Text.Equals(Dire[i].Text))
                            {
                                MessageBox.Show(Dire[x].Text + " Already Pick");
                                Dire[x].SelectedIndex = 0;
                            }
                        }
                    }
                }

                for (int i = 0; i < Rad.Length; i++)
                {
                    if (Dire[x].SelectedIndex > 0 && Rad[i].SelectedIndex > 0)
                    {
                        if (Dire[x].Text.Equals(Rad[i].Text))
                        {
                            MessageBox.Show(Dire[x].Text + " Already Pick");
                            Dire[x].SelectedIndex = 0;
                        }
                    }
                }
            }
        }
    }
}
