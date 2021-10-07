
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
            ((System.ComponentModel.ISupportInitialize)(this.formSplitter)).BeginInit();
            this.formSplitter.Panel1.SuspendLayout();
            this.formSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // formSplitter
            // 
            this.formSplitter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.formSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSplitter.Location = new System.Drawing.Point(0, 0);
            this.formSplitter.Name = "formSplitter";
            // 
            // formSplitter.PanelDrawing
            // 
            this.formSplitter.Panel1.Controls.Add(this.DrawingArea);
            this.formSplitter.Panel1MinSize = 800;
            // 
            // formSplitter.PanelTools
            // 
            this.formSplitter.Panel2MinSize = 300;
            this.formSplitter.Size = new System.Drawing.Size(1184, 761);
            this.formSplitter.SplitterDistance = 800;
            this.formSplitter.TabIndex = 0;
            // 
            // DrawingArea
            // 
            this.DrawingArea.Location = new System.Drawing.Point(12, 12);
            this.DrawingArea.Name = "DrawingArea";
            this.DrawingArea.Size = new System.Drawing.Size(785, 737);
            this.DrawingArea.TabIndex = 0;
            this.DrawingArea.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.formSplitter);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Text = "Polygon Editor";
            this.formSplitter.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formSplitter)).EndInit();
            this.formSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DrawingArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer formSplitter;
        private System.Windows.Forms.PictureBox DrawingArea;
    }
}

