namespace VersionTools
{
    partial class VersionFrom
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
            this.AllFileBox = new System.Windows.Forms.ListBox();
            this.OutputBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.currVersionLable = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nextVersionLable = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AllFileBox
            // 
            this.AllFileBox.FormattingEnabled = true;
            this.AllFileBox.ItemHeight = 12;
            this.AllFileBox.Location = new System.Drawing.Point(12, 24);
            this.AllFileBox.Name = "AllFileBox";
            this.AllFileBox.Size = new System.Drawing.Size(401, 172);
            this.AllFileBox.TabIndex = 0;
            // 
            // OutputBox
            // 
            this.OutputBox.FormattingEnabled = true;
            this.OutputBox.ItemHeight = 12;
            this.OutputBox.Location = new System.Drawing.Point(12, 202);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(401, 196);
            this.OutputBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "所有文件";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(501, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "选择文件夹";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(501, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "检查版本";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(501, 334);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 35);
            this.button3.TabIndex = 5;
            this.button3.Text = "生成版本";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "当前版本";
            // 
            // currVersionLable
            // 
            this.currVersionLable.AutoSize = true;
            this.currVersionLable.Location = new System.Drawing.Point(567, 47);
            this.currVersionLable.Name = "currVersionLable";
            this.currVersionLable.Size = new System.Drawing.Size(0, 12);
            this.currVersionLable.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "下一版本";
            // 
            // nextVersionLable
            // 
            this.nextVersionLable.Location = new System.Drawing.Point(529, 116);
            this.nextVersionLable.Name = "nextVersionLable";
            this.nextVersionLable.Size = new System.Drawing.Size(100, 21);
            this.nextVersionLable.TabIndex = 9;
            this.nextVersionLable.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // VersionFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 400);
            this.Controls.Add(this.nextVersionLable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.currVersionLable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.AllFileBox);
            this.Name = "VersionFrom";
            this.Text = "版本生成工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AllFileBox;
        private System.Windows.Forms.ListBox OutputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label currVersionLable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nextVersionLable;
    }
}

