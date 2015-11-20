namespace RegExHelper
{
    partial class Form3
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
            this.btnGetSqlQuery = new System.Windows.Forms.Button();
            this.btnGenerateConstants = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetSqlQuery
            // 
            this.btnGetSqlQuery.Location = new System.Drawing.Point(72, 99);
            this.btnGetSqlQuery.Name = "btnGetSqlQuery";
            this.btnGetSqlQuery.Size = new System.Drawing.Size(259, 65);
            this.btnGetSqlQuery.TabIndex = 0;
            this.btnGetSqlQuery.Text = "Получить sql - строку";
            this.btnGetSqlQuery.UseVisualStyleBackColor = true;
            this.btnGetSqlQuery.Click += new System.EventHandler(this.btnGetSqlQuery_Click);
            // 
            // btnGenerateConstants
            // 
            this.btnGenerateConstants.Location = new System.Drawing.Point(72, 204);
            this.btnGenerateConstants.Name = "btnGenerateConstants";
            this.btnGenerateConstants.Size = new System.Drawing.Size(259, 66);
            this.btnGenerateConstants.TabIndex = 0;
            this.btnGenerateConstants.Text = "Сгенерировать константы";
            this.btnGenerateConstants.UseVisualStyleBackColor = true;
            this.btnGenerateConstants.Click += new System.EventHandler(this.btnGenerateConstants_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(427, 439);
            this.Controls.Add(this.btnGenerateConstants);
            this.Controls.Add(this.btnGetSqlQuery);
            this.Name = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetSqlQuery;
        private System.Windows.Forms.Button btnGenerateConstants;
    }
}