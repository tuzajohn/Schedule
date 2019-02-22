using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace Staff_Schedulling_System
{
    public partial class MaterialMessageBox : MaterialForm
    {
        private readonly MaterialSkinManager loginSkin;
        public enum State { SUCCESS, ERROR }
        public MaterialMessageBox(State state, string message)
        {
            InitializeComponent();            
            loginSkin = MaterialSkinManager.Instance;
            loginSkin.AddFormToManage(this);
            loginSkin.Theme = MaterialSkinManager.Themes.LIGHT;
            switch (state)
            {
                case State.SUCCESS:
                    this.Text = "SUCCESS";
                    loginSkin.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.LightBlue200, TextShade.WHITE);
                    break;
                case State.ERROR:
                    this.Text = "ERROR";
                    loginSkin.ColorScheme = new ColorScheme(Primary.Red800, Primary.Red900, Primary.Red500, Accent.LightBlue200, TextShade.WHITE);
                    break;
                default:
                    break;
            }
            MessageInlineBox.Text = message;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
