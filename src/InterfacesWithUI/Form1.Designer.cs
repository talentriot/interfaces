namespace InterfacesWithUI
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
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.btnToRight = new System.Windows.Forms.Button();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.cmbTypeOfItems = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lstLeft
            // 
            this.lstLeft.FormattingEnabled = true;
            this.lstLeft.Location = new System.Drawing.Point(24, 84);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.Size = new System.Drawing.Size(233, 225);
            this.lstLeft.TabIndex = 0;
            // 
            // lstRight
            // 
            this.lstRight.FormattingEnabled = true;
            this.lstRight.Location = new System.Drawing.Point(358, 84);
            this.lstRight.Name = "lstRight";
            this.lstRight.Size = new System.Drawing.Size(242, 225);
            this.lstRight.TabIndex = 1;
            this.lstRight.SelectedIndexChanged += new System.EventHandler(this.lstRight_SelectedIndexChanged);
            // 
            // btnToRight
            // 
            this.btnToRight.Location = new System.Drawing.Point(288, 118);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(33, 28);
            this.btnToRight.TabIndex = 2;
            this.btnToRight.Text = ">";
            this.btnToRight.UseVisualStyleBackColor = true;
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // btnToLeft
            // 
            this.btnToLeft.Location = new System.Drawing.Point(288, 164);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(33, 28);
            this.btnToLeft.TabIndex = 3;
            this.btnToLeft.Text = "<";
            this.btnToLeft.UseVisualStyleBackColor = true;
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // btnUp
            // 
            this.btnUp.Enabled = false;
            this.btnUp.Location = new System.Drawing.Point(606, 103);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(33, 28);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "/\\";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Enabled = false;
            this.btnDown.Location = new System.Drawing.Point(606, 137);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(33, 28);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "\\/";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // cmbTypeOfItems
            // 
            this.cmbTypeOfItems.FormattingEnabled = true;
            this.cmbTypeOfItems.Items.AddRange(new object[] {
            "Food",
            "People"});
            this.cmbTypeOfItems.Location = new System.Drawing.Point(24, 35);
            this.cmbTypeOfItems.Name = "cmbTypeOfItems";
            this.cmbTypeOfItems.Size = new System.Drawing.Size(176, 21);
            this.cmbTypeOfItems.TabIndex = 6;
            this.cmbTypeOfItems.SelectedIndexChanged += new System.EventHandler(this.cmbTypeOfItems_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 570);
            this.Controls.Add(this.cmbTypeOfItems);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnToLeft);
            this.Controls.Add(this.btnToRight);
            this.Controls.Add(this.lstRight);
            this.Controls.Add(this.lstLeft);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.Button btnToRight;
        private System.Windows.Forms.Button btnToLeft;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ComboBox cmbTypeOfItems;
    }
}

