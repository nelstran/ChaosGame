namespace ChaosGame
{
    partial class gameWindow
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
            this.playerButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.counterLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.dotTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerButton
            // 
            this.playerButton.Enabled = false;
            this.playerButton.Location = new System.Drawing.Point(180, 163);
            this.playerButton.Name = "playerButton";
            this.playerButton.Size = new System.Drawing.Size(99, 48);
            this.playerButton.TabIndex = 0;
            this.playerButton.Text = "Play/Pause";
            this.playerButton.UseVisualStyleBackColor = true;
            this.playerButton.Click += new System.EventHandler(this.playerButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(55, 163);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(99, 48);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear graphics";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Enabled = false;
            this.nextButton.Location = new System.Drawing.Point(114, 229);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(99, 48);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // speedBar
            // 
            this.speedBar.Location = new System.Drawing.Point(43, 305);
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(266, 45);
            this.speedBar.TabIndex = 3;
            this.speedBar.Scroll += new System.EventHandler(this.speedBar_Scroll);
            // 
            // counterLabel
            // 
            this.counterLabel.AutoSize = true;
            this.counterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterLabel.Location = new System.Drawing.Point(111, 129);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(114, 20);
            this.counterLabel.TabIndex = 4;
            this.counterLabel.Text = "Iterations : N/A";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedLabel.Location = new System.Drawing.Point(114, 363);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(94, 20);
            this.speedLabel.TabIndex = 5;
            this.speedLabel.Text = "Speed : N/A";
            // 
            // infoLabel
            // 
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(0, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(297, 114);
            this.infoLabel.TabIndex = 6;
            this.infoLabel.Text = "N/A";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dotTimer
            // 
            this.dotTimer.Tick += new System.EventHandler(this.dotTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.infoLabel);
            this.panel1.Location = new System.Drawing.Point(23, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 114);
            this.panel1.TabIndex = 7;
            // 
            // gameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.counterLabel);
            this.Controls.Add(this.speedBar);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.playerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "gameWindow";
            this.Text = "Chaos Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.gameWindow_FormClosed);
            this.Load += new System.EventHandler(this.gameWindow_Load);
            this.Shown += new System.EventHandler(this.gameWindow_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.gameWindow_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameWindow_MouseClick);
            this.MouseLeave += new System.EventHandler(this.gameWindow_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gameWindow_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playerButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.Label counterLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Timer dotTimer;
        private System.Windows.Forms.Panel panel1;
    }
}

