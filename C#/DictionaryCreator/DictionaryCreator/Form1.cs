using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bOpenDictionary_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                rtxmy_dictionary.Text=System.IO.File.ReadAllText(op.FileName);
            }
        }

        private void bOpenAllWords_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                rtx_allwords.Text = System.IO.File.ReadAllText(op.FileName);
            }
        }

        private void bExtract150toDeepseek_Click(object sender, EventArgs e)
        {
            string prompt = "فرض کن یک زبان شناس هستی که به دیکشنری های آکسفورد و کمبریج دسترسی داری و میخوای با لیست کلماتی که من بهت میدم فایل آموزش لغات زبان انگلیسی درست کنی. فایلی که من میدم در هر خط یک کلمه داره، تو در هر خط، کلمه رو به این فرمت مینویسی:\r\nword#meaning in persian#example in sentence#synonym#CEFR level#pronounciation in american#translation of example in persian\r\nتو فقط فایل خروجی رو میدی و هیچ توضیحات دیگه ای نمیدی\r\nمعنی فارسی و ترجمه جمله به فارسی نباید شامل کلمات غیر فارسی باشد\r\nاز اونجایی که این پرامپت طولانیه من میرم و نیم ساعت دیگه بر می میگردم، میخوام هیچ اینتراپتی وسطش ندی یا سوالی نپرسی یا سوال میوخوای ادامه بدی رو نپرسی و خودت ادامه بدی\r\nWords:\r\n";
            int startindex = lastindex_sent_deepseek;
            int stopindex = 0;
            if(new_words!=null)
            {
               
                for(int i=lastindex_sent_deepseek;i<Math.Min(lastindex_sent_deepseek+150,new_words.Count());i++)
                {
                    prompt += new_words[i] + "\r\n";
                    stopindex = i;
                }
                lastindex_sent_deepseek = stopindex + 1;
                System.IO.File.WriteAllText("lastindex", lastindex_sent_deepseek + "");
                OpenBrowser("https://gemini.google.com/app?is_sa=1&is_sa=1&android-min-version=301356232&ios-min-version=322.0&campaign_id=bkws&utm_source=sem&utm_source=google&utm_medium=paid-media&utm_medium=cpc&utm_campaign=bkws&utm_campaign=2024enGB_gemfeb&pt=9008&mt=8&ct=p-growth-sem-bkws&gclsrc=aw.ds&gad_source=1&gad_campaignid=22921538072&gbraid=0AAAAApk5BhkUWTASFVSBF0c3iiTCiuwVu&gclid=CjwKCAjwk7DFBhBAEiwAeYbJsbHeEYRJX_4YW3pRoXuZ2ru24Tnblo7ZtQA8O6NUEABmD6g6Usv9MRoCNM8QAvD_BwE");
                Clipboard.SetText(prompt);
                System.Threading.Thread.Sleep(5000);
                SendKeys.Send("^v");
                System.Threading.Thread.Sleep(500);
                SendKeys.Send("{ENTER}");
            }
            ldeepseek.Text = startindex + " to " + stopindex;
        }

        

        List<string> my_words = new List<string>();
        List<string> all_words = new List<string>();
        List<string> new_words;
        int lastindex_sent_deepseek = 0;
        private void bExtractNewWords_Click(object sender, EventArgs e)
        {
            string[] lines = rtxmy_dictionary.Lines;
            for (int i=0;i< lines.Length;i++)
            {
                string word = lines[i].Split('#')[0].ToLower();
                my_words.Add(word);
                progressBar1.Value = i * 100 / lines.Length;
                if(i%10==0) Application.DoEvents();
                
            }
            lines = rtx_allwords.Lines;
            ldeepseek.Text = my_words.Count() + "";
            for (int i = 0; i < lines.Length; i++)
            {
                string word = lines[i].Trim();
                if(word.Length>=3) all_words.Add(word);
                progressBar1.Value = i * 100 / lines.Length;
                if (i % 10 == 0) Application.DoEvents();
            }
            new_words = all_words.Where(x => !my_words.Contains(x)).ToList();
            ldeepseek.Text += " "+new_words.Count() + "";
            string new_words_str = "";
            foreach (string word in new_words)
            {
                new_words_str += word + "\r\n";
            }
            rtx_not_in_dictionary_words.Text = new_words_str;
        }

        public static void OpenBrowser(string url)
        {
            // Use the OS-specific command to open a web browser
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });//try
            //{
            //    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            //}
            //catch (System.ComponentModel.Win32Exception)
            //{ 
            //     Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                lastindex_sent_deepseek = int.Parse(System.IO.File.ReadAllText("lastindex"));
            }
            catch (Exception ex)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = rtxmy_dictionary.Lines;
            List<string> A1 = new List<string>();
            List<string> A2 = new List<string>();
            List<string> B1 = new List<string>();
            List<string> B2 = new List<string>();
            List<string> C1 = new List<string>();
            List<string> C2 = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] items = lines[i].Split('#');
                if (items.Length > 4)
                {
                    string word = items[0].ToLower();
                    string CEFR = items[4].ToUpper();
                    switch (CEFR)
                    {
                        case "A1":
                            A1.Add(word);
                            break;
                        case "A2":
                            A2.Add(word);
                            break;
                        case "B1":
                            B1.Add(word);
                            break;
                        case "B2":
                            B2.Add(word);
                            break;
                        case "C1":
                            C1.Add(word);
                            break;
                        case "C2":
                            C2.Add(word);
                            break;

                    }
                   
                }
                progressBar1.Value = i * 100 / lines.Length;
                if (i % 10 == 0) Application.DoEvents();

            }
            SaveToFile("A1.txt", A1);
            SaveToFile("A2.txt", A2);
            SaveToFile("B1.txt", B1);
            SaveToFile("B2.txt", B2);
            SaveToFile("C1.txt", C1);
            SaveToFile("C2.txt", C2);
            MessageBox.Show("Saved");

        }

        void SaveToFile(string file,List<string> list)
        {
            string str = "";
            foreach(string s in list)
            {
                str += s + "\r\n";
            }
            System.IO.File.WriteAllText(file, str);
        }

    }
}
