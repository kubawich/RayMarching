namespace RayMarching
{
    partial class Form1
    {

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sandbox = new RayMarching.Algorithm_Sandbox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // sandbox
            // 
            this.sandbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sandbox.BackColor = System.Drawing.Color.DarkGray;
            this.sandbox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sandbox.Location = new System.Drawing.Point(0, 0);
            this.sandbox.Name = "sandbox";
            this.sandbox.RayAngle = 0F;
            this.sandbox.RayPos = ((System.Drawing.PointF)(resources.GetObject("sandbox.RayPos")));
            this.sandbox.Size = new System.Drawing.Size(300, 300);
            this.sandbox.TabIndex = 2;
            // 
            // trackBar
            // 
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar.LargeChange = 1;
            this.trackBar.Location = new System.Drawing.Point(0, 255);
            this.trackBar.Maximum = 360;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(300, 45);
            this.trackBar.TabIndex = 1;
            this.trackBar.Scroll += new System.EventHandler(this.MoveRayOnScroll);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.sandbox);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ray Marching";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private Algorithm_Sandbox sandbox;
    }
}

