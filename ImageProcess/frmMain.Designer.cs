namespace ImageProcess
{
    partial class frmMain
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lbImageInfo = new System.Windows.Forms.ListBox();
            this.cbFilterSelect = new System.Windows.Forms.ComboBox();
            this.gbColorFilters = new System.Windows.Forms.GroupBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.gbColorFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(913, 786);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Image Files(*.BMP;*.JPG|*.BMP;*.JPG;*)";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(999, 34);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(263, 53);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.TabStop = false;
            this.btnBrowse.Text = "Add Image";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lbImageInfo
            // 
            this.lbImageInfo.FormattingEnabled = true;
            this.lbImageInfo.ItemHeight = 16;
            this.lbImageInfo.Location = new System.Drawing.Point(998, 395);
            this.lbImageInfo.Name = "lbImageInfo";
            this.lbImageInfo.Size = new System.Drawing.Size(263, 180);
            this.lbImageInfo.TabIndex = 2;
            // 
            // cbFilterSelect
            // 
            this.cbFilterSelect.FormattingEnabled = true;
            this.cbFilterSelect.Items.AddRange(new object[] {
            "Inverse",
            "GreyScale"});
            this.cbFilterSelect.Location = new System.Drawing.Point(22, 52);
            this.cbFilterSelect.Name = "cbFilterSelect";
            this.cbFilterSelect.Size = new System.Drawing.Size(220, 24);
            this.cbFilterSelect.TabIndex = 3;
            this.cbFilterSelect.Text = "Choose Filter Type";
            this.cbFilterSelect.SelectedIndexChanged += new System.EventHandler(this.cbFilterSelect_SelectedIndexChanged);
            // 
            // gbColorFilters
            // 
            this.gbColorFilters.Controls.Add(this.btnApplyFilter);
            this.gbColorFilters.Controls.Add(this.cbFilterSelect);
            this.gbColorFilters.Location = new System.Drawing.Point(999, 106);
            this.gbColorFilters.Name = "gbColorFilters";
            this.gbColorFilters.Size = new System.Drawing.Size(262, 197);
            this.gbColorFilters.TabIndex = 4;
            this.gbColorFilters.TabStop = false;
            this.gbColorFilters.Text = "Color Filters";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(22, 94);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(219, 53);
            this.btnApplyFilter.TabIndex = 4;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1000, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(262, 53);
            this.btnSave.TabIndex = 5;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "bmp";
            this.saveFileDialog.FileName = "image";
            this.saveFileDialog.Filter = "Image Files(*.BMP;*.JPG|*.BMP;*.JPG;*)";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 810);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbColorFilters);
            this.Controls.Add(this.lbImageInfo);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.pictureBox);
            this.Name = "frmMain";
            this.Text = "Image Processing";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.gbColorFilters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ListBox lbImageInfo;
        private System.Windows.Forms.ComboBox cbFilterSelect;
        private System.Windows.Forms.GroupBox gbColorFilters;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

