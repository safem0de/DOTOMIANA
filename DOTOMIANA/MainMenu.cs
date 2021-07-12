using System.Windows.Forms;
using DOTOMIANA.Controllers;


namespace DOTOMIANA
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            MainMenuManager a = new MainMenuManager();
            a.addToComboBoxHeroes(CmbRadiantHero1);
            a.addToComboBoxHeroes(CmbRadiantHero2);
            a.addToComboBoxHeroes(CmbRadiantHero3);
            a.addToComboBoxHeroes(CmbRadiantHero4);
            a.addToComboBoxHeroes(CmbRadiantHero5);
            a.addToComboBoxHeroes(CmbTheDireHero1);
            a.addToComboBoxHeroes(CmbTheDireHero2);
            a.addToComboBoxHeroes(CmbTheDireHero3);
            a.addToComboBoxHeroes(CmbTheDireHero4);
            a.addToComboBoxHeroes(CmbTheDireHero5);
            a.addComboBoxTeam(CmbRadiantTeam);
            a.addComboBoxTeam(CmbTheDireTeam);
        }

        private void CmbRadiantTeam_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        //https://stackoverflow.com/questions/6901070/getting-selected-value-of-a-combobox

            ComboBox cmb = (ComboBox)sender;
            //var selectedIndex = cmb.SelectedIndex;
            int selectedValue = (int)cmb.SelectedValue;
            //MessageBox.Show(selectedValue.ToString());
            
            MainMenuManager b = new MainMenuManager();
            var item = b.checkTeamAvailable(selectedValue);

            if (item.Count > 1)
            {
                b.addComboBox(CmbRadiantPlayer1, item);
                b.addComboBox(CmbRadiantPlayer2, item);
                b.addComboBox(CmbRadiantPlayer3, item);
                b.addComboBox(CmbRadiantPlayer4, item);
                b.addComboBox(CmbRadiantPlayer5, item);
            }
            else
            {
                CmbRadiantTeam.SelectedIndex = 0;
                CmbRadiantPlayer1.DataSource = null;
                CmbRadiantPlayer2.DataSource = null;
                CmbRadiantPlayer3.DataSource = null;
                CmbRadiantPlayer4.DataSource = null;
                CmbRadiantPlayer5.DataSource = null;
                CmbRadiantPlayer1.Items.Clear();
                CmbRadiantPlayer2.Items.Clear();
                CmbRadiantPlayer3.Items.Clear();
                CmbRadiantPlayer4.Items.Clear();
                CmbRadiantPlayer5.Items.Clear();
                MessageBox.Show(selectedValue.ToString()+" : This Team Not Available to Select");
            }
        }
        
        private void CmbRadiantHero1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //if (CmbRadiantHero1.SelectedIndex > 0)
            //{
            //    var Hero = CmbRadiantHero1.Text.Replace("-","").Replace(" ","_").ToString().ToLower();
            //    //MessageBox.Show(Hero);
            //    switch (Hero)
            //    {
            //        case "shadow_fiend":
            //            Hero = "nevermore";
            //            break;
            //        case "queen_of_pain":
            //            Hero = "queenofpain";
            //            break;
            //        case "vengeful_spirit":
            //            Hero = "vengefulspirit";
            //            break;
            //        case "windranger":
            //            Hero = "windrunner";
            //            break;
            //        case "zeus":
            //            Hero = "zuus";
            //            break;
            //        case "necrophos":
            //            Hero = "necrolyte";
            //            break;
            //        case "wraith_king":
            //            Hero = "skeleton_king";
            //            break;
            //        case "nature's_prophet":
            //            Hero = "furion";
            //            break;
            //        case "clockwerk":
            //            Hero = "rattletrap";
            //            break;
            //        case "io":
            //            Hero = "wisp";
            //            break;
            //        case "lifestealer":
            //            Hero = "life_stealer";
            //            break;
            //        case "doom":
            //            Hero = "doom_bringer";
            //            break; 
            //        case "outworld_destroyer":
            //            Hero = "obsidian_destroyer";
            //            break;
            //        case "treant_protector":
            //            Hero = "treant";
            //            break;
            //        case "centaur_warrunner":
            //            Hero = "centaur";
            //            break;
            //        case "magnus":
            //            Hero = "magnataur";
            //            break;
            //        case "timbersaw":
            //            Hero = "shredder";
            //            break;
            //        case "underlord":
            //            Hero = "abyssal_underlord";
            //            break;
            //    }
            //    string URL = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/"+Hero+".png";
            //    PicRadiant_Hero1.ImageLocation = URL;
            //    PicRadiant_Hero1.SizeMode = PictureBoxSizeMode.Zoom;
            //}
            //else
            //{
            //    PicRadiant_Hero1.Image = null;
            //    PicRadiant_Hero1.Refresh();
            //}
            
        }
    }
}
