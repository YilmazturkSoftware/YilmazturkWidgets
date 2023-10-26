namespace Yılmaztürk_Widgets
{
    partial class Hour
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
            this.components = new System.ComponentModel.Container();
            this.date = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.timeLBL = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.widgetıKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // date
            // 
            this.date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.date.Font = new System.Drawing.Font("Segoe UI Light", 16F);
            this.date.ForeColor = System.Drawing.Color.DodgerBlue;
            this.date.Location = new System.Drawing.Point(19, 115);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(405, 35);
            this.date.TabIndex = 4;
            this.date.Text = "date";
            this.date.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // tim
            // 
            this.tim.Tick += new System.EventHandler(this.tim_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // timeLBL
            // 
            this.timeLBL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeLBL.Font = new System.Drawing.Font("Segoe UI Semibold", 23.75F, System.Drawing.FontStyle.Bold);
            this.timeLBL.ForeColor = System.Drawing.Color.Black;
            this.timeLBL.Location = new System.Drawing.Point(16, 9);
            this.timeLBL.Name = "timeLBL";
            this.timeLBL.Size = new System.Drawing.Size(412, 106);
            this.timeLBL.TabIndex = 3;
            this.timeLBL.Text = "time";
            this.timeLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.widgetıKapatToolStripMenuItem,
            this.ayarlarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 48);
            // 
            // widgetıKapatToolStripMenuItem
            // 
            this.widgetıKapatToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.widgetıKapatToolStripMenuItem.Name = "widgetıKapatToolStripMenuItem";
            this.widgetıKapatToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.widgetıKapatToolStripMenuItem.Text = "Widget\'ı Kapat";
            this.widgetıKapatToolStripMenuItem.Click += new System.EventHandler(this.widgetıKapatToolStripMenuItem_Click);
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            this.ayarlarToolStripMenuItem.Click += new System.EventHandler(this.ayarlarToolStripMenuItem_Click);
            // 
            // Hour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 152);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.date);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.timeLBL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Hour";
            this.Text = "Hour";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hour_FormClosing);
            this.Load += new System.EventHandler(this.Hour_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hour_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Hour_MouseMove);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label date;
        public System.Windows.Forms.Timer tim;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label timeLBL;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem widgetıKapatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
    }
}