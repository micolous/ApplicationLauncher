namespace ApplicationLauncher
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MessageToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShortcutsListView = new System.Windows.Forms.ListView();
            this.ShortcutContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IconList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ProgramDescriptionRTB = new System.Windows.Forms.RichTextBox();
            this.TimeTimer = new System.Windows.Forms.Timer(this.components);
            this.BannerPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.ShortcutContextMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BannerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.appToolStripMenuItem,
            this.MessageToolStrip,
            this.TimeToolStripItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closeToolStripMenuItem.Font = new System.Drawing.Font("Marlett", 8F);
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.ShowShortcutKeys = false;
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.closeToolStripMenuItem.Text = "r";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // appToolStripMenuItem
            // 
            this.appToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appToolStripMenuItem.Name = "appToolStripMenuItem";
            this.appToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.appToolStripMenuItem.Text = "Application Launcher";
            this.appToolStripMenuItem.DropDownOpening += new System.EventHandler(this.appToolStripMenuItem_DropDownOpening);
            this.appToolStripMenuItem.MouseLeave += new System.EventHandler(this.appToolStripMenuItem_MouseLeave);
            this.appToolStripMenuItem.MouseEnter += new System.EventHandler(this.appToolStripMenuItem_MouseEnter);
            // 
            // MessageToolStrip
            // 
            this.MessageToolStrip.Name = "MessageToolStrip";
            this.MessageToolStrip.Size = new System.Drawing.Size(12, 20);
            this.MessageToolStrip.Visible = false;
            this.MessageToolStrip.DropDownOpening += new System.EventHandler(this.MessageToolStrip_DropDownOpening);
            this.MessageToolStrip.TextChanged += new System.EventHandler(this.MessageToolStrip_TextChanged);
            // 
            // TimeToolStripItem
            // 
            this.TimeToolStripItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TimeToolStripItem.Name = "TimeToolStripItem";
            this.TimeToolStripItem.Size = new System.Drawing.Size(96, 20);
            this.TimeToolStripItem.Text = "CURRENT TIME";
            this.TimeToolStripItem.DropDownOpening += new System.EventHandler(this.TimeToolStripItem_DropDownOpening);
            // 
            // ShortcutsListView
            // 
            this.ShortcutsListView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.ShortcutsListView.ContextMenuStrip = this.ShortcutContextMenu;
            this.ShortcutsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShortcutsListView.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShortcutsListView.HoverSelection = true;
            this.ShortcutsListView.LargeImageList = this.IconList;
            this.ShortcutsListView.Location = new System.Drawing.Point(0, 0);
            this.ShortcutsListView.MultiSelect = false;
            this.ShortcutsListView.Name = "ShortcutsListView";
            this.ShortcutsListView.Size = new System.Drawing.Size(580, 427);
            this.ShortcutsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ShortcutsListView.TabIndex = 0;
            this.ShortcutsListView.UseCompatibleStateImageBehavior = false;
            this.ShortcutsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ShortcutsListView_MouseDoubleClick);
            this.ShortcutsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ShortcutsListView_ItemSelectionChanged);
            this.ShortcutsListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ShortcutsListView_KeyPress);
            // 
            // ShortcutContextMenu
            // 
            this.ShortcutContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openApplicationToolStripMenuItem});
            this.ShortcutContextMenu.Name = "ShortcutContextMenu";
            this.ShortcutContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ShortcutContextMenu.ShowImageMargin = false;
            this.ShortcutContextMenu.Size = new System.Drawing.Size(72, 26);
            this.ShortcutContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ShortcutContextMenu_Opening);
            // 
            // openApplicationToolStripMenuItem
            // 
            this.openApplicationToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.openApplicationToolStripMenuItem.Name = "openApplicationToolStripMenuItem";
            this.openApplicationToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.openApplicationToolStripMenuItem.Text = "Run";
            this.openApplicationToolStripMenuItem.Click += new System.EventHandler(this.openApplicationToolStripMenuItem_Click);
            // 
            // IconList
            // 
            this.IconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IconList.ImageSize = new System.Drawing.Size(32, 32);
            this.IconList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(12, 161);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ShortcutsListView);
            this.splitContainer1.Panel1MinSize = 400;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ProgramDescriptionRTB);
            this.splitContainer1.Size = new System.Drawing.Size(776, 427);
            this.splitContainer1.SplitterDistance = 580;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            // 
            // ProgramDescriptionRTB
            // 
            this.ProgramDescriptionRTB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ProgramDescriptionRTB.DetectUrls = false;
            this.ProgramDescriptionRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgramDescriptionRTB.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramDescriptionRTB.Location = new System.Drawing.Point(0, 0);
            this.ProgramDescriptionRTB.Name = "ProgramDescriptionRTB";
            this.ProgramDescriptionRTB.ReadOnly = true;
            this.ProgramDescriptionRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ProgramDescriptionRTB.ShortcutsEnabled = false;
            this.ProgramDescriptionRTB.Size = new System.Drawing.Size(192, 427);
            this.ProgramDescriptionRTB.TabIndex = 1;
            this.ProgramDescriptionRTB.TabStop = false;
            this.ProgramDescriptionRTB.Text = "";
            this.ProgramDescriptionRTB.Enter += new System.EventHandler(this.ProgramDescriptionRTB_Enter);
            // 
            // TimeTimer
            // 
            this.TimeTimer.Enabled = true;
            this.TimeTimer.Interval = 5000;
            this.TimeTimer.Tick += new System.EventHandler(this.TimeTimer_Tick);
            // 
            // BannerPictureBox
            // 
            this.BannerPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BannerPictureBox.Location = new System.Drawing.Point(12, 27);
            this.BannerPictureBox.Name = "BannerPictureBox";
            this.BannerPictureBox.Size = new System.Drawing.Size(776, 128);
            this.BannerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BannerPictureBox.TabIndex = 1;
            this.BannerPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.BannerPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Launcher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ShortcutContextMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BannerPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appToolStripMenuItem;
        private System.Windows.Forms.PictureBox BannerPictureBox;
        private System.Windows.Forms.ListView ShortcutsListView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox ProgramDescriptionRTB;
        private System.Windows.Forms.ImageList IconList;
        private System.Windows.Forms.ContextMenuStrip ShortcutContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MessageToolStrip;
        private System.Windows.Forms.ToolStripMenuItem TimeToolStripItem;
        private System.Windows.Forms.Timer TimeTimer;

    }
}

