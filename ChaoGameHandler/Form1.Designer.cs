
namespace ChaoGameHandler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.qrPic = new System.Windows.Forms.PictureBox();
            this.generateBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.importTxt = new System.Windows.Forms.TextBox();
            this.importBtn = new System.Windows.Forms.Button();
            this.openDir = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelDir = new System.Windows.Forms.Label();
            this.chaoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.qrPic)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(764, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Path is commonly something like C:\\Program Files\\Steam\\steamapps\\ common\\Sonic Ad" +
    "venture 2\\resource\\gd_PC\\SAVEDATA\\SONIC2B__ALF";
            // 
            // qrPic
            // 
            this.qrPic.Location = new System.Drawing.Point(515, 183);
            this.qrPic.Name = "qrPic";
            this.qrPic.Size = new System.Drawing.Size(350, 350);
            this.qrPic.TabIndex = 3;
            this.qrPic.TabStop = false;
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(618, 575);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(120, 23);
            this.generateBtn.TabIndex = 4;
            this.generateBtn.Text = "Generate QR";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(629, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Export Data to mobile";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Import Data to Sonic Adventure 2";
            // 
            // importTxt
            // 
            this.importTxt.Location = new System.Drawing.Point(53, 485);
            this.importTxt.Multiline = true;
            this.importTxt.Name = "importTxt";
            this.importTxt.Size = new System.Drawing.Size(328, 48);
            this.importTxt.TabIndex = 7;
            // 
            // importBtn
            // 
            this.importBtn.Location = new System.Drawing.Point(163, 575);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(94, 23);
            this.importBtn.TabIndex = 8;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // openDir
            // 
            this.openDir.Location = new System.Drawing.Point(348, 87);
            this.openDir.Name = "openDir";
            this.openDir.Size = new System.Drawing.Size(225, 23);
            this.openDir.TabIndex = 9;
            this.openDir.Text = "Open File";
            this.openDir.UseVisualStyleBackColor = true;
            this.openDir.Click += new System.EventHandler(this.openDir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelDir
            // 
            this.labelDir.AutoSize = true;
            this.labelDir.Location = new System.Drawing.Point(224, 58);
            this.labelDir.Name = "labelDir";
            this.labelDir.Size = new System.Drawing.Size(503, 15);
            this.labelDir.TabIndex = 10;
            this.labelDir.Text = "D:\\steam\\steamapps\\common\\Sonic Adventure 2\\resource\\gd_PC\\SAVEDATA\\SONIC2B__ALF";
            this.labelDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chaoLabel
            // 
            this.chaoLabel.AutoSize = true;
            this.chaoLabel.Location = new System.Drawing.Point(66, 183);
            this.chaoLabel.Name = "chaoLabel";
            this.chaoLabel.Size = new System.Drawing.Size(0, 15);
            this.chaoLabel.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 644);
            this.Controls.Add(this.chaoLabel);
            this.Controls.Add(this.labelDir);
            this.Controls.Add(this.openDir);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.importTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.qrPic);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.qrPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox qrPic;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox importTxt;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Button openDir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelDir;
        private System.Windows.Forms.Label chaoLabel;
    }
}

