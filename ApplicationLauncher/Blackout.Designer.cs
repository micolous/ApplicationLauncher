namespace ApplicationLauncher
{
    partial class Blackout
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
            this.BlackoutTicker = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ForceQuitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BlackoutTicker
            // 
            this.BlackoutTicker.Enabled = true;
            this.BlackoutTicker.Interval = 1000;
            this.BlackoutTicker.Tick += new System.EventHandler(this.BlackoutTicker_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(590, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "An application is already running.  You must close it before you can return to th" +
                "e application launcher.\r\n\r\nPress Alt-TAB to switch back to it.\r\n\r\nIf you believe" +
                " it has crashed, press Force Quit.";
            // 
            // ForceQuitButton
            // 
            this.ForceQuitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ForceQuitButton.BackColor = System.Drawing.Color.DimGray;
            this.ForceQuitButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForceQuitButton.ForeColor = System.Drawing.Color.White;
            this.ForceQuitButton.Location = new System.Drawing.Point(690, 31);
            this.ForceQuitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ForceQuitButton.Name = "ForceQuitButton";
            this.ForceQuitButton.Size = new System.Drawing.Size(98, 35);
            this.ForceQuitButton.TabIndex = 1;
            this.ForceQuitButton.Text = "Force Quit";
            this.ForceQuitButton.UseVisualStyleBackColor = false;
            this.ForceQuitButton.Click += new System.EventHandler(this.ForceQuitButton_Click);
            // 
            // Blackout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.ForceQuitButton);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Blackout";
            this.Opacity = 0.8;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Blackout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ForceQuitButton;
        private System.Windows.Forms.Timer BlackoutTicker;


    }
}