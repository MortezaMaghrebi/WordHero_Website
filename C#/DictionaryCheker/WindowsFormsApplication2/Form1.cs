using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> allwords = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if(op.ShowDialog()==DialogResult.OK)
            {
                string str = System.IO.File.ReadAllText(op.FileName);
                str = str.Replace("\r\n", "\n");
                str = str.Replace("\r", "");
                string[] lines = str.Split('\n');
                string[] linesfa = richTextBox2.Text.Replace("\r\n","\n").Split('\n');
                string newfile = "";
                string rtx = "";
                string corrects = "";
                string faults1 = "";
                string faults2 = "";
                string witoutexampleFa = "";
                string onlyexamples = "";
                int corrected = 0;
                for (int i=0;i<lines.Length;i++)
                {
                    string line = lines[i];
                    string[] items= line.Split('#');

                    if(items.Length==7)
                    {
                        String word = items[0];
                        String persian = items[1].Replace("،", ",");
                        string newpersian = "";
                        
                        foreach (string s in persian.Split(','))
                        {
                            if (IsOnlyPersian(s))
                            {
                                if (newpersian.Length > 0) newpersian += "، ";
                                newpersian += s.Trim() ;
                            }
                        }
                        persian = newpersian;
                        
                        String example = items[2];
                        String definition = items[3];
                        String level = items[4];
                        String pronounce = items[5];
                        String examplefa = items[6];
                        if(examplefa.Contains(word))
                        {
                            string pers = persian.Split('،')[0].Replace(" کردن", "").Replace(" شدن", "");
                            if (pers.Length > 0)
                            {
                                examplefa = examplefa.Replace(word, pers);
                                if (IsOnlyPersian(examplefa))
                                {
                                    corrected++;
                                }
                            }else
                            {
                                int a = 10;
                            }
                        }
                        newfile = word + "#" + persian + "#" + example + "#" + definition + "#" + level + "#" + pronounce + "#" + examplefa;
                        if (IsOnlyPersian(persian) && IsOnlyPersian(examplefa) && persian.Length>0)
                        {
                            //corrects += newfile + "\r\n";
                            if(!allwords.Contains(word)) corrects += newfile + "\r\n";
                        }
                        else
                        {
                            if (IsOnlyPersian(persian) && persian.Length > 0)
                            {
                                witoutexampleFa += word + "#" + persian + "#" + example + "#" + definition + "#" + level + "#" + pronounce + "#" + "\r\n";
                                onlyexamples += example + "\r\n";
                            }
                            else
                            {
                                faults1 += word + "\r\n";
                            }
                            //FindNonPersianParts(persian);
                            //FindNonPersianParts(examplefa);
                            //FindNonPersianParts(persian);
                            //IsOnlyPersian(persian);
                            //  bool isper = IsOnlyPersian(persian);
                            //  bool isexa = IsOnlyPersian(examplefa);
                            //  IsOnlyPersian(persian);


                        }
                        //
                        //rtx += example + "\r\n";
                    }
                    else {
                        faults2 += line.Split('#')[0] + "\r\n";
                    }
                    if (i % 50 == 0)
                    {
                        label1.Text = i + "/" + lines.Length;
                        label1.Invalidate();
                        Application.DoEvents();
                    }
                   
                }
                richTextBox1.Text = corrects;
                richTextBox2.Text = faults1;
                richTextBox3.Text = faults2;
                rtxWithouExampleFa.Text = witoutexampleFa;
                rxtOnlyExample.Text = onlyexamples;
                //System.IO.File.WriteAllText(op.FileName.Replace(".txt","1.txt"), newfile);
                MessageBox.Show("Finish corrected: " +corrected);
                

            }
        }

        static bool IsOnlyPersian(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;

            // اگر رشته شامل حروف انگلیسی باشه
            if (Regex.IsMatch(text, "[A-Za-z]")) return false;

            if (FindNonPersianParts(text) > 2) return false;
            // اجازه‌ی کاراکترهای فارسی، فاصله و علائم رایج
            return true;
        }

        static int FindNonPersianParts(string text)
        {
            // فقط کاراکترهایی رو پیدا کن که بیرون از محدوده فارسی-عربی باشن
            var matches = Regex.Matches(text, @"[^\u0600-\u06FF\u200C\s،؛؟٪ءآأإئًٌٍَُِّ.!؟(){}\[\]«»""]");
            return matches.Count;
            //if (matches.Count == 0)
            //{
            //    Console.WriteLine("✅ متن فقط فارسی است");
            //}
            //else
            //{
            //    Console.WriteLine("❌ متن حاوی کاراکترهای غیر فارسی است");
            //    foreach (Match match in matches)
            //    {
            //        Console.WriteLine($"Nob persian:'{match.Value}'in position {match.Index}");
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string complete = "";
            for(int i=0;i<rtxWithouExampleFa.Lines.Length;i++)
            {
                string com = rtxWithouExampleFa.Lines[i]+ rxtOnlyExample.Lines[i];
                complete += com + "\r\n";

            }
            rtxWithouExampleFa.Text = complete;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
