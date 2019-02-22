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
namespace CustomMessageBox
{
    public partial class MyCustomMessageBox : MetroForm
    {
        public enum State { SUCCESS, ERROR, WARNING }
        public MyCustomMessageBox()
        {
            InitializeComponent();
        }
        public MyCustomMessageBox(State state, string message)
        {
            InitializeComponent();
            switch (state)
            {
                case State.SUCCESS:
                    this.Text = "SUCCESS";
                    this.Style = MetroColorStyle.Green;
                    break;
                case State.ERROR:
                    this.Text = "ERROR";
                    this.Style = MetroColorStyle.Red;
                    break;
                case State.WARNING:
                    this.Text = "WARNING";
                    this.Style = MetroColorStyle.Orange;
                    break;
                default:
                    break;
            }
            MessageInlineBox.Text = message;
        }


        public MyCustomMessageBox(State state, string message, MessageBoxButtons messageBoxButtons, out DialogResult dialogResult)
        {
            InitializeComponent();
            switch (state)
            {
                case State.SUCCESS:
                    this.Text = "SUCCESS";
                    this.Style = MetroColorStyle.Green;
                    break;
                case State.ERROR:
                    this.Text = "ERROR";
                    this.Style = MetroColorStyle.Red;
                    break;
                case State.WARNING:
                    this.Text = "WARNING";
                    this.Style = MetroColorStyle.Orange;
                    break;
                default:
                    break;
            }
            MessageInlineBox.Text = message;

            switch (messageBoxButtons)
            {
                case MessageBoxButtons.OK:
                    dialogResult = (DialogResult)MessageBoxButtons.OK;
                    break;
                case MessageBoxButtons.OKCancel:
                    dialogResult = (DialogResult)MessageBoxButtons.OKCancel;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    dialogResult = (DialogResult)MessageBoxButtons.AbortRetryIgnore;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    dialogResult = (DialogResult)MessageBoxButtons.YesNoCancel;
                    break;
                case MessageBoxButtons.YesNo:
                    dialogResult = (DialogResult)MessageBoxButtons.YesNo;
                    break;
                case MessageBoxButtons.RetryCancel:
                    dialogResult = (DialogResult)MessageBoxButtons.RetryCancel;
                    break;
                default:
                    dialogResult = (DialogResult)MessageBoxButtons.OK;
                    break;
            }
        }
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormattedMessage(string unformattedMessage, out string formattedMessage)
        {
            
            formattedMessage = unformattedMessage;
        }
    }
}