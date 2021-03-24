namespace MineField_Game
{
    partial class frmGame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGame));
            this.pnlField = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NumericSure = new System.Windows.Forms.NumericUpDown();
            this.NumericMayinSayisi = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelkalansure = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericSure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericMayinSayisi)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlField
            // 
            this.pnlField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlField.Location = new System.Drawing.Point(40, 12);
            this.pnlField.Name = "pnlField";
            this.pnlField.Size = new System.Drawing.Size(130, 130);
            this.pnlField.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NumericSure);
            this.groupBox1.Controls.Add(this.NumericMayinSayisi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 82);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // NumericSure
            // 
            this.NumericSure.Location = new System.Drawing.Point(80, 48);
            this.NumericSure.Name = "NumericSure";
            this.NumericSure.Size = new System.Drawing.Size(106, 21);
            this.NumericSure.TabIndex = 1;
            this.NumericSure.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // NumericMayinSayisi
            // 
            this.NumericMayinSayisi.Location = new System.Drawing.Point(80, 19);
            this.NumericMayinSayisi.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.NumericMayinSayisi.Name = "NumericMayinSayisi";
            this.NumericMayinSayisi.Size = new System.Drawing.Size(106, 21);
            this.NumericMayinSayisi.TabIndex = 1;
            this.NumericMayinSayisi.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Süre=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "MayınSayısı=";
            // 
            // labelkalansure
            // 
            this.labelkalansure.AutoSize = true;
            this.labelkalansure.Location = new System.Drawing.Point(12, 246);
            this.labelkalansure.Name = "labelkalansure";
            this.labelkalansure.Size = new System.Drawing.Size(69, 13);
            this.labelkalansure.TabIndex = 11;
            this.labelkalansure.Text = "Kalan Süre =";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(123, 241);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "Başla";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonbuttonStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(249, 299);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelkalansure);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlField);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGame";
            this.Text = "MineField Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericSure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericMayinSayisi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlField;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown NumericSure;
        private System.Windows.Forms.NumericUpDown NumericMayinSayisi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelkalansure;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer1;
    }
}

