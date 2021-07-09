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
            ComboBox cmb = (ComboBox)sender;
            int selectedValue = (int)cmb.SelectedValue;
            var x = new MainMenuManager();
            var Hero = CmbRadiantHero1.Text.ToString().ToLower();
            var URL = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/" + Hero + ".png";
            var Bool = x.checkURLImg(URL);

            PicRadiant_Hero1.Image = null;
            PicRadiant_Hero1.SizeMode = PictureBoxSizeMode.Zoom;

            //MessageBox.Show(Hero.ToString());

            if (Bool is false)
            {
                Hero = Hero.Replace(" ", "_").Replace("-", "");
                URL = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/" + Hero + ".png";
                Bool = x.checkURLImg(URL);
                if (Bool is true)
                {
                    //MessageBox.Show(y.ToString());
                }
                else
                {
                    if (Hero.Contains("fiend")) {
                        Hero = "nevermore";
                        URL = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/" + Hero + ".png";
                    }
                    else
                    {
                        MessageBox.Show("Not Found Hero Image");
                    }
                }
            }
            //MessageBox.Show(URL);
            PicRadiant_Hero1.Load(URL);
        }
    }
}
