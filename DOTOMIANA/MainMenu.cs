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
            a.callWebServices();
        }

    }
}
