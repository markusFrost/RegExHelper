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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.btnGetSqlQuery = new System.Windows.Forms.Button();
            this.btnGenerateConstants = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetSqlQuery
            // 
            this.btnGetSqlQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetSqlQuery.Location = new System.Drawing.Point(61, 256);
            this.btnGetSqlQuery.Name = "btnGetSqlQuery";
            this.btnGetSqlQuery.Size = new System.Drawing.Size(259, 65);
            this.btnGetSqlQuery.TabIndex = 0;
            this.btnGetSqlQuery.Text = "Получить sql - строку";
            this.btnGetSqlQuery.UseVisualStyleBackColor = true;
            this.btnGetSqlQuery.Click += new System.EventHandler(this.btnGetSqlQuery_Click);
            // 
            // btnGenerateConstants
            // 
            this.btnGenerateConstants.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGenerateConstants.Location = new System.Drawing.Point(61, 90);
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
            this.ClientSize = new System.Drawing.Size(390, 439);
            this.Controls.Add(this.btnGenerateConstants);
            this.Controls.Add(this.btnGetSqlQuery);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetSqlQuery;
        private System.Windows.Forms.Button btnGenerateConstants;
    }
}