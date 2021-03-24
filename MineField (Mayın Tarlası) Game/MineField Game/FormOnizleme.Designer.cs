namespace MineField_Game
{
    partial class FormOnizleme
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
            this.pnlFieldOnz = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlFieldOnz
            // 
            this.pnlFieldOnz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFieldOnz.Location = new System.Drawing.Point(12, 12);
            this.pnlFieldOnz.Name = "pnlFieldOnz";
            this.pnlFieldOnz.Size = new System.Drawing.Size(130, 130);
            this.pnlFieldOnz.TabIndex = 6;
            // 
            // FormOnizleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(160, 160);
            this.Controls.Add(this.pnlFieldOnz);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOnizleme";
            this.ShowIcon = false;
            this.Text = "FormOnizleme";
            this.Load += new System.EventHandler(this.FormOnizleme_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFieldOnz;
    }
}