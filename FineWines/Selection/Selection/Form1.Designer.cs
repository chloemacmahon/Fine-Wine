namespace Selection
{
    partial class SelectionPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionPage));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.btnWines = new System.Windows.Forms.Button();
            this.btnGrapes = new System.Windows.Forms.Button();
            this.btnClearWines = new System.Windows.Forms.Button();
            this.btnCLearGrapes = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.IndianRed;
            this.groupBox1.Controls.Add(this.btnClearWines);
            this.groupBox1.Controls.Add(this.btnWines);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(73, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wine Selection";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(23, 152);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(175, 29);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Wine Inventory";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(23, 105);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(210, 29);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Wine Maintenance";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(23, 57);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(146, 29);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Wine Types";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox2.Controls.Add(this.btnCLearGrapes);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.btnGrapes);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(452, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 273);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Grape Selection";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(28, 105);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(204, 29);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Grapes Harvested";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(28, 57);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(219, 29);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Grape Maintenance";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // btnWines
            // 
            this.btnWines.BackColor = System.Drawing.Color.DarkRed;
            this.btnWines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnWines.ForeColor = System.Drawing.Color.Transparent;
            this.btnWines.Location = new System.Drawing.Point(6, 194);
            this.btnWines.Name = "btnWines";
            this.btnWines.Size = new System.Drawing.Size(128, 58);
            this.btnWines.TabIndex = 2;
            this.btnWines.Text = "Proceed";
            this.btnWines.UseVisualStyleBackColor = false;
            this.btnWines.Click += new System.EventHandler(this.btnWines_Click);
            // 
            // btnGrapes
            // 
            this.btnGrapes.BackColor = System.Drawing.Color.DarkGreen;
            this.btnGrapes.Location = new System.Drawing.Point(6, 194);
            this.btnGrapes.Name = "btnGrapes";
            this.btnGrapes.Size = new System.Drawing.Size(128, 58);
            this.btnGrapes.TabIndex = 3;
            this.btnGrapes.Text = "Proceed";
            this.btnGrapes.UseVisualStyleBackColor = false;
            this.btnGrapes.Click += new System.EventHandler(this.btnGrapes_Click);
            // 
            // btnClearWines
            // 
            this.btnClearWines.BackColor = System.Drawing.Color.DarkRed;
            this.btnClearWines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClearWines.ForeColor = System.Drawing.Color.Transparent;
            this.btnClearWines.Location = new System.Drawing.Point(144, 194);
            this.btnClearWines.Name = "btnClearWines";
            this.btnClearWines.Size = new System.Drawing.Size(128, 58);
            this.btnClearWines.TabIndex = 3;
            this.btnClearWines.Text = "Clear Wines";
            this.btnClearWines.UseVisualStyleBackColor = false;
            this.btnClearWines.Click += new System.EventHandler(this.btnClearWines_Click);
            // 
            // btnCLearGrapes
            // 
            this.btnCLearGrapes.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCLearGrapes.Location = new System.Drawing.Point(140, 194);
            this.btnCLearGrapes.Name = "btnCLearGrapes";
            this.btnCLearGrapes.Size = new System.Drawing.Size(128, 58);
            this.btnCLearGrapes.TabIndex = 4;
            this.btnCLearGrapes.Text = "Clear Grapes";
            this.btnCLearGrapes.UseVisualStyleBackColor = false;
            this.btnCLearGrapes.Click += new System.EventHandler(this.btnCLearGrapes_Click);
            // 
            // SelectionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SelectionPage";
            this.Text = "SelectionPage";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button btnWines;
        private System.Windows.Forms.Button btnGrapes;
        private System.Windows.Forms.Button btnClearWines;
        private System.Windows.Forms.Button btnCLearGrapes;
    }
}

