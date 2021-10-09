
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
            this.GroupBoxShapeSelect = new System.Windows.Forms.GroupBox();
            this.RadioButtonCircleSelected = new System.Windows.Forms.RadioButton();
            this.RadioButtonPolygonSelected = new System.Windows.Forms.RadioButton();
            this.textBoxHelper = new System.Windows.Forms.TextBox();
            this.GroupBoxColorOptions = new System.Windows.Forms.GroupBox();
            this.LabelCurrentColor = new System.Windows.Forms.Label();
            this.PictureBoxSelectedColor = new System.Windows.Forms.PictureBox();
            this.ButtonPickColor = new System.Windows.Forms.Button();
            this.ShapeOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.ButtonDeleteObject = new System.Windows.Forms.Button();
            this.ButtonEditObject = new System.Windows.Forms.Button();
            this.ButtonAddObject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.formSplitter)).BeginInit();
            this.formSplitter.Panel1.SuspendLayout();
            this.formSplitter.Panel2.SuspendLayout();
            this.formSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingArea)).BeginInit();
            this.GroupBoxShapeSelect.SuspendLayout();
            this.GroupBoxColorOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSelectedColor)).BeginInit();
            this.ShapeOptionsGroupBox.SuspendLayout();
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
            this.formSplitter.Panel2.BackColor = System.Drawing.Color.Ivory;
            this.formSplitter.Panel2.Controls.Add(this.GroupBoxShapeSelect);
            this.formSplitter.Panel2.Controls.Add(this.textBoxHelper);
            this.formSplitter.Panel2.Controls.Add(this.GroupBoxColorOptions);
            this.formSplitter.Panel2.Controls.Add(this.ShapeOptionsGroupBox);
            this.formSplitter.Panel2MinSize = 300;
            this.formSplitter.Size = new System.Drawing.Size(1184, 761);
            this.formSplitter.SplitterDistance = 880;
            this.formSplitter.TabIndex = 0;
            // 
            // DrawingArea
            // 
            this.DrawingArea.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DrawingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawingArea.Location = new System.Drawing.Point(0, 0);
            this.DrawingArea.Name = "DrawingArea";
            this.DrawingArea.Size = new System.Drawing.Size(880, 761);
            this.DrawingArea.TabIndex = 0;
            this.DrawingArea.TabStop = false;
            this.DrawingArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingArea_MouseClick);
            this.DrawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingArea_MouseMove);
            // 
            // GroupBoxShapeSelect
            // 
            this.GroupBoxShapeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxShapeSelect.Controls.Add(this.RadioButtonCircleSelected);
            this.GroupBoxShapeSelect.Controls.Add(this.RadioButtonPolygonSelected);
            this.GroupBoxShapeSelect.Location = new System.Drawing.Point(11, 12);
            this.GroupBoxShapeSelect.Name = "GroupBoxShapeSelect";
            this.GroupBoxShapeSelect.Size = new System.Drawing.Size(275, 82);
            this.GroupBoxShapeSelect.TabIndex = 3;
            this.GroupBoxShapeSelect.TabStop = false;
            this.GroupBoxShapeSelect.Text = "Shape Select";
            // 
            // RadioButtonCircleSelected
            // 
            this.RadioButtonCircleSelected.AutoSize = true;
            this.RadioButtonCircleSelected.Location = new System.Drawing.Point(13, 53);
            this.RadioButtonCircleSelected.Margin = new System.Windows.Forms.Padding(5);
            this.RadioButtonCircleSelected.Name = "RadioButtonCircleSelected";
            this.RadioButtonCircleSelected.Size = new System.Drawing.Size(55, 19);
            this.RadioButtonCircleSelected.TabIndex = 1;
            this.RadioButtonCircleSelected.Text = "Circle";
            this.RadioButtonCircleSelected.UseVisualStyleBackColor = true;
            // 
            // RadioButtonPolygonSelected
            // 
            this.RadioButtonPolygonSelected.AutoSize = true;
            this.RadioButtonPolygonSelected.Checked = true;
            this.RadioButtonPolygonSelected.Location = new System.Drawing.Point(13, 24);
            this.RadioButtonPolygonSelected.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.RadioButtonPolygonSelected.Name = "RadioButtonPolygonSelected";
            this.RadioButtonPolygonSelected.Size = new System.Drawing.Size(69, 19);
            this.RadioButtonPolygonSelected.TabIndex = 0;
            this.RadioButtonPolygonSelected.TabStop = true;
            this.RadioButtonPolygonSelected.Text = "Polygon";
            this.RadioButtonPolygonSelected.UseVisualStyleBackColor = true;
            // 
            // textBoxHelper
            // 
            this.textBoxHelper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHelper.Enabled = false;
            this.textBoxHelper.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxHelper.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBoxHelper.Location = new System.Drawing.Point(11, 413);
            this.textBoxHelper.Multiline = true;
            this.textBoxHelper.Name = "textBoxHelper";
            this.textBoxHelper.PlaceholderText = "Help text";
            this.textBoxHelper.ReadOnly = true;
            this.textBoxHelper.Size = new System.Drawing.Size(275, 336);
            this.textBoxHelper.TabIndex = 2;
            // 
            // GroupBoxColorOptions
            // 
            this.GroupBoxColorOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxColorOptions.Controls.Add(this.LabelCurrentColor);
            this.GroupBoxColorOptions.Controls.Add(this.PictureBoxSelectedColor);
            this.GroupBoxColorOptions.Controls.Add(this.ButtonPickColor);
            this.GroupBoxColorOptions.Location = new System.Drawing.Point(11, 286);
            this.GroupBoxColorOptions.Name = "GroupBoxColorOptions";
            this.GroupBoxColorOptions.Size = new System.Drawing.Size(275, 121);
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
            this.ButtonPickColor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonPickColor.Image = global::PolygonEditor.Properties.Resources.color_wheel;
            this.ButtonPickColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonPickColor.Location = new System.Drawing.Point(9, 25);
            this.ButtonPickColor.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonPickColor.Name = "ButtonPickColor";
            this.ButtonPickColor.Size = new System.Drawing.Size(254, 37);
            this.ButtonPickColor.TabIndex = 1;
            this.ButtonPickColor.Text = "Change Color";
            this.ButtonPickColor.UseVisualStyleBackColor = true;
            this.ButtonPickColor.Click += new System.EventHandler(this.ButtonPickColor_Click);
            // 
            // ShapeOptionsGroupBox
            // 
            this.ShapeOptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ShapeOptionsGroupBox.Controls.Add(this.ButtonDeleteObject);
            this.ShapeOptionsGroupBox.Controls.Add(this.ButtonEditObject);
            this.ShapeOptionsGroupBox.Controls.Add(this.ButtonAddObject);
            this.ShapeOptionsGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShapeOptionsGroupBox.Location = new System.Drawing.Point(11, 102);
            this.ShapeOptionsGroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.ShapeOptionsGroupBox.Name = "ShapeOptionsGroupBox";
            this.ShapeOptionsGroupBox.Size = new System.Drawing.Size(275, 176);
            this.ShapeOptionsGroupBox.TabIndex = 0;
            this.ShapeOptionsGroupBox.TabStop = false;
            this.ShapeOptionsGroupBox.Text = "Shape Options";
            // 
            // ButtonDeleteObject
            // 
            this.ButtonDeleteObject.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonDeleteObject.Image = global::PolygonEditor.Properties.Resources.delete;
            this.ButtonDeleteObject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDeleteObject.Location = new System.Drawing.Point(9, 123);
            this.ButtonDeleteObject.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonDeleteObject.Name = "ButtonDeleteObject";
            this.ButtonDeleteObject.Size = new System.Drawing.Size(254, 37);
            this.ButtonDeleteObject.TabIndex = 2;
            this.ButtonDeleteObject.Text = "Delete";
            this.ButtonDeleteObject.UseVisualStyleBackColor = true;
            // 
            // ButtonEditObject
            // 
            this.ButtonEditObject.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonEditObject.Image = global::PolygonEditor.Properties.Resources.pencil;
            this.ButtonEditObject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonEditObject.Location = new System.Drawing.Point(9, 74);
            this.ButtonEditObject.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonEditObject.Name = "ButtonEditObject";
            this.ButtonEditObject.Size = new System.Drawing.Size(254, 37);
            this.ButtonEditObject.TabIndex = 1;
            this.ButtonEditObject.Text = "Edit";
            this.ButtonEditObject.UseVisualStyleBackColor = true;
            // 
            // ButtonAddObject
            // 
            this.ButtonAddObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddObject.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonAddObject.Image = global::PolygonEditor.Properties.Resources.plus;
            this.ButtonAddObject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAddObject.Location = new System.Drawing.Point(9, 25);
            this.ButtonAddObject.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonAddObject.Name = "ButtonAddObject";
            this.ButtonAddObject.Size = new System.Drawing.Size(254, 37);
            this.ButtonAddObject.TabIndex = 0;
            this.ButtonAddObject.Text = "Add New";
            this.ButtonAddObject.UseVisualStyleBackColor = true;
            this.ButtonAddObject.Click += new System.EventHandler(this.ButtonAdd_Click);
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
            this.GroupBoxShapeSelect.ResumeLayout(false);
            this.GroupBoxShapeSelect.PerformLayout();
            this.GroupBoxColorOptions.ResumeLayout(false);
            this.GroupBoxColorOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSelectedColor)).EndInit();
            this.ShapeOptionsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer formSplitter;
        private System.Windows.Forms.PictureBox DrawingArea;
        private System.Windows.Forms.GroupBox polygonOptionsGroupBox;
        private System.Windows.Forms.Button ButtonDeleteObject;
        private System.Windows.Forms.Button ButtonEditObject;
        private System.Windows.Forms.Button ButtonAddObject;
        private System.Windows.Forms.GroupBox GroupBoxColorOptions;
        private System.Windows.Forms.Label LabelCurrentColor;
        private System.Windows.Forms.PictureBox PictureBoxSelectedColor;
        private System.Windows.Forms.Button ButtonPickColor;
        private System.Windows.Forms.TextBox textBoxHelper;
        private System.Windows.Forms.GroupBox GroupBoxShapeSelect;
        private System.Windows.Forms.RadioButton RadioButtonCircleSelected;
        private System.Windows.Forms.RadioButton RadioButtonPolygon;
        private System.Windows.Forms.GroupBox ShapeOptionsGroupBox;
        private System.Windows.Forms.RadioButton RadioButtonPolygonSelected;
    }
}

