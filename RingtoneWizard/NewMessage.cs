using System;
using System.Windows.Forms;

namespace RingtoneWizard
{
    public partial class NewMessage : Form
    {
        public NewMessage()
        {
            InitializeComponent();
        }
        public void Show(string text)
        {
            message.Text = text;
            base.Show();
        }

        private void dismiss_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void hideButtons()
        {
            dismiss.Hide();
        }

        public void showButtons()
        {
            dismiss.Show();
        }
    }
}
