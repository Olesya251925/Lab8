namespace FileSyncApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button syncButton;
        private System.Windows.Forms.TextBox statusTextBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.syncButton = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // syncButton
            //
            this.syncButton.Location = new System.Drawing.Point(12, 12);
            this.syncButton.Name = "syncButton";
            this.syncButton.Size = new System.Drawing.Size(120, 30);
            this.syncButton.TabIndex = 0;
            this.syncButton.Text = "Синхронизировать";
            this.syncButton.UseVisualStyleBackColor = true;
            //
            // statusTextBox
            //
            this.statusTextBox.Location = new System.Drawing.Point(12, 48);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusTextBox.Size = new System.Drawing.Size(300, 200);
            this.statusTextBox.TabIndex = 1;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 261);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.syncButton);
            this.Name = "Form1";
            this.Text = "FileSyncApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
