using System.Windows.Forms;
using DOTOMIANA.Controllers;


namespace DOTOMIANA
{
    public partial class MainMenu : Form
    {
        MainMenuManager a = new MainMenuManager();
        public MainMenu()
        {
            InitializeComponent();
            //MainMenuManager a = new MainMenuManager();
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
            
            //MainMenuManager b = new MainMenuManager();
            var item = a.checkTeamAvailable(selectedValue);

            if (item.Count > 1)
            {
                a.addComboBox(CmbRadiantPlayer1, item);
                a.addComboBox(CmbRadiantPlayer2, item);
                a.addComboBox(CmbRadiantPlayer3, item);
                a.addComboBox(CmbRadiantPlayer4, item);
                a.addComboBox(CmbRadiantPlayer5, item);
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

            if (CmbRadiantTeam.SelectedIndex > 0 && CmbTheDireTeam.SelectedIndex > 0)
            {
                if (CmbRadiantTeam.Text.Equals(CmbTheDireTeam.Text)){
                    MessageBox.Show("Team : "+ CmbTheDireTeam.Text +" was Selected (The Dire)");
                }
            }
        }
        
        private void CmbRadiantHero1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //MainMenuManager a = new MainMenuManager();
            a.getImagefromComboBox(CmbRadiantHero1, PicRadiant_Hero1);
            ComboBox[] Rad = { CmbRadiantHero1, CmbRadiantHero2, CmbRadiantHero3, CmbRadiantHero4, CmbRadiantHero5 };
            ComboBox[] Dire = { CmbTheDireHero1, CmbTheDireHero2, CmbTheDireHero3, CmbTheDireHero4, CmbTheDireHero5 };
            a.checkDuplicateHero(Rad, Dire, 1, true);
        }

        private void CmbRadiantHero2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //MainMenuManager a = new MainMenuManager();
            a.getImagefromComboBox(CmbRadiantHero2, PicRadiant_Hero2);

            ComboBox[] Rad = { CmbRadiantHero1, CmbRadiantHero2, CmbRadiantHero3, CmbRadiantHero4, CmbRadiantHero5 };
            ComboBox[] Dire = { CmbTheDireHero1, CmbTheDireHero2, CmbTheDireHero3, CmbTheDireHero4, CmbTheDireHero5 };
            a.checkDuplicateHero(Rad, Dire, 2, true);

        }

