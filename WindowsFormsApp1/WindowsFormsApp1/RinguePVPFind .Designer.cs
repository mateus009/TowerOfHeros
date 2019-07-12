namespace WindowsFormsApp1
{
    partial class RinguePVPFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RinguePVPFind));
            this.suaVida = new System.Windows.Forms.Label();
            this.VidaEnemy = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ATKButton = new System.Windows.Forms.Button();
            this.SkillButton = new System.Windows.Forms.Button();
            this.FugirButton = new System.Windows.Forms.Button();
            this.ItemButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.ImageEnemy = new System.Windows.Forms.PictureBox();
            this.NameEnemy = new System.Windows.Forms.Label();
            this.Lvl = new System.Windows.Forms.Label();
            this.ProntoButton = new System.Windows.Forms.Button();
            this.mouse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouse)).BeginInit();
            this.SuspendLayout();
            // 
            // suaVida
            // 
            resources.ApplyResources(this.suaVida, "suaVida");
            this.suaVida.BackColor = System.Drawing.Color.Transparent;
            this.suaVida.Name = "suaVida";
            // 
            // VidaEnemy
            // 
            resources.ApplyResources(this.VidaEnemy, "VidaEnemy");
            this.VidaEnemy.BackColor = System.Drawing.Color.Transparent;
            this.VidaEnemy.Name = "VidaEnemy";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // ATKButton
            // 
            resources.ApplyResources(this.ATKButton, "ATKButton");
            this.ATKButton.Name = "ATKButton";
            this.ATKButton.UseVisualStyleBackColor = true;
            this.ATKButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SkillButton
            // 
            resources.ApplyResources(this.SkillButton, "SkillButton");
            this.SkillButton.Name = "SkillButton";
            this.SkillButton.UseVisualStyleBackColor = true;
            this.SkillButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // FugirButton
            // 
            resources.ApplyResources(this.FugirButton, "FugirButton");
            this.FugirButton.Name = "FugirButton";
            this.FugirButton.UseVisualStyleBackColor = true;
            this.FugirButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // ItemButton
            // 
            resources.ApplyResources(this.ItemButton, "ItemButton");
            this.ItemButton.Name = "ItemButton";
            this.ItemButton.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Status
            // 
            resources.ApplyResources(this.Status, "Status");
            this.Status.BackColor = System.Drawing.Color.Transparent;
            this.Status.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Status.Name = "Status";
            // 
            // ImageEnemy
            // 
            this.ImageEnemy.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.ImageEnemy, "ImageEnemy");
            this.ImageEnemy.Name = "ImageEnemy";
            this.ImageEnemy.TabStop = false;
            // 
            // NameEnemy
            // 
            resources.ApplyResources(this.NameEnemy, "NameEnemy");
            this.NameEnemy.BackColor = System.Drawing.Color.Transparent;
            this.NameEnemy.Name = "NameEnemy";
            // 
            // Lvl
            // 
            resources.ApplyResources(this.Lvl, "Lvl");
            this.Lvl.BackColor = System.Drawing.Color.Transparent;
            this.Lvl.Name = "Lvl";
            // 
            // ProntoButton
            // 
            resources.ApplyResources(this.ProntoButton, "ProntoButton");
            this.ProntoButton.Name = "ProntoButton";
            this.ProntoButton.UseVisualStyleBackColor = true;
            this.ProntoButton.Click += new System.EventHandler(this.prontoButton);
            // 
            // mouse
            // 
            this.mouse.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.mouse, "mouse");
            this.mouse.Name = "mouse";
            this.mouse.TabStop = false;
            this.mouse.UseWaitCursor = true;
            // 
            // RinguePVPFind
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mouse);
            this.Controls.Add(this.ProntoButton);
            this.Controls.Add(this.Lvl);
            this.Controls.Add(this.NameEnemy);
            this.Controls.Add(this.ImageEnemy);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.ItemButton);
            this.Controls.Add(this.FugirButton);
            this.Controls.Add(this.SkillButton);
            this.Controls.Add(this.ATKButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.VidaEnemy);
            this.Controls.Add(this.suaVida);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RinguePVPFind";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label suaVida;
        private System.Windows.Forms.Label VidaEnemy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ATKButton;
        private System.Windows.Forms.Button SkillButton;
        private System.Windows.Forms.Button FugirButton;
        private System.Windows.Forms.Button ItemButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.PictureBox ImageEnemy;
        private System.Windows.Forms.Label NameEnemy;
        private System.Windows.Forms.Label Lvl;
        private System.Windows.Forms.Button ProntoButton;
        private System.Windows.Forms.PictureBox mouse;
    }

}