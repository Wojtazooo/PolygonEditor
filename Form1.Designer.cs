
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonMoveObject = new System.Windows.Forms.Button();
            this.ButtonDeleteObject = new System.Windows.Forms.Button();
            this.GroupBoxShapeSelect = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonEditRadius = new System.Windows.Forms.Button();
            this.ButtonAddCircle = new System.Windows.Forms.Button();
            this.textBoxHelper = new System.Windows.Forms.TextBox();
            this.GroupBoxColorOptions = new System.Windows.Forms.GroupBox();
            this.LabelCurrentColor = new System.Windows.Forms.Label();
            this.PictureBoxSelectedColor = new System.Windows.Forms.PictureBox();
            this.ButtonPickColor = new System.Windows.Forms.Button();
            this.ShapeOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.MoveSegmentButton = new System.Windows.Forms.Button();
            this.MoveVertexButton = new System.Windows.Forms.Button();
            this.ButtonAddPolygon = new System.Windows.Forms.Button();
            this.ButtonRemoveVertex = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.formSplitter)).BeginInit();
            this.formSplitter.Panel1.SuspendLayout();
            this.formSplitter.Panel2.SuspendLayout();
            this.formSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingArea)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.GroupBoxShapeSelect.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.GroupBoxColorOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSelectedColor)).BeginInit();
            this.ShapeOptionsGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.formSplitter.Panel2.Controls.Add(this.groupBox1);
            this.formSplitter.Panel2.Controls.Add(this.GroupBoxShapeSelect);
            this.formSplitter.Panel2.Controls.Add(this.textBoxHelper);
            this.formSplitter.Panel2.Controls.Add(this.GroupBoxColorOptions);
            this.formSplitter.Panel2.Controls.Add(this.ShapeOptionsGroupBox);
            this.formSplitter.Panel2MinSize = 300;
            this.formSplitter.Size = new System.Drawing.Size(1284, 761);
            this.formSplitter.SplitterDistance = 850;
            this.formSplitter.TabIndex = 0;
            // 
            // DrawingArea
            // 
            this.DrawingArea.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DrawingArea.Cursor = System.Windows.Forms.Cursors.Default;
            this.DrawingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawingArea.Location = new System.Drawing.Point(0, 0);
            this.DrawingArea.Name = "DrawingArea";
            this.DrawingArea.Size = new System.Drawing.Size(850, 761);
            this.DrawingArea.TabIndex = 0;
            this.DrawingArea.TabStop = false;
            this.DrawingArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingArea_MouseClick);
            this.DrawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingArea_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(11, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 78);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ButtonMoveObject, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonDeleteObject, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(399, 56);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // ButtonMoveObject
            // 
            this.ButtonMoveObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMoveObject.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonMoveObject.Image = global::PolygonEditor.Properties.Resources.move;
            this.ButtonMoveObject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonMoveObject.Location = new System.Drawing.Point(205, 6);
            this.ButtonMoveObject.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonMoveObject.Name = "ButtonMoveObject";
            this.ButtonMoveObject.Size = new System.Drawing.Size(188, 37);
            this.ButtonMoveObject.TabIndex = 3;
            this.ButtonMoveObject.Text = "Move";
            this.ButtonMoveObject.UseVisualStyleBackColor = true;
            this.ButtonMoveObject.Click += new System.EventHandler(this.ButtonMoveObject_Click);
            // 
            // ButtonDeleteObject
            // 
            this.ButtonDeleteObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDeleteObject.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonDeleteObject.Image = global::PolygonEditor.Properties.Resources.delete;
            this.ButtonDeleteObject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDeleteObject.Location = new System.Drawing.Point(6, 6);
            this.ButtonDeleteObject.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonDeleteObject.Name = "ButtonDeleteObject";
            this.ButtonDeleteObject.Size = new System.Drawing.Size(187, 37);
            this.ButtonDeleteObject.TabIndex = 2;
            this.ButtonDeleteObject.Text = "Delete";
            this.ButtonDeleteObject.UseVisualStyleBackColor = true;
            this.ButtonDeleteObject.Click += new System.EventHandler(this.ButtonDeleteObject_Click);
            // 
            // GroupBoxShapeSelect
            // 
            this.GroupBoxShapeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxShapeSelect.Controls.Add(this.tableLayoutPanel3);
            this.GroupBoxShapeSelect.Location = new System.Drawing.Point(11, 12);
            this.GroupBoxShapeSelect.Name = "GroupBoxShapeSelect";
            this.GroupBoxShapeSelect.Size = new System.Drawing.Size(405, 79);
            this.GroupBoxShapeSelect.TabIndex = 3;
            this.GroupBoxShapeSelect.TabStop = false;
            this.GroupBoxShapeSelect.Text = "Circle Options";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.ButtonEditRadius, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.ButtonAddCircle, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(399, 57);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // ButtonEditRadius
            // 
            this.ButtonEditRadius.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonEditRadius.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonEditRadius.Image = global::PolygonEditor.Properties.Resources.pencil;
            this.ButtonEditRadius.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonEditRadius.Location = new System.Drawing.Point(205, 6);
            this.ButtonEditRadius.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonEditRadius.Name = "ButtonEditRadius";
            this.ButtonEditRadius.Size = new System.Drawing.Size(188, 37);
            this.ButtonEditRadius.TabIndex = 5;
            this.ButtonEditRadius.Text = "Edit Radius";
            this.ButtonEditRadius.UseVisualStyleBackColor = true;
            // 
            // ButtonAddCircle
            // 
            this.ButtonAddCircle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddCircle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonAddCircle.Image = global::PolygonEditor.Properties.Resources.plus;
            this.ButtonAddCircle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAddCircle.Location = new System.Drawing.Point(6, 6);
            this.ButtonAddCircle.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonAddCircle.Name = "ButtonAddCircle";
            this.ButtonAddCircle.Size = new System.Drawing.Size(187, 37);
            this.ButtonAddCircle.TabIndex = 1;
            this.ButtonAddCircle.Text = "Add Circle";
            this.ButtonAddCircle.UseVisualStyleBackColor = true;
            this.ButtonAddCircle.Click += new System.EventHandler(this.ButtonAddCircle_Click);
            // 
            // textBoxHelper
            // 
            this.textBoxHelper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHelper.Enabled = false;
            this.textBoxHelper.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxHelper.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBoxHelper.Location = new System.Drawing.Point(11, 503);
            this.textBoxHelper.Multiline = true;
            this.textBoxHelper.Name = "textBoxHelper";
            this.textBoxHelper.PlaceholderText = "Help text";
            this.textBoxHelper.ReadOnly = true;
            this.textBoxHelper.Size = new System.Drawing.Size(405, 246);
            this.textBoxHelper.TabIndex = 2;
            // 
            // GroupBoxColorOptions
            // 
            this.GroupBoxColorOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxColorOptions.Controls.Add(this.LabelCurrentColor);
            this.GroupBoxColorOptions.Controls.Add(this.PictureBoxSelectedColor);
            this.GroupBoxColorOptions.Controls.Add(this.ButtonPickColor);
            this.GroupBoxColorOptions.Location = new System.Drawing.Point(11, 376);
            this.GroupBoxColorOptions.Name = "GroupBoxColorOptions";
            this.GroupBoxColorOptions.Size = new System.Drawing.Size(405, 121);
            this.GroupBoxColorOptions.TabIndex = 1;
            this.GroupBoxColorOptions.TabStop = false;
            this.GroupBoxColorOptions.Text = "Color options";
            // 
            // LabelCurrentColor
            // 
            this.LabelCurrentColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.PictureBoxSelectedColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBoxSelectedColor.Location = new System.Drawing.Point(188, 67);
            this.PictureBoxSelectedColor.MaximumSize = new System.Drawing.Size(37, 37);
            this.PictureBoxSelectedColor.MinimumSize = new System.Drawing.Size(37, 37);
            this.PictureBoxSelectedColor.Name = "PictureBoxSelectedColor";
            this.PictureBoxSelectedColor.Size = new System.Drawing.Size(37, 37);
            this.PictureBoxSelectedColor.TabIndex = 2;
            this.PictureBoxSelectedColor.TabStop = false;
            // 
            // ButtonPickColor
            // 
            this.ButtonPickColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonPickColor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonPickColor.Image = global::PolygonEditor.Properties.Resources.color_wheel;
            this.ButtonPickColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonPickColor.Location = new System.Drawing.Point(9, 25);
            this.ButtonPickColor.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonPickColor.Name = "ButtonPickColor";
            this.ButtonPickColor.Size = new System.Drawing.Size(384, 37);
            this.ButtonPickColor.TabIndex = 1;
            this.ButtonPickColor.Text = "Change Color";
            this.ButtonPickColor.UseVisualStyleBackColor = true;
            this.ButtonPickColor.Click += new System.EventHandler(this.ButtonPickColor_Click);
            // 
            // ShapeOptionsGroupBox
            // 
            this.ShapeOptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShapeOptionsGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.ShapeOptionsGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShapeOptionsGroupBox.Location = new System.Drawing.Point(11, 99);
            this.ShapeOptionsGroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.ShapeOptionsGroupBox.Name = "ShapeOptionsGroupBox";
            this.ShapeOptionsGroupBox.Size = new System.Drawing.Size(405, 185);
            this.ShapeOptionsGroupBox.TabIndex = 0;
            this.ShapeOptionsGroupBox.TabStop = false;
            this.ShapeOptionsGroupBox.Text = "Polygon Options";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.62406F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.37594F));
            this.tableLayoutPanel2.Controls.Add(this.ButtonRemoveVertex, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.MoveSegmentButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.MoveVertexButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ButtonAddPolygon, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.37615F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.62385F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(399, 163);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // MoveSegmentButton
            // 
            this.MoveSegmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveSegmentButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MoveSegmentButton.Image = global::PolygonEditor.Properties.Resources.pencil;
            this.MoveSegmentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MoveSegmentButton.Location = new System.Drawing.Point(6, 62);
            this.MoveSegmentButton.Margin = new System.Windows.Forms.Padding(6);
            this.MoveSegmentButton.Name = "MoveSegmentButton";
            this.MoveSegmentButton.Size = new System.Drawing.Size(186, 37);
            this.MoveSegmentButton.TabIndex = 2;
            this.MoveSegmentButton.Text = "Move Segment";
            this.MoveSegmentButton.UseVisualStyleBackColor = true;
            // 
            // MoveVertexButton
            // 
            this.MoveVertexButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveVertexButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MoveVertexButton.Image = global::PolygonEditor.Properties.Resources.pencil;
            this.MoveVertexButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MoveVertexButton.Location = new System.Drawing.Point(204, 6);
            this.MoveVertexButton.Margin = new System.Windows.Forms.Padding(6);
            this.MoveVertexButton.Name = "MoveVertexButton";
            this.MoveVertexButton.Size = new System.Drawing.Size(189, 37);
            this.MoveVertexButton.TabIndex = 1;
            this.MoveVertexButton.Text = "Move Vertex";
            this.MoveVertexButton.UseVisualStyleBackColor = true;
            this.MoveVertexButton.Click += new System.EventHandler(this.ButtonEditObject_Click);
            // 
            // ButtonAddPolygon
            // 
            this.ButtonAddPolygon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddPolygon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonAddPolygon.Image = global::PolygonEditor.Properties.Resources.plus;
            this.ButtonAddPolygon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAddPolygon.Location = new System.Drawing.Point(6, 6);
            this.ButtonAddPolygon.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonAddPolygon.Name = "ButtonAddPolygon";
            this.ButtonAddPolygon.Size = new System.Drawing.Size(186, 37);
            this.ButtonAddPolygon.TabIndex = 0;
            this.ButtonAddPolygon.Text = "Add Polygon";
            this.ButtonAddPolygon.UseVisualStyleBackColor = true;
            this.ButtonAddPolygon.Click += new System.EventHandler(this.ButtonAddPolygon_Click);
            // 
            // ButtonRemoveVertex
            // 
            this.ButtonRemoveVertex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRemoveVertex.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonRemoveVertex.Image = global::PolygonEditor.Properties.Resources.delete;
            this.ButtonRemoveVertex.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonRemoveVertex.Location = new System.Drawing.Point(6, 115);
            this.ButtonRemoveVertex.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonRemoveVertex.Name = "ButtonRemoveVertex";
            this.ButtonRemoveVertex.Size = new System.Drawing.Size(186, 37);
            this.ButtonRemoveVertex.TabIndex = 3;
            this.ButtonRemoveVertex.Text = "Remove Vertex";
            this.ButtonRemoveVertex.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.formSplitter);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Text = "Polygon Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.formSplitter.Panel1.ResumeLayout(false);
            this.formSplitter.Panel2.ResumeLayout(false);
            this.formSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formSplitter)).EndInit();
            this.formSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DrawingArea)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.GroupBoxShapeSelect.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.GroupBoxColorOptions.ResumeLayout(false);
            this.GroupBoxColorOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSelectedColor)).EndInit();
            this.ShapeOptionsGroupBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer formSplitter;
        private System.Windows.Forms.PictureBox DrawingArea;
        private System.Windows.Forms.Button ButtonDeleteObject;
        private System.Windows.Forms.Button MoveVertexButton;
        private System.Windows.Forms.Button ButtonAddPolygon;
        private System.Windows.Forms.GroupBox GroupBoxColorOptions;
        private System.Windows.Forms.Label LabelCurrentColor;
        private System.Windows.Forms.PictureBox PictureBoxSelectedColor;
        private System.Windows.Forms.Button ButtonPickColor;
        private System.Windows.Forms.TextBox textBoxHelper;
        private System.Windows.Forms.GroupBox GroupBoxShapeSelect;
        private System.Windows.Forms.GroupBox ShapeOptionsGroupBox;
        private System.Windows.Forms.Button ButtonMoveObject;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ButtonAddCircle;
        private System.Windows.Forms.Button MoveSegmentButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button ButtonEditRadius;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button ButtonRemoveVertex;
    }
}

