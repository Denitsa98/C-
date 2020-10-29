namespace WindowsFormsApplication1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.insertUpdateDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertupdatedeleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAndReferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertUpdateDeleteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(515, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // insertUpdateDeleteToolStripMenuItem
            // 
            this.insertUpdateDeleteToolStripMenuItem.BackColor = System.Drawing.Color.Lime;
            this.insertUpdateDeleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertupdatedeleteToolStripMenuItem1,
            this.updateDepartmentToolStripMenuItem,
            this.positionToolStripMenuItem,
            this.searchAndReferencesToolStripMenuItem});
            this.insertUpdateDeleteToolStripMenuItem.Name = "insertUpdateDeleteToolStripMenuItem";
            this.insertUpdateDeleteToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.insertUpdateDeleteToolStripMenuItem.Text = "Options";
            // 
            // insertupdatedeleteToolStripMenuItem1
            // 
            this.insertupdatedeleteToolStripMenuItem1.BackColor = System.Drawing.Color.Lime;
            this.insertupdatedeleteToolStripMenuItem1.Name = "insertupdatedeleteToolStripMenuItem1";
            this.insertupdatedeleteToolStripMenuItem1.Size = new System.Drawing.Size(320, 24);
            this.insertupdatedeleteToolStripMenuItem1.Text = "Editing/Delete/Create a Worker";
            this.insertupdatedeleteToolStripMenuItem1.Click += new System.EventHandler(this.insertupdatedeleteToolStripMenuItem1_Click);
            // 
            // searchAndReferencesToolStripMenuItem
            // 
            this.searchAndReferencesToolStripMenuItem.BackColor = System.Drawing.Color.Lime;
            this.searchAndReferencesToolStripMenuItem.Name = "searchAndReferencesToolStripMenuItem";
            this.searchAndReferencesToolStripMenuItem.Size = new System.Drawing.Size(320, 24);
            this.searchAndReferencesToolStripMenuItem.Text = "Search and references";
            this.searchAndReferencesToolStripMenuItem.Click += new System.EventHandler(this.searchAndReferencesToolStripMenuItem_Click);
            // 
            // updateDepartmentToolStripMenuItem
            // 
            this.updateDepartmentToolStripMenuItem.BackColor = System.Drawing.Color.Lime;
            this.updateDepartmentToolStripMenuItem.Name = "updateDepartmentToolStripMenuItem";
            this.updateDepartmentToolStripMenuItem.Size = new System.Drawing.Size(320, 24);
            this.updateDepartmentToolStripMenuItem.Text = "Editing/Delete/Create a Department";
            this.updateDepartmentToolStripMenuItem.Click += new System.EventHandler(this.updateDepartmentToolStripMenuItem_Click);
            // 
            // positionToolStripMenuItem
            // 
            this.positionToolStripMenuItem.BackColor = System.Drawing.Color.Lime;
            this.positionToolStripMenuItem.Name = "positionToolStripMenuItem";
            this.positionToolStripMenuItem.Size = new System.Drawing.Size(320, 24);
            this.positionToolStripMenuItem.Text = "Editing/Delete/Create a Position";
            this.positionToolStripMenuItem.Click += new System.EventHandler(this.positionToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.e7b006f8_1b25_4709_b93c_aaf951cdc369_200x200;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(515, 390);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Wellcome";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem insertUpdateDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertupdatedeleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem searchAndReferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionToolStripMenuItem;
    }
}

