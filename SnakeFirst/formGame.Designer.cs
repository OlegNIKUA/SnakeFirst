namespace SnakeFirst
{
    partial class FormGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hrToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.extToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складністьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.легкийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.середнійToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складнийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LScore = new System.Windows.Forms.Label();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.правилаГриToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.складністьToolStripMenuItem1,
            this.правилаГриToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(832, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.hrToolStripMenuItem,
            this.extToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "Гра";
            // 
            // recordsToolStripMenuItem
            // 
            this.recordsToolStripMenuItem.Name = "recordsToolStripMenuItem";
            this.recordsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.recordsToolStripMenuItem.Text = "Рекорди";
            this.recordsToolStripMenuItem.Click += new System.EventHandler(this.recordsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aboutToolStripMenuItem.Text = "Про програму";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // hrToolStripMenuItem
            // 
            this.hrToolStripMenuItem.Name = "hrToolStripMenuItem";
            this.hrToolStripMenuItem.Size = new System.Drawing.Size(151, 6);
            // 
            // extToolStripMenuItem
            // 
            this.extToolStripMenuItem.Name = "extToolStripMenuItem";
            this.extToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.extToolStripMenuItem.Text = "Вийти";
            this.extToolStripMenuItem.Click += new System.EventHandler(this.extToolStripMenuItem_Click);
            // 
            // складністьToolStripMenuItem1
            // 
            this.складністьToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.легкийToolStripMenuItem,
            this.середнійToolStripMenuItem,
            this.складнийToolStripMenuItem});
            this.складністьToolStripMenuItem1.Name = "складністьToolStripMenuItem1";
            this.складністьToolStripMenuItem1.Size = new System.Drawing.Size(79, 20);
            this.складністьToolStripMenuItem1.Text = "Складність";
            // 
            // легкийToolStripMenuItem
            // 
            this.легкийToolStripMenuItem.Checked = true;
            this.легкийToolStripMenuItem.CheckOnClick = true;
            this.легкийToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.легкийToolStripMenuItem.Name = "легкийToolStripMenuItem";
            this.легкийToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.легкийToolStripMenuItem.Text = "Легкий";
            this.легкийToolStripMenuItem.Click += new System.EventHandler(this.легкийToolStripMenuItem_Click);
            // 
            // середнійToolStripMenuItem
            // 
            this.середнійToolStripMenuItem.CheckOnClick = true;
            this.середнійToolStripMenuItem.Name = "середнійToolStripMenuItem";
            this.середнійToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.середнійToolStripMenuItem.Text = "Середній";
            this.середнійToolStripMenuItem.Click += new System.EventHandler(this.середнійToolStripMenuItem_Click);
            // 
            // складнийToolStripMenuItem
            // 
            this.складнийToolStripMenuItem.CheckOnClick = true;
            this.складнийToolStripMenuItem.Name = "складнийToolStripMenuItem";
            this.складнийToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.складнийToolStripMenuItem.Text = "Складний";
            this.складнийToolStripMenuItem.Click += new System.EventHandler(this.складнийToolStripMenuItem_Click);
            // 
            // LScore
            // 
            this.LScore.AutoSize = true;
            this.LScore.Location = new System.Drawing.Point(12, 539);
            this.LScore.Name = "LScore";
            this.LScore.Size = new System.Drawing.Size(35, 13);
            this.LScore.TabIndex = 2;
            this.LScore.Text = "Score";
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.SystemColors.Highlight;
            this.pbCanvas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbCanvas.BackgroundImage")));
            this.pbCanvas.Location = new System.Drawing.Point(0, 24);
            this.pbCanvas.Margin = new System.Windows.Forms.Padding(0);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(832, 512);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Click += new System.EventHandler(this.pbCanvas_Click);
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            // 
            // правилаГриToolStripMenuItem
            // 
            this.правилаГриToolStripMenuItem.Name = "правилаГриToolStripMenuItem";
            this.правилаГриToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.правилаГриToolStripMenuItem.Text = "Правила гри";
            this.правилаГриToolStripMenuItem.Click += new System.EventHandler(this.правилаГриToolStripMenuItem_Click);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 561);
            this.Controls.Add(this.LScore);
            this.Controls.Add(this.pbCanvas);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Змійка";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.formGame_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator hrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extToolStripMenuItem;
        private System.Windows.Forms.Label LScore;
        private System.Windows.Forms.ToolStripMenuItem recordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem легкийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem середнійToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складнийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складністьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem правилаГриToolStripMenuItem;
    }
}