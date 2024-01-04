namespace Generyczny
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.UpDown = new System.Windows.Forms.NumericUpDown();
            this.start = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Epoki:";
            // 
            // UpDown
            // 
            this.UpDown.Location = new System.Drawing.Point(52, 7);
            this.UpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDown.Name = "UpDown";
            this.UpDown.Size = new System.Drawing.Size(83, 20);
            this.UpDown.TabIndex = 2;
            this.UpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(141, 4);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 3;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.HideSelection = false;
            this.textBox.Location = new System.Drawing.Point(0, 37);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(476, 356);
            this.textBox.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.UpDown);
            this.panel1.Controls.Add(this.start);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 37);
            this.panel1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 393);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Szukanie najlepszej trasy";
            ((System.ComponentModel.ISupportInitialize)(this.UpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown UpDown;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Panel panel1;
    }
}

