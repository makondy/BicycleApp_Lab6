namespace BicycleApp_Lab6
{
    partial class fVehicleType
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
            this.btnElectric = new System.Windows.Forms.Button();
            this.btnMechanical = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnElectric
            // 
            this.btnElectric.Location = new System.Drawing.Point(43, 78);
            this.btnElectric.Name = "btnElectric";
            this.btnElectric.Size = new System.Drawing.Size(75, 23);
            this.btnElectric.TabIndex = 0;
            this.btnElectric.Text = "Електричний";
            this.btnElectric.UseVisualStyleBackColor = true;
            this.btnElectric.Click += new System.EventHandler(this.btnElectric_Click);
            // 
            // btnMechanical
            // 
            this.btnMechanical.Location = new System.Drawing.Point(188, 78);
            this.btnMechanical.Name = "btnMechanical";
            this.btnMechanical.Size = new System.Drawing.Size(75, 23);
            this.btnMechanical.TabIndex = 1;
            this.btnMechanical.Text = "Механічний";
            this.btnMechanical.UseVisualStyleBackColor = true;
            this.btnMechanical.Click += new System.EventHandler(this.btnMechanical_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Виберіть основу для велосипеду";
            // 
            // fVehicleType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 157);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMechanical);
            this.Controls.Add(this.btnElectric);
            this.Name = "fVehicleType";
            this.Text = "Вибір основи";
            this.Load += new System.EventHandler(this.fVehicleType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnElectric;
        private System.Windows.Forms.Button btnMechanical;
        private System.Windows.Forms.Label label1;
    }
}