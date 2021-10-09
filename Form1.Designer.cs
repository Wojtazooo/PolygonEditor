
namespace PolygonEditor
{
    partial class MainForm
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
            this.formSplitter = new System.Windows.Forms.SplitContainer();
            this.DrawingArea = new System.Windows.Forms.PictureBox();
            this.textBoxHelper = new System.Windows.Forms.TextBox();
            this.GroupBoxColorOptions = new System.Windows.Forms.GroupBox();
            this.LabelCurrentColor = new System.Windows.Forms.Label();
            this.PictureBoxSelectedColor = new System.Windows.Forms.PictureBox();
            this.ButtonPickColor = new System.Windows.Forms.Button();
            this.polygonOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.ButtonDeletePolygon = new System.Windows.Forms.Button();
            this.ButtonEditPolygon = new System.Windows.Forms.Button();
            this.ButtonAddPolygon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.formSplitter)).BeginInit();
            this.formSplitter.Panel1.SuspendLayout();
            this.formSplitter.Panel2.SuspendLayout();
            this.formSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingArea)).BeginInit();
            this.GroupBoxColorOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSelectedColor)).BeginInit();
            this.polygonOptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSplitter
            // 
            this.formSplitter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.formSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSplitter.Location = new System.Drawing.Point(0, 0);
            this.formSplitter.Name = "formSplitter";
            // 
            // formSplitter.Panel1
            // 
            this.formSplitter.Panel1.Controls.Add(this.DrawingArea);
            this.formSplitter.Panel1MinSize = 800;
            // 
            // formSplitter.Panel2
            // 
            this.formSplitter.Panel2.Controls.Add(this.textBoxHelper);
            this.formSplitter.Panel2.Controls.Add(this.GroupBoxColorOptions);
            this.formSplitter.Panel2.Controls.Add(this.polygonOptionsGroupBox);
            this.formSplitter.Panel2MinSize = 300;
            this.formSplitter.Size = new System.Drawing.Size(1184, 761);
            this.formSplitter.SplitterDistance = 880;
            this.formSplitter.TabIndex = 0;
            // 
            // DrawingArea
            // 
            this.DrawingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawingArea.Location = new System.Drawing.Point(0, 0);
            this.DrawingArea.Name = "DrawingArea";
            this.DrawingArea.Size = new System.Drawing.Size(880, 761);
            this.DrawingArea.TabIndex = 0;
            this.DrawingArea.TabStop = false;
            this.DrawingArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingArea_MouseClick);
            this.DrawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingArea_MouseMove);
            // 
            // textBoxHelper
            // 
            this.textBoxHelper.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxHelper.Enabled = false;
            this.textBoxHelper.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxHelper.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBoxHelper.Location = new System.Drawing.Point(0, 255);
            this.textBoxHelper.Multiline = true;
            this.textBoxHelper.Name = "textBoxHelper";
            this.textBoxHelper.PlaceholderText = "Help text";
            this.textBoxHelper.ReadOnly = true;
            this.textBoxHelper.Size = new System.Drawing.Size(300, 151);
            this.textBoxHelper.TabIndex = 2;
            // 
            // GroupBoxColorOptions
            // 
            this.GroupBoxColorOptions.Controls.Add(this.LabelCurrentColor);
            this.GroupBoxColorOptions.Controls.Add(this.PictureBoxSelectedColor);
            this.GroupBoxColorOptions.Controls.Add(this.ButtonPickColor);
            this.GroupBoxColorOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBoxColorOptions.Location = new System.Drawing.Point(0, 134);
            this.GroupBoxColorOptions.Name = "GroupBoxColorOptions";
            this.GroupBoxColorOptions.Size = new System.Drawing.Size(300, 121);
            this.GroupBoxColorOptions.TabIndex = 1;
            this.GroupBoxColorOptions.TabStop = false;
            this.GroupBoxColorOptions.Text = "Color options";
            // 
            // LabelCurrentColor
            // 
            this.LabelCurrentColor.AutoSize = true;
            this.LabelCurrentColor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelCurrentColor.Location = new System.Drawing.Point(69, 67);
            this.LabelCurrentColor.MinimumSize = new System.Drawing.Size(0, 37);
            this.LabelCurrentColor.Name = "LabelCurrentColor";
            this.LabelCurrentColor.Size = new System.Drawing.Size(113, 37);
            this.LabelCurrentColor.TabIndex = 3;
            this.LabelCurrentColor.Text = "Selected Color:";
            this.LabelCurrentColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PictureBoxSelectedColor
            // 
            this.PictureBoxSelectedColor.Location = new System.Drawing.Point(188, 67);
            this.PictureBoxSelectedColor.Name = "PictureBoxSelectedColor";
            this.PictureBoxSelectedColor.Size = new System.Drawing.Size(37, 37);
            this.PictureBoxSelectedColor.TabIndex = 2;
            this.PictureBoxSelectedColor.TabStop = false;
            // 
            // ButtonPickColor
            // 
            this.ButtonPickColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonPickColor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonPickColor.Image = global::PolygonEditor.Properties.Resources.color_wheel;
            this.ButtonPickColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonPickColor.Location = new System.Drawing.Point(3, 19);
            this.ButtonPickColor.Name = "ButtonPickColor";
            this.ButtonPickColor.Size = new System.Drawing.Size(294, 37);
            this.ButtonPickColor.TabIndex = 1;
            this.ButtonPickColor.Text = "Change Color";
            this.ButtonPickColor.UseVisualStyleBackColor = true;
            this.ButtonPickColor.Click += new System.EventHandler(this.ButtonPickColor_Click);
            // 
            // polygonOptionsGroupBox
            // 
            this.polygonOptionsGroupBox.Controls.Add(this.ButtonDeletePolygon);
            this.polygonOptionsGroupBox.Controls.Add(this.ButtonEditPolygon);
            this.polygonOptionsGroupBox.Controls.Add(this.ButtonAddPolygon);
            this.polygonOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.polygonOptionsGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.polygonOptionsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.polygonOptionsGroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.polygonOptionsGroupBox.Name = "polygonOptionsGroupBox";
            this.polygonOptionsGroupBox.Size = new System.Drawing.Size(300, 134);
            this.polygonOptionsGroupBox.TabIndex = 0;
            this.polygonOptionsGroupBox.TabStop = false;
            this.polygonOptionsGroupBox.Text = "Polygon options";
            // 
            // ButtonDeletePolygon
            // 
            this.ButtonDeletePolygon.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonDeletePolygon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonDeletePolygon.Image = global::PolygonEditor.Properties.Resources.delete;
            this.ButtonDeletePolygon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDeletePolygon.Location = new System.Drawing.Point(3, 93);
            this.ButtonDeletePolygon.Name = "ButtonDeletePolygon";
            this.ButtonDeletePolygon.Size = new System.Drawing.Size(294, 37);
            this.ButtonDeletePolygon.TabIndex = 2;
            this.ButtonDeletePolygon.Text = "Delete Polygon";
            this.ButtonDeletePolygon.UseVisualStyleBackColor = true;
            // 
            // ButtonEditPolygon
            // 
            this.ButtonEditPolygon.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonEditPolygon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonEditPolygon.Image = global::PolygonEditor.Properties.Resources.pencil;
            this.ButtonEditPolygon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonEditPolygon.Location = new System.Drawing.Point(3, 56);
            this.ButtonEditPolygon.Name = "ButtonEditPolygon";
            this.ButtonEditPolygon.Size = new System.Drawing.Size(294, 37);
            this.ButtonEditPolygon.TabIndex = 1;
            this.ButtonEditPolygon.Text = "Edit Polygon";
            this.ButtonEditPolygon.UseVisualStyleBackColor = true;
            // 
            // ButtonAddPolygon
            // 
            this.ButtonAddPolygon.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonAddPolygon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonAddPolygon.Image = global::PolygonEditor.Properties.Resources.plus;
            this.ButtonAddPolygon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAddPolygon.Location = new System.Drawing.Point(3, 19);
            this.ButtonAddPolygon.Name = "ButtonAddPolygon";
            this.ButtonAddPolygon.Size = new System.Drawing.Size(294, 37);
            this.ButtonAddPolygon.TabIndex = 0;
            this.ButtonAddPolygon.Text = "Add New Polygon";
            this.ButtonAddPolygon.UseVisualStyleBackColor = true;
            this.ButtonAddPolygon.Click += new System.EventHandler(this.ButtonAddPolygon_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.formSplitter);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Text = "Polygon Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.formSplitter.Panel1.ResumeLayout(false);
            this.formSplitter.Panel2.ResumeLayout(false);
            this.formSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formSplitter)).EndInit();
            this.formSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DrawingArea)).EndInit();
            this.GroupBoxColorOptions.ResumeLayout(false);
            this.GroupBoxColorOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSelectedColor)).EndInit();
            this.polygonOptionsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer formSplitter;
        private System.Windows.Forms.PictureBox DrawingArea;
        private System.Windows.Forms.GroupBox polygonOptionsGroupBox;
        private System.Windows.Forms.Button ButtonDeletePolygon;
        private System.Windows.Forms.Button ButtonEditPolygon;
        private System.Windows.Forms.Button ButtonAddPolygon;
        private System.Windows.Forms.GroupBox GroupBoxColorOptions;
        private System.Windows.Forms.Label LabelCurrentColor;
        private System.Windows.Forms.PictureBox PictureBoxSelectedColor;
        private System.Windows.Forms.Button ButtonPickColor;
        private System.Windows.Forms.TextBox textBoxHelper;
    }
}

