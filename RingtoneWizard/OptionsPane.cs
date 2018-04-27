using System.Collections.Generic;
using System.Windows.Forms;

namespace RingtoneWizard
{
    public partial class OptionsPane : Form
    {
        private CustomTrackbar custom;
        private float[] point;

        public OptionsPane()
        {
            InitializeComponent();
        }

        public void Show(float[] point, CustomTrackbar trackbar)
        {
            base.Show();
            this.point = point;
            this.custom = trackbar;
            defaultView();
        }

        private void defaultView()
        {
            deletePointButton.Show();
            editButton.Show();
            xLabel.Hide();
            yLabel.Hide();
            xText.Hide();
            yText.Hide();
            cancelButton.Show();
            saveButton.Hide();
            cancelEditButton.Hide();
        }

        private void deletePointButton_Click(object sender, System.EventArgs e)
        {
            List<float[]> temp = custom.getSets();
            temp.Remove(point);
            custom.setSets(temp);
            this.Hide();
        }

        private void editButton_Click(object sender, System.EventArgs e)
        {
            deletePointButton.Hide();
            editButton.Hide();
            cancelButton.Hide();
            xLabel.Show();
            xText.Text = point[0].ToString();
            yLabel.Show();
            yText.Text = point[1].ToString();
            xText.Show();
            yText.Show();
            saveButton.Show();
            cancelEditButton.Show();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void cancelEditButton_Click(object sender, System.EventArgs e)
        {
            defaultView();
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            if (float.Parse(xText.Text) < 0 || float.Parse(yText.Text) > custom.Width)
            {
                DialogResult result = MessageBox.Show("Must be between 0 and " + custom.Width, "Error", MessageBoxButtons.OK);
            }
            else
            {
                float[] temp = new float[2] { float.Parse(xText.Text), float.Parse(yText.Text) };
                List<float[]> t = custom.getSets();
                t.Remove(point);
                t.Add(temp);
                custom.setSets(t);
                this.Hide();
            }
        }
    }
}
