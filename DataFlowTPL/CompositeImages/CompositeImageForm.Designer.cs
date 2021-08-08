
namespace CompositeImages
{
    partial class CompositeImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompositeImageForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbChooseFld = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbChooseFld,
            this.tsbCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1513, 52);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbChooseFld
            // 
            this.tsbChooseFld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbChooseFld.Image = ((System.Drawing.Image)(resources.GetObject("tsbChooseFld.Image")));
            this.tsbChooseFld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbChooseFld.Name = "tsbChooseFld";
            this.tsbChooseFld.Size = new System.Drawing.Size(215, 45);
            this.tsbChooseFld.Text = "Choose Folder";
            this.tsbChooseFld.Click += new System.EventHandler(this.tsbChooseFld_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(110, 45);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // pbImage
            // 
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(0, 52);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(1513, 1147);
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            // 
            // CompositeImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 1199);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CompositeImageForm";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbChooseFld;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.PictureBox pbImage;
    }
}

