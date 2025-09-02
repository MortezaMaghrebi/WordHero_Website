namespace DictionaryCreator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bOpenDictionary = new System.Windows.Forms.Button();
            this.rtxmy_dictionary = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtx_not_in_dictionary_words = new System.Windows.Forms.RichTextBox();
            this.rtx_allwords = new System.Windows.Forms.RichTextBox();
            this.bOpenAllWords = new System.Windows.Forms.Button();
            this.bExtract150toDeepseek = new System.Windows.Forms.Button();
            this.bExtractNewWords = new System.Windows.Forms.Button();
            this.ldeepseek = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bOpenDictionary
            // 
            this.bOpenDictionary.Location = new System.Drawing.Point(80, 6);
            this.bOpenDictionary.Name = "bOpenDictionary";
            this.bOpenDictionary.Size = new System.Drawing.Size(93, 25);
            this.bOpenDictionary.TabIndex = 0;
            this.bOpenDictionary.Text = "Open Dictionary";
            this.bOpenDictionary.UseVisualStyleBackColor = true;
            this.bOpenDictionary.Click += new System.EventHandler(this.bOpenDictionary_Click);
            // 
            // rtxmy_dictionary
            // 
            this.rtxmy_dictionary.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtxmy_dictionary.Location = new System.Drawing.Point(0, 50);
            this.rtxmy_dictionary.Name = "rtxmy_dictionary";
            this.rtxmy_dictionary.Size = new System.Drawing.Size(258, 390);
            this.rtxmy_dictionary.TabIndex = 1;
            this.rtxmy_dictionary.Text = "";
            this.rtxmy_dictionary.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 440);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(813, 10);
            this.progressBar1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ldeepseek);
            this.panel1.Controls.Add(this.bExtractNewWords);
            this.panel1.Controls.Add(this.bExtract150toDeepseek);
            this.panel1.Controls.Add(this.bOpenAllWords);
            this.panel1.Controls.Add(this.bOpenDictionary);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 50);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // rtx_not_in_dictionary_words
            // 
            this.rtx_not_in_dictionary_words.Dock = System.Windows.Forms.DockStyle.Right;
            this.rtx_not_in_dictionary_words.Location = new System.Drawing.Point(528, 50);
            this.rtx_not_in_dictionary_words.Name = "rtx_not_in_dictionary_words";
            this.rtx_not_in_dictionary_words.Size = new System.Drawing.Size(285, 390);
            this.rtx_not_in_dictionary_words.TabIndex = 4;
            this.rtx_not_in_dictionary_words.Text = "";
            // 
            // rtx_allwords
            // 
            this.rtx_allwords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtx_allwords.Location = new System.Drawing.Point(258, 50);
            this.rtx_allwords.Name = "rtx_allwords";
            this.rtx_allwords.Size = new System.Drawing.Size(270, 390);
            this.rtx_allwords.TabIndex = 5;
            this.rtx_allwords.Text = "";
            // 
            // bOpenAllWords
            // 
            this.bOpenAllWords.Location = new System.Drawing.Point(337, 5);
            this.bOpenAllWords.Name = "bOpenAllWords";
            this.bOpenAllWords.Size = new System.Drawing.Size(93, 25);
            this.bOpenAllWords.TabIndex = 1;
            this.bOpenAllWords.Text = "Open All words";
            this.bOpenAllWords.UseVisualStyleBackColor = true;
            this.bOpenAllWords.Click += new System.EventHandler(this.bOpenAllWords_Click);
            // 
            // bExtract150toDeepseek
            // 
            this.bExtract150toDeepseek.Location = new System.Drawing.Point(661, 6);
            this.bExtract150toDeepseek.Name = "bExtract150toDeepseek";
            this.bExtract150toDeepseek.Size = new System.Drawing.Size(140, 25);
            this.bExtract150toDeepseek.TabIndex = 2;
            this.bExtract150toDeepseek.Text = "Extract 150 to Deepseek";
            this.bExtract150toDeepseek.UseVisualStyleBackColor = true;
            this.bExtract150toDeepseek.Click += new System.EventHandler(this.bExtract150toDeepseek_Click);
            // 
            // bExtractNewWords
            // 
            this.bExtractNewWords.Location = new System.Drawing.Point(528, 6);
            this.bExtractNewWords.Name = "bExtractNewWords";
            this.bExtractNewWords.Size = new System.Drawing.Size(127, 25);
            this.bExtractNewWords.TabIndex = 3;
            this.bExtractNewWords.Text = "Extract New Words";
            this.bExtractNewWords.UseVisualStyleBackColor = true;
            this.bExtractNewWords.Click += new System.EventHandler(this.bExtractNewWords_Click);
            // 
            // ldeepseek
            // 
            this.ldeepseek.AutoSize = true;
            this.ldeepseek.Location = new System.Drawing.Point(661, 34);
            this.ldeepseek.Name = "ldeepseek";
            this.ldeepseek.Size = new System.Drawing.Size(35, 13);
            this.ldeepseek.TabIndex = 4;
            this.ldeepseek.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 450);
            this.Controls.Add(this.rtx_allwords);
            this.Controls.Add(this.rtx_not_in_dictionary_words);
            this.Controls.Add(this.rtxmy_dictionary);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "My_Dictionary";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bOpenDictionary;
        private System.Windows.Forms.RichTextBox rtxmy_dictionary;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtx_not_in_dictionary_words;
        private System.Windows.Forms.RichTextBox rtx_allwords;
        private System.Windows.Forms.Button bExtract150toDeepseek;
        private System.Windows.Forms.Button bOpenAllWords;
        private System.Windows.Forms.Button bExtractNewWords;
        private System.Windows.Forms.Label ldeepseek;
    }
}

