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
            int selectedValue = (int)cmb.SelectedValue;
            ComboBox[] Rad_Pl = { CmbRadiantPlayer1, CmbRadiantPlayer2, CmbRadiantPlayer3, CmbRadiantPlayer4, CmbRadiantPlayer5 };

            var item = a.checkTeamAvailable(selectedValue);

            if (item.Count > 1) // because checkTeam... Add Pls. Select Player
            {
                for(int i = 0; i < Rad_Pl.Length; i++)
                {
                    a.addComboBox(Rad_Pl[i], item);
                }
            }
            else
            {
                if (CmbRadiantTeam.SelectedIndex > 0)
                {
                    MessageBox.Show(selectedValue.ToString() + " : This Team Not Available to Select");
                }

                CmbRadiantTeam.SelectedIndex = 0;
                for (int i = 0; i < Rad_Pl.Length; i++)
                {
                    Rad_Pl[i].DataSource = null;
                    Rad_Pl[i].Items.Clear();
                }
            }

            // Clear If Other Side Select Team and it's Duplicate
            if (CmbRadiantTeam.SelectedIndex > 0 && CmbTheDireTeam.SelectedIndex > 0)
            {
                if (CmbRadiantTeam.Text.Equals(CmbTheDireTeam.Text)){
                    CmbRadiantTeam.SelectedIndex = 0;
                    for (int i = 0; i < Rad_Pl.Length; i++)
                    {
                        Rad_Pl[i].DataSource = null;
                        Rad_Pl[i].Items.Clear();
                    }
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
            ComboBox[] Dire_Pl = { CmbTheDirePlayer1, CmbTheDirePlayer2, CmbTheDirePlayer3, CmbTheDirePlayer4, CmbTheDirePlayer5 };

            var item = a.checkTeamAvailable(selectedValue);

            if (item.Count > 1) // because checkTeam... Add Pls. Select Player
            {
                for (int i = 0; i < Dire_Pl.Length; i++)
                {
                    a.addComboBox(Dire_Pl[i], item);
                }
            }
            else
            {
                if (CmbRadiantTeam.SelectedIndex > 0)
                {
                    MessageBox.Show(selectedValue.ToString() + " : This Team Not Available to Select");
                }

                CmbRadiantTeam.SelectedIndex = 0;
                for (int i = 0; i < Dire_Pl.Length; i++)
                {
                    Dire_Pl[i].DataSource = null;
                    Dire_Pl[i].Items.Clear();
                }
            }

            // Clear If Other Side Select Team and it's Duplicate
            if (CmbRadiantTeam.SelectedIndex > 0 && CmbTheDireTeam.SelectedIndex > 0)
            {
                if (CmbRadiantTeam.Text.Equals(CmbTheDireTeam.Text))
                {
                    CmbRadiantTeam.SelectedIndex = 0;
                    for (int i = 0; i < Dire_Pl.Length; i++)
                    {
                        Dire_Pl[i].DataSource = null;
                        Dire_Pl[i].Items.Clear();
                    }
                    MessageBox.Show("Team : " + CmbTheDireTeam.Text + " was Selected (Radiant)");
                }
            }
        }

        private void CmbRadiantPlayer1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox[] Rad_Pl = { CmbRadiantPlayer1, CmbRadiantPlayer2, CmbRadiantPlayer3, CmbRadiantPlayer4, CmbRadiantPlayer5 };
            a.checkPlayerDuplicate(Rad_Pl, 1);
        }

        private void CmbRadiantPlayer2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox[] Rad_Pl = { CmbRadiantPlayer1, CmbRadiantPlayer2, CmbRadiantPlayer3, CmbRadiantPlayer4, CmbRadiantPlayer5 };
            a.checkPlayerDuplicate(Rad_Pl, 2);
        }

        private void CmbRadiantPlayer3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox[] Rad_Pl = { CmbRadiantPlayer1, CmbRadiantPlayer2, CmbRadiantPlayer3, CmbRadiantPlayer4, CmbRadiantPlayer5 };
            a.checkPlayerDuplicate(Rad_Pl, 3);
        }

        private void CmbRadiantPlayer4_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox[] Rad_Pl = { CmbRadiantPlayer1, CmbRadiantPlayer2, CmbRadiantPlayer3, CmbRadiantPlayer4, CmbRadiantPlayer5 };
            a.checkPlayerDuplicate(Rad_Pl, 4);
        }

        private void CmbRadiantPlayer5_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox[] Rad_Pl = { CmbRadiantPlayer1, CmbRadiantPlayer2, CmbRadiantPlayer3, CmbRadiantPlayer4, CmbRadiantPlayer5 };
            a.checkPlayerDuplicate(Rad_Pl, 5);
        }

        private void CmbTheDirePlayer1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox[] Dire_Pl = { CmbTheDirePlayer1, CmbTheDirePlayer2, CmbTheDirePlayer3, CmbTheDirePlayer4, CmbTheDirePlayer5 };
            a.checkPlayerDuplicate(Dire_Pl, 1);
        }

        private void CmbTheDirePlayer2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox[] Dire_Pl = { CmbTheDirePlayer1, CmbTheDirePlayer2, CmbTheDirePlayer3, CmbTheDirePlayer4, CmbTheDirePlayer5 };
            a.checkPlayerDuplicate(Dire_Pl, 2);
        }

        private void CmbTheDirePlayer3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox[] Dire_Pl = { CmbTheDirePlayer1, CmbTheDirePlayer2, CmbTheDirePlayer3, CmbTheDirePlayer4, CmbTheDirePlayer5 };
            a.checkPlayerDuplicate(Dire_Pl, 3);
        }

        private void CmbTheDirePlayer4_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox[] Dire_Pl = { CmbTheDirePlayer1, CmbTheDirePlayer2, CmbTheDirePlayer3, CmbTheDirePlayer4, CmbTheDirePlayer5 };
            a.checkPlayerDuplicate(Dire_Pl, 4);
        }

        private void CmbTheDirePlayer5_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox[] Dire_Pl = { CmbTheDirePlayer1, CmbTheDirePlayer2, CmbTheDirePlayer3, CmbTheDirePlayer4, CmbTheDirePlayer5 };
            a.checkPlayerDuplicate(Dire_Pl, 5);
        }
    }
}