        private void CmbRadiantHero3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            a.getImagefromComboBox(CmbRadiantHero3, PicRadiant_Hero3);
            ComboBox[] Rad = { CmbRadiantHero1, CmbRadiantHero2, CmbRadiantHero3, CmbRadiantHero4, CmbRadiantHero5 };
            ComboBox[] Dire = { CmbTheDireHero1, CmbTheDireHero2, CmbTheDireHero3, CmbTheDireHero4, CmbTheDireHero5 };
            a.checkDuplicateHero(Rad, Dire, 3, true);
        }

        private void CmbRadiantHero4_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            a.getImagefromComboBox(CmbRadiantHero4, PicRadiant_Hero4);
            ComboBox[] Rad = { CmbRadiantHero1, CmbRadiantHero2, CmbRadiantHero3, CmbRadiantHero4, CmbRadiantHero5 };
            ComboBox[] Dire = { CmbTheDireHero1, CmbTheDireHero2, CmbTheDireHero3, CmbTheDireHero4, CmbTheDireHero5 };
            a.checkDuplicateHero(Rad, Dire, 4, true);
        }

        private void CmbRadiantHero5_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            a.getImagefromComboBox(CmbRadiantHero5, PicRadiant_Hero5);
            ComboBox[] Rad = { CmbRadiantHero1, CmbRadiantHero2, CmbRadiantHero3, CmbRadiantHero4, CmbRadiantHero5 };
            ComboBox[] Dire = { CmbTheDireHero1, CmbTheDireHero2, CmbTheDireHero3, CmbTheDireHero4, CmbTheDireHero5 };
            a.checkDuplicateHero(Rad, Dire, 5, true);
        }

        private void CmbTheDireHero1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            a.getImagefromComboBox(CmbTheDireHero1, PicTheDire_Hero1);
            ComboBox[] Rad = { CmbRadiantHero1, CmbRadiantHero2, CmbRadiantHero3, CmbRadiantHero4, CmbRadiantHero5 };
            ComboBox[] Dire = { CmbTheDireHero1, CmbTheDireHero2, CmbTheDireHero3, CmbTheDireHero4, CmbTheDireHero5 };
            a.checkDuplicateHero(Rad, Dire, 1, false);
        }

        private void CmbTheDireHero2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            a.getImagefromComboBox(CmbTheDireHero2, PicTheDire_Hero2);
            ComboBox[] Rad = { CmbRadiantHero1, CmbRadiantHero2, CmbRadiantHero3, CmbRadiantHero4, CmbRadiantHero5 };
            ComboBox[] Dire = { CmbTheDireHero1, CmbTheDireHero2, CmbTheDireHero3, CmbTheDireHero4, CmbTheDireHero5 };
            a.checkDuplicateHero(Rad, Dire, 2, false);
        }

        private void CmbTheDireHero3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            a.getImagefromComboBox(CmbTheDireHero3, PicTheDire_Hero3);
            ComboBox[] Rad = { CmbRadiantHero1, CmbRadiantHero2, CmbRadiantHero3, CmbRadiantHero4, CmbRadiantHero5 };
            ComboBox[] Dire = { CmbTheDireHero1, CmbTheDireHero2, CmbTheDireHero3, CmbTheDireHero4, CmbTheDireHero5 };
            a.checkDuplicateHero(Rad, Dire, 3, false);
        }

        private void CmbTheDireHero4_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            a.getImagefromComboBox(CmbTheDireHero4, PicTheDire_Hero4);
            ComboBox[] Rad = { CmbRadiantHero1, CmbRadiantHero2, CmbRadiantHero3, CmbRadiantHero4, CmbRadiantHero5 };
            ComboBox[] Dire = { CmbTheDireHero1, CmbTheDireHero2, CmbTheDireHero3, CmbTheDireHero4, CmbTheDireHero5 };
            a.checkDuplicateHero(Rad, Dire, 4, false);
        }

        private void CmbTheDireHero5_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            a.getImagefromComboBox(CmbTheDireHero5, PicTheDire_Hero5);
            ComboBox[] Rad = { CmbRadiantHero1, CmbRadiantHero2, CmbRadiantHero3, CmbRadiantHero4, CmbRadiantHero5 };
            ComboBox[] Dire = { CmbTheDireHero1, CmbTheDireHero2, CmbTheDireHero3, CmbTheDireHero4, CmbTheDireHero5 };
            a.checkDuplicateHero(Rad, Dire, 5, false);
        }

        private void CmbTheDireTeam_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedValue = (int)cmb.SelectedValue;

            var item = a.checkTeamAvailable(selectedValue);

            if (item.Count > 1)
            {
                a.addComboBox(CmbTheDirePlayer1, item);
                a.addComboBox(CmbTheDirePlayer2, item);
                a.addComboBox(CmbTheDirePlayer3, item);
                a.addComboBox(CmbTheDirePlayer4, item);
                a.addComboBox(CmbTheDirePlayer5, item);
            }
            else
            {
                CmbTheDireTeam.SelectedIndex = 0;
                CmbTheDirePlayer1.DataSource = null;
                CmbTheDirePlayer2.DataSource = null;
                CmbTheDirePlayer3.DataSource = null;
                CmbTheDirePlayer4.DataSource = null;
                CmbTheDirePlayer5.DataSource = null;
                CmbTheDirePlayer1.Items.Clear();
                CmbTheDirePlayer2.Items.Clear();
                CmbTheDirePlayer3.Items.Clear();
                CmbTheDirePlayer4.Items.Clear();
                CmbTheDirePlayer5.Items.Clear();
                MessageBox.Show(selectedValue.ToString() + " : This Team Not Available to Select");
            }
        }
    }
}
