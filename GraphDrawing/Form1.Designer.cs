namespace GraphDrawing
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
            this.graphImage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.windowInput = new System.Windows.Forms.NumericUpDown();
            this.fillButton = new System.Windows.Forms.Button();
            this.colorSchemePicker = new System.Windows.Forms.ComboBox();
            this.gridLinesInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.selectionImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.graphImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLinesInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionImage)).BeginInit();
            this.SuspendLayout();
            // 
            // graphImage
            // 
            this.graphImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphImage.Location = new System.Drawing.Point(12, 42);
            this.graphImage.Name = "graphImage";
            this.graphImage.Size = new System.Drawing.Size(727, 372);
            this.graphImage.TabIndex = 0;
            this.graphImage.TabStop = false;
            this.graphImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphImage_MouseDown);
            this.graphImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphImage_MouseMove);
            this.graphImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graphImage_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Smooth";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // windowInput
            // 
            this.windowInput.Location = new System.Drawing.Point(95, 14);
            this.windowInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.windowInput.Name = "windowInput";
            this.windowInput.Size = new System.Drawing.Size(49, 20);
            this.windowInput.TabIndex = 2;
            this.windowInput.Value = new decimal(new int[] {
            101,
            0,
            0,
            0});
            // 
            // fillButton
            // 
            this.fillButton.Location = new System.Drawing.Point(198, 13);
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(75, 23);
            this.fillButton.TabIndex = 3;
            this.fillButton.Text = "Fill";
            this.fillButton.UseVisualStyleBackColor = true;
            this.fillButton.Click += new System.EventHandler(this.fillButton_Click);
            // 
            // colorSchemePicker
            // 
            this.colorSchemePicker.FormattingEnabled = true;
            this.colorSchemePicker.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.colorSchemePicker.Location = new System.Drawing.Point(672, 15);
            this.colorSchemePicker.Name = "colorSchemePicker";
            this.colorSchemePicker.Size = new System.Drawing.Size(67, 21);
            this.colorSchemePicker.TabIndex = 4;
            this.colorSchemePicker.Text = "Light";
            this.colorSchemePicker.SelectedIndexChanged += new System.EventHandler(this.colorSchemePicker_SelectedIndexChanged);
            // 
            // gridLinesInput
            // 
            this.gridLinesInput.Location = new System.Drawing.Point(348, 13);
            this.gridLinesInput.Name = "gridLinesInput";
            this.gridLinesInput.Size = new System.Drawing.Size(59, 20);
            this.gridLinesInput.TabIndex = 5;
            this.gridLinesInput.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.gridLinesInput.ValueChanged += new System.EventHandler(this.gridLinesInput_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(414, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Grid Lines";
            // 
            // selectionImage
            // 
            this.selectionImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectionImage.Location = new System.Drawing.Point(13, 420);
            this.selectionImage.Name = "selectionImage";
            this.selectionImage.Size = new System.Drawing.Size(726, 30);
            this.selectionImage.TabIndex = 7;
            this.selectionImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 459);
            this.Controls.Add(this.selectionImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridLinesInput);
            this.Controls.Add(this.colorSchemePicker);
            this.Controls.Add(this.fillButton);
            this.Controls.Add(this.windowInput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.graphImage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.graphImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLinesInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox graphImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown windowInput;
        private System.Windows.Forms.Button fillButton;
        private System.Windows.Forms.ComboBox colorSchemePicker;
        private System.Windows.Forms.NumericUpDown gridLinesInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox selectionImage;
    }
}

