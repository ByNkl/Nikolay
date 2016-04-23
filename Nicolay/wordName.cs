using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nicolay
{
    public partial class WordName : Form
    {
        public delegate void onWord(String word);

        onWord callback;

        public WordName(onWord cb)
        {
            InitializeComponent();
            callback = cb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                callback(textBox1.Text);
                Hide();
            }
        }
    }
}
