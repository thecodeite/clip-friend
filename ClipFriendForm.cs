using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codeite.ClipFriend;

namespace ClipChanger
{
    public partial class ClipFriendForm : Form
    {

        public ClipFriendForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var test = "sam";
            if (Clipboard.ContainsText())
            {
                textBox1.Text = Clipboard.GetText();
            }

            ClipboardNotification.ClipboardUpdate += ClipboardNotification_ClipboardUpdate;
        }

        void ClipboardNotification_ClipboardUpdate(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                textBox1.Text = Clipboard.GetText();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var transform = "@\"" + textBox1.Text.Replace("\"", "\"\"") + "\"";
            textBox1.Text = transform;
            Clipboard.SetText(transform);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var transform = Rot18.Convert(textBox1.Text);
            textBox1.Text = transform;
            Clipboard.SetText(transform);
        }
    }
}
