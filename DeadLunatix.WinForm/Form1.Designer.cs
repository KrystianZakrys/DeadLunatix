namespace DeadLunatix.WinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Image = new System.Windows.Forms.PictureBox();
            this.AssetsPath = new System.Windows.Forms.Label();
            this.label_assetsPath = new System.Windows.Forms.Label();
            this.label_generationPath = new System.Windows.Forms.Label();
            this.GenerationPath = new System.Windows.Forms.Label();
            this.label_generationsCount = new System.Windows.Forms.Label();
            this.Amount = new System.Windows.Forms.NumericUpDown();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.ButtonChooseAssets = new System.Windows.Forms.Button();
            this.ButtonChooseGenerationLocation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).BeginInit();
            this.SuspendLayout();
            // 
            // Image
            // 
            this.Image.ErrorImage = global::DeadLunatix.WinForm.Properties.Resources.placeholeder;
            this.Image.Image = global::DeadLunatix.WinForm.Properties.Resources.placeholeder;
            this.Image.InitialImage = global::DeadLunatix.WinForm.Properties.Resources.placeholeder;
            this.Image.Location = new System.Drawing.Point(12, 12);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(836, 836);
            this.Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Image.TabIndex = 0;
            this.Image.TabStop = false;
            // 
            // AssetsPath
            // 
            this.AssetsPath.AutoSize = true;
            this.AssetsPath.Location = new System.Drawing.Point(12, 879);
            this.AssetsPath.Name = "AssetsPath";
            this.AssetsPath.Size = new System.Drawing.Size(108, 25);
            this.AssetsPath.TabIndex = 1;
            this.AssetsPath.Text = "Asset path...";
            // 
            // label_assetsPath
            // 
            this.label_assetsPath.AutoSize = true;
            this.label_assetsPath.Location = new System.Drawing.Point(12, 854);
            this.label_assetsPath.Name = "label_assetsPath";
            this.label_assetsPath.Size = new System.Drawing.Size(96, 25);
            this.label_assetsPath.TabIndex = 2;
            this.label_assetsPath.Text = "Asset path";
            // 
            // label_generationPath
            // 
            this.label_generationPath.AutoSize = true;
            this.label_generationPath.Location = new System.Drawing.Point(12, 922);
            this.label_generationPath.Name = "label_generationPath";
            this.label_generationPath.Size = new System.Drawing.Size(170, 25);
            this.label_generationPath.TabIndex = 3;
            this.label_generationPath.Text = "Generated files path";
            // 
            // GenerationPath
            // 
            this.GenerationPath.AutoSize = true;
            this.GenerationPath.Location = new System.Drawing.Point(12, 947);
            this.GenerationPath.Name = "GenerationPath";
            this.GenerationPath.Size = new System.Drawing.Size(182, 25);
            this.GenerationPath.TabIndex = 4;
            this.GenerationPath.Text = "Generated files path...";
            // 
            // label_generationsCount
            // 
            this.label_generationsCount.AutoSize = true;
            this.label_generationsCount.Location = new System.Drawing.Point(12, 999);
            this.label_generationsCount.Name = "label_generationsCount";
            this.label_generationsCount.Size = new System.Drawing.Size(139, 25);
            this.label_generationsCount.TabIndex = 5;
            this.label_generationsCount.Text = "Choose amount";
            // 
            // Amount
            // 
            this.Amount.Location = new System.Drawing.Point(14, 1027);
            this.Amount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(180, 31);
            this.Amount.TabIndex = 6;
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Location = new System.Drawing.Point(14, 1117);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(189, 79);
            this.BtnGenerate.TabIndex = 7;
            this.BtnGenerate.Text = "Generate";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(209, 1117);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(189, 79);
            this.Clear.TabIndex = 8;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            // 
            // ButtonChooseAssets
            // 
            this.ButtonChooseAssets.Location = new System.Drawing.Point(404, 1117);
            this.ButtonChooseAssets.Name = "ButtonChooseAssets";
            this.ButtonChooseAssets.Size = new System.Drawing.Size(189, 79);
            this.ButtonChooseAssets.TabIndex = 9;
            this.ButtonChooseAssets.Text = "Get assets";
            this.ButtonChooseAssets.UseVisualStyleBackColor = true;
            // 
            // ButtonChooseGenerationLocation
            // 
            this.ButtonChooseGenerationLocation.Location = new System.Drawing.Point(599, 1117);
            this.ButtonChooseGenerationLocation.Name = "ButtonChooseGenerationLocation";
            this.ButtonChooseGenerationLocation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButtonChooseGenerationLocation.Size = new System.Drawing.Size(249, 79);
            this.ButtonChooseGenerationLocation.TabIndex = 10;
            this.ButtonChooseGenerationLocation.Text = "Set Generations Locations";
            this.ButtonChooseGenerationLocation.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(863, 1050);
            this.Controls.Add(this.ButtonChooseGenerationLocation);
            this.Controls.Add(this.ButtonChooseAssets);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.BtnGenerate);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.label_generationsCount);
            this.Controls.Add(this.GenerationPath);
            this.Controls.Add(this.label_generationPath);
            this.Controls.Add(this.label_assetsPath);
            this.Controls.Add(this.AssetsPath);
            this.Controls.Add(this.Image);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "DeadLunatixGen";
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox Image;
        private Label AssetsFolder;
        private Label AssetsPath;
        private Label label_assetsPath;
        private Label label_generationPath;
        private Label GenerationPath;
        private Label label_generationsCount;
        private NumericUpDown Amount;
        private Button BtnGenerate;
        private Button Clear;
        private Button ButtonChooseAssets;
        private Button ButtonChooseGenerationLocation;
    }
}