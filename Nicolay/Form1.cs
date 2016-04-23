using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nicolay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            String word = textBox1.Text;

            if (openFileDialog1.FileName != String.Empty || openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                String c_word;

                while((c_word = sr.ReadLine()) != null)
                {
                    bool f = false;

                    for (int wj = 0; wj < c_word.Length; wj++)
                    {
                        f = false;
                        for (int j = 0; j < word.Length; j++)
                        {
                            if (c_word[wj] == word[j])
                            {
                                f = true;
                                break;
                            }
                        }
                        if (!f)
                        {
                            break;
                        }
                    }

                    if (f)
                    {
                        richTextBox1.Text += " " + c_word + "\n";
                    }
                }

                sr.Close();
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        public void addWord(String word)
        {
            if (openFileDialog1.FileName != String.Empty || openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                String c_word;

                while ((c_word = sr.ReadLine()) != null)
                {
                    if (c_word == word)
					{
                        return;
					}
                }

                sr.Close();


                StreamWriter wr = new StreamWriter(openFileDialog1.FileName, true);
                wr.Write("\n" + word);
                wr.Close();
            }
        }

        public void deleteWord(String word)
        {
            if (openFileDialog1.FileName != String.Empty || openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                List<String> c_words = new List<string>();
                String c_word;

                while ((c_word = sr.ReadLine()) != null)
                {
                    c_words.Add(c_word);
                }

                sr.Close();

                StreamWriter wr = new StreamWriter(openFileDialog1.FileName, false);
                foreach(string i in c_words)
                {
                    if(i != word)
                    {
                        wr.WriteLine(i);
                    }
                }

                wr.Close();
            }
        }

        private void добавитьСловоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WordName wnForm = new WordName(addWord);
            wnForm.ShowDialog();
        }

        private void удалитьСловоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WordName wnForm = new WordName(deleteWord);
            wnForm.ShowDialog();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.FileName != String.Empty || saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter wr = new StreamWriter(saveFileDialog1.FileName, false);
                wr.Write(richTextBox1.Text);
                wr.Close();
            }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument def = new PrintDocument();
            def.PrintPage += new PrintPageEventHandler(PRD);
            def.DocumentName = "Document1";
            def.Print();
        }
        private void PRD(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(richTextBox1.Text, Font, new SolidBrush(Color.Black), 0, 0);
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }
    }
}
