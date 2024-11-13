namespace WindowsFormsApp3
{
    partial class Form4
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Maximum = new System.Windows.Forms.NumericUpDown();
            this.Minimum = new System.Windows.Forms.NumericUpDown();
            this.Type = new System.Windows.Forms.ComboBox();
            this.ExtraAddress = new System.Windows.Forms.TextBox();
            this.NumberOfBethrooms = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfBedrooms = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NumberOfBeds = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Capacity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.HostRules = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ApproximateAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.AmenitiesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Done = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.LandmarksDataGridView = new System.Windows.Forms.DataGridView();
            this.Next = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Maximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfBethrooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfBedrooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfBeds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Capacity)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LandmarksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(883, 436);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Maximum);
            this.tabPage1.Controls.Add(this.Minimum);
            this.tabPage1.Controls.Add(this.Type);
            this.tabPage1.Controls.Add(this.ExtraAddress);
            this.tabPage1.Controls.Add(this.NumberOfBethrooms);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.NumberOfBedrooms);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.NumberOfBeds);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.Capacity);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.HostRules);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.Description);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.ApproximateAddress);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.Title);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(875, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Distance to Attraction";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Maximum
            // 
            this.Maximum.Location = new System.Drawing.Point(611, 369);
            this.Maximum.Name = "Maximum";
            this.Maximum.Size = new System.Drawing.Size(74, 20);
            this.Maximum.TabIndex = 49;
            // 
            // Minimum
            // 
            this.Minimum.Location = new System.Drawing.Point(315, 369);
            this.Minimum.Name = "Minimum";
            this.Minimum.Size = new System.Drawing.Size(74, 20);
            this.Minimum.TabIndex = 48;
            // 
            // Type
            // 
            this.Type.FormattingEnabled = true;
            this.Type.Location = new System.Drawing.Point(76, 34);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(267, 21);
            this.Type.TabIndex = 47;
            // 
            // ExtraAddress
            // 
            this.ExtraAddress.Location = new System.Drawing.Point(115, 191);
            this.ExtraAddress.Multiline = true;
            this.ExtraAddress.Name = "ExtraAddress";
            this.ExtraAddress.Size = new System.Drawing.Size(716, 44);
            this.ExtraAddress.TabIndex = 39;
            // 
            // NumberOfBethrooms
            // 
            this.NumberOfBethrooms.Location = new System.Drawing.Point(747, 89);
            this.NumberOfBethrooms.Name = "NumberOfBethrooms";
            this.NumberOfBethrooms.Size = new System.Drawing.Size(74, 20);
            this.NumberOfBethrooms.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Type";
            // 
            // NumberOfBedrooms
            // 
            this.NumberOfBedrooms.Location = new System.Drawing.Point(521, 89);
            this.NumberOfBedrooms.Name = "NumberOfBedrooms";
            this.NumberOfBedrooms.Size = new System.Drawing.Size(74, 20);
            this.NumberOfBedrooms.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Capacity";
            // 
            // NumberOfBeds
            // 
            this.NumberOfBeds.Location = new System.Drawing.Point(269, 89);
            this.NumberOfBeds.Name = "NumberOfBeds";
            this.NumberOfBeds.Size = new System.Drawing.Size(74, 20);
            this.NumberOfBeds.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Title";
            // 
            // Capacity
            // 
            this.Capacity.Location = new System.Drawing.Point(76, 89);
            this.Capacity.Name = "Capacity";
            this.Capacity.Size = new System.Drawing.Size(74, 20);
            this.Capacity.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Approximate Address";
            // 
            // HostRules
            // 
            this.HostRules.Location = new System.Drawing.Point(115, 307);
            this.HostRules.Multiline = true;
            this.HostRules.Name = "HostRules";
            this.HostRules.Size = new System.Drawing.Size(716, 44);
            this.HostRules.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Extra Address";
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(115, 243);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(716, 44);
            this.Description.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Description";
            // 
            // ApproximateAddress
            // 
            this.ApproximateAddress.Location = new System.Drawing.Point(146, 130);
            this.ApproximateAddress.Name = "ApproximateAddress";
            this.ApproximateAddress.Size = new System.Drawing.Size(685, 20);
            this.ApproximateAddress.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Host Rules";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(632, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Number of Bethrooms";
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(470, 35);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(285, 20);
            this.Title.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Reservation Time (Nights)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(544, 376);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Maximum";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(240, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Minimum";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(389, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Number of Bedrooms";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(180, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Number of Beds";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.AmenitiesCheckedListBox);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(875, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Amenities";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // AmenitiesCheckedListBox
            // 
            this.AmenitiesCheckedListBox.FormattingEnabled = true;
            this.AmenitiesCheckedListBox.Location = new System.Drawing.Point(9, 57);
            this.AmenitiesCheckedListBox.Name = "AmenitiesCheckedListBox";
            this.AmenitiesCheckedListBox.Size = new System.Drawing.Size(652, 259);
            this.AmenitiesCheckedListBox.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(137, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Choose Availoble Amenities";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Done);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.LandmarksDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(875, 410);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Listing Details";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Done
            // 
            this.Done.Location = new System.Drawing.Point(756, 6);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(75, 23);
            this.Done.TabIndex = 3;
            this.Done.Text = "Done ";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "distatn";
            // 
            // LandmarksDataGridView
            // 
            this.LandmarksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LandmarksDataGridView.Location = new System.Drawing.Point(6, 32);
            this.LandmarksDataGridView.Name = "LandmarksDataGridView";
            this.LandmarksDataGridView.Size = new System.Drawing.Size(863, 362);
            this.LandmarksDataGridView.TabIndex = 2;
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(710, 468);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 1;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(816, 468);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Close/Finish";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 498);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Next);
            this.Name = "Form4";
            this.Text = "Form4";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Maximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfBethrooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfBedrooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfBeds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Capacity)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LandmarksDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckedListBox AmenitiesCheckedListBox;
        private System.Windows.Forms.NumericUpDown Maximum;
        private System.Windows.Forms.NumericUpDown Minimum;
        private System.Windows.Forms.ComboBox Type;
        private System.Windows.Forms.TextBox ExtraAddress;
        private System.Windows.Forms.NumericUpDown NumberOfBethrooms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumberOfBedrooms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumberOfBeds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Capacity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox HostRules;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ApproximateAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView LandmarksDataGridView;
    }
}