namespace QuizGameSimple
{
    partial class Main
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
            this.dragPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Closepb = new System.Windows.Forms.PictureBox();
            this.MinimizePb = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddPlayerPanel = new System.Windows.Forms.Panel();
            this.AddPlayerPb = new System.Windows.Forms.PictureBox();
            this.CreateQuizPb = new System.Windows.Forms.PictureBox();
            this.PlayQuizPb = new System.Windows.Forms.PictureBox();
            this.PlayersLv = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerTb = new System.Windows.Forms.TextBox();
            this.CreatePb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Closepb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizePb)).BeginInit();
            this.panel1.SuspendLayout();
            this.AddPlayerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddPlayerPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateQuizPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayQuizPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatePb)).BeginInit();
            this.SuspendLayout();
            // 
            // dragPanel
            // 
            this.dragPanel.BackColor = System.Drawing.Color.Transparent;
            this.dragPanel.BackgroundImage = global::QuizGameSimple.Properties.Resources.bg_light;
            this.dragPanel.Location = new System.Drawing.Point(0, 0);
            this.dragPanel.Name = "dragPanel";
            this.dragPanel.Size = new System.Drawing.Size(801, 23);
            this.dragPanel.TabIndex = 0;
            this.dragPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseMove);
            // 
            // Closepb
            // 
            this.Closepb.BackColor = System.Drawing.Color.Transparent;
            this.Closepb.Image = global::QuizGameSimple.Properties.Resources.Close;
            this.Closepb.Location = new System.Drawing.Point(756, 0);
            this.Closepb.Name = "Closepb";
            this.Closepb.Size = new System.Drawing.Size(45, 23);
            this.Closepb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Closepb.TabIndex = 1;
            this.Closepb.TabStop = false;
            this.Closepb.Click += new System.EventHandler(this.Close_Click);
            // 
            // MinimizePb
            // 
            this.MinimizePb.BackColor = System.Drawing.Color.Transparent;
            this.MinimizePb.Image = global::QuizGameSimple.Properties.Resources.Minimize;
            this.MinimizePb.Location = new System.Drawing.Point(711, 0);
            this.MinimizePb.Name = "MinimizePb";
            this.MinimizePb.Size = new System.Drawing.Size(45, 23);
            this.MinimizePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MinimizePb.TabIndex = 2;
            this.MinimizePb.TabStop = false;
            this.MinimizePb.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::QuizGameSimple.Properties.Resources.bg_dark;
            this.panel1.Controls.Add(this.AddPlayerPanel);
            this.panel1.Controls.Add(this.AddPlayerPb);
            this.panel1.Controls.Add(this.CreateQuizPb);
            this.panel1.Controls.Add(this.PlayQuizPb);
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 429);
            this.panel1.TabIndex = 3;
            // 
            // AddPlayerPanel
            // 
            this.AddPlayerPanel.BackColor = System.Drawing.Color.Transparent;
            this.AddPlayerPanel.BackgroundImage = global::QuizGameSimple.Properties.Resources.bg_dark;
            this.AddPlayerPanel.Controls.Add(this.CreatePb);
            this.AddPlayerPanel.Controls.Add(this.PlayerTb);
            this.AddPlayerPanel.Controls.Add(this.label1);
            this.AddPlayerPanel.Controls.Add(this.PlayersLv);
            this.AddPlayerPanel.Location = new System.Drawing.Point(0, 1);
            this.AddPlayerPanel.Name = "AddPlayerPanel";
            this.AddPlayerPanel.Size = new System.Drawing.Size(801, 429);
            this.AddPlayerPanel.TabIndex = 4;
            this.AddPlayerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AddPlayerPanel_Paint);
            // 
            // AddPlayerPb
            // 
            this.AddPlayerPb.Image = global::QuizGameSimple.Properties.Resources.Add_Player;
            this.AddPlayerPb.Location = new System.Drawing.Point(443, 307);
            this.AddPlayerPb.Name = "AddPlayerPb";
            this.AddPlayerPb.Size = new System.Drawing.Size(145, 77);
            this.AddPlayerPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AddPlayerPb.TabIndex = 2;
            this.AddPlayerPb.TabStop = false;
            this.AddPlayerPb.Click += new System.EventHandler(this.AddPlayerPb_Click);
            // 
            // CreateQuizPb
            // 
            this.CreateQuizPb.Image = global::QuizGameSimple.Properties.Resources.CreateQuiz;
            this.CreateQuizPb.Location = new System.Drawing.Point(228, 307);
            this.CreateQuizPb.Name = "CreateQuizPb";
            this.CreateQuizPb.Size = new System.Drawing.Size(145, 77);
            this.CreateQuizPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CreateQuizPb.TabIndex = 1;
            this.CreateQuizPb.TabStop = false;
            this.CreateQuizPb.Click += new System.EventHandler(this.CreateQuizPb_Click);
            // 
            // PlayQuizPb
            // 
            this.PlayQuizPb.Image = global::QuizGameSimple.Properties.Resources.Play;
            this.PlayQuizPb.Location = new System.Drawing.Point(301, 139);
            this.PlayQuizPb.Name = "PlayQuizPb";
            this.PlayQuizPb.Size = new System.Drawing.Size(210, 109);
            this.PlayQuizPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayQuizPb.TabIndex = 0;
            this.PlayQuizPb.TabStop = false;
            this.PlayQuizPb.Click += new System.EventHandler(this.PlayQuizPb_Click);
            // 
            // PlayersLv
            // 
            this.PlayersLv.Location = new System.Drawing.Point(491, 54);
            this.PlayersLv.Name = "PlayersLv";
            this.PlayersLv.Size = new System.Drawing.Size(265, 348);
            this.PlayersLv.TabIndex = 0;
            this.PlayersLv.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(487, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Existing Players";
            // 
            // PlayerTb
            // 
            this.PlayerTb.Location = new System.Drawing.Point(37, 136);
            this.PlayerTb.Multiline = true;
            this.PlayerTb.Name = "PlayerTb";
            this.PlayerTb.Size = new System.Drawing.Size(377, 48);
            this.PlayerTb.TabIndex = 2;
            // 
            // CreatePb
            // 
            this.CreatePb.Image = global::QuizGameSimple.Properties.Resources.Create;
            this.CreatePb.Location = new System.Drawing.Point(325, 190);
            this.CreatePb.Name = "CreatePb";
            this.CreatePb.Size = new System.Drawing.Size(96, 55);
            this.CreatePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CreatePb.TabIndex = 3;
            this.CreatePb.TabStop = false;
            this.CreatePb.Click += new System.EventHandler(this.CreatePb_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MinimizePb);
            this.Controls.Add(this.Closepb);
            this.Controls.Add(this.dragPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuizGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Closepb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizePb)).EndInit();
            this.panel1.ResumeLayout(false);
            this.AddPlayerPanel.ResumeLayout(false);
            this.AddPlayerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddPlayerPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateQuizPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayQuizPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatePb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel dragPanel;
        private PictureBox Closepb;
        private PictureBox MinimizePb;
        private Panel panel1;
        private PictureBox AddPlayerPb;
        private PictureBox CreateQuizPb;
        private PictureBox PlayQuizPb;
        private Panel AddPlayerPanel;
        private PictureBox CreatePb;
        private TextBox PlayerTb;
        private Label label1;
        private ListView PlayersLv;
    }
}