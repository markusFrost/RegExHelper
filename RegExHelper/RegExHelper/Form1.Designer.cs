namespace RegExHelper
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.rtbConstants = new System.Windows.Forms.RichTextBox();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.rtbSql = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(892, 347);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(139, 43);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // rtbConstants
            // 
            this.rtbConstants.Location = new System.Drawing.Point(12, 32);
            this.rtbConstants.Name = "rtbConstants";
            this.rtbConstants.Size = new System.Drawing.Size(856, 144);
            this.rtbConstants.TabIndex = 1;
            this.rtbConstants.Text = "";
            // 
            // rtbResult
            // 
            this.rtbResult.Location = new System.Drawing.Point(12, 347);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(856, 268);
            this.rtbResult.TabIndex = 3;
            this.rtbResult.Text = "";
            this.rtbResult.TextChanged += new System.EventHandler(this.rtbResult_TextChanged);
            // 
            // rtbSql
            // 
            this.rtbSql.Location = new System.Drawing.Point(12, 214);
            this.rtbSql.Name = "rtbSql";
            this.rtbSql.Size = new System.Drawing.Size(856, 88);
            this.rtbSql.TabIndex = 4;
            this.rtbSql.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(892, 448);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(139, 43);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(436, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введите константы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(436, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Введите sql запрос";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(436, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Результирующий sql запрос";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1066, 640);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.rtbSql);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.rtbConstants);
            this.Controls.Add(this.btnGenerate);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox rtbConstants;
        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.RichTextBox rtbSql;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

