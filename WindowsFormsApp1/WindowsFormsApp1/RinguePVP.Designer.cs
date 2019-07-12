namespace WindowsFormsApp1
{
    partial class RinguePVP
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
            this.Pronto = new System.Windows.Forms.Button();
            this.IpTextBox = new System.Windows.Forms.TextBox();
            this.mouse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouse)).BeginInit();
            this.SuspendLayout();
            // 
            // suaVida
            // 
            this.suaVida.AutoSize = true;
            this.suaVida.BackColor = System.Drawing.Color.Transparent;
            this.suaVida.Location = new System.Drawing.Point(55, 44);
            this.suaVida.Name = "suaVida";
            this.suaVida.Size = new System.Drawing.Size(27, 13);
            this.suaVida.TabIndex = 0;
            this.suaVida.Text = "vida";
            // 
            // VidaEnemy
            // 
            this.VidaEnemy.AutoSize = true;
            this.VidaEnemy.BackColor = System.Drawing.Color.Transparent;
            this.VidaEnemy.Location = new System.Drawing.Point(635, 49);
            this.VidaEnemy.Name = "VidaEnemy";
            this.VidaEnemy.Size = new System.Drawing.Size(59, 13);
            this.VidaEnemy.TabIndex = 1;
            this.VidaEnemy.Text = "vidaEnemy";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.boneco2;
            this.pictureBox1.Location = new System.Drawing.Point(58, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 181);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ATKButton
            // 
            this.ATKButton.Enabled = false;
            this.ATKButton.Location = new System.Drawing.Point(58, 338);
            this.ATKButton.Name = "ATKButton";
            this.ATKButton.Size = new System.Drawing.Size(75, 23);
            this.ATKButton.TabIndex = 4;
            this.ATKButton.Text = "ATK";
            this.ATKButton.UseVisualStyleBackColor = true;
            this.ATKButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SkillButton
            // 
            this.SkillButton.Enabled = false;
            this.SkillButton.Location = new System.Drawing.Point(168, 338);
            this.SkillButton.Name = "SkillButton";
            this.SkillButton.Size = new System.Drawing.Size(75, 23);
            this.SkillButton.TabIndex = 5;
            this.SkillButton.Text = "SKILL";
            this.SkillButton.UseVisualStyleBackColor = true;
            this.SkillButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // FugirButton
            // 
            this.FugirButton.Enabled = false;
            this.FugirButton.Location = new System.Drawing.Point(168, 380);
            this.FugirButton.Name = "FugirButton";
            this.FugirButton.Size = new System.Drawing.Size(75, 23);
            this.FugirButton.TabIndex = 6;
            this.FugirButton.Text = "FUGIR";
            this.FugirButton.UseVisualStyleBackColor = true;
            this.FugirButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // ItemButton
            // 
            this.ItemButton.Enabled = false;
            this.ItemButton.Location = new System.Drawing.Point(58, 380);
            this.ItemButton.Name = "ItemButton";
            this.ItemButton.Size = new System.Drawing.Size(75, 23);
            this.ItemButton.TabIndex = 7;
            this.ItemButton.Text = "ITEM";
            this.ItemButton.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(358, 39);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Buscar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.BackColor = System.Drawing.Color.Transparent;
            this.Status.Location = new System.Drawing.Point(355, 85);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(35, 13);
            this.Status.TabIndex = 10;
            this.Status.Text = "label3";
            // 
            // ImageEnemy
            // 
            this.ImageEnemy.BackColor = System.Drawing.Color.Transparent;
            this.ImageEnemy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImageEnemy.Image = global::WindowsFormsApp1.Properties.Resources.boneco2;
            this.ImageEnemy.Location = new System.Drawing.Point(594, 85);
            this.ImageEnemy.Name = "ImageEnemy";
            this.ImageEnemy.Size = new System.Drawing.Size(96, 181);
            this.ImageEnemy.TabIndex = 11;
            this.ImageEnemy.TabStop = false;
            this.ImageEnemy.Visible = false;
            // 
            // NameEnemy
            // 
            this.NameEnemy.AutoSize = true;
            this.NameEnemy.BackColor = System.Drawing.Color.Transparent;
            this.NameEnemy.Location = new System.Drawing.Point(605, 269);
            this.NameEnemy.Name = "NameEnemy";
            this.NameEnemy.Size = new System.Drawing.Size(67, 13);
            this.NameEnemy.TabIndex = 12;
            this.NameEnemy.Text = "NomeEnemy";
            // 
            // Lvl
            // 
            this.Lvl.AutoSize = true;
            this.Lvl.BackColor = System.Drawing.Color.Transparent;
            this.Lvl.Location = new System.Drawing.Point(594, 48);
            this.Lvl.Name = "Lvl";
            this.Lvl.Size = new System.Drawing.Size(35, 13);
            this.Lvl.TabIndex = 13;
            this.Lvl.Text = "label2";
            // 
            // Pronto
            // 
            this.Pronto.Location = new System.Drawing.Point(358, 182);
            this.Pronto.Name = "Pronto";
            this.Pronto.Size = new System.Drawing.Size(75, 23);
            this.Pronto.TabIndex = 14;
            this.Pronto.Text = "Pronto";
            this.Pronto.UseVisualStyleBackColor = true;
            this.Pronto.Click += new System.EventHandler(this.prontoButton);
            // 
            // IpTextBox
            // 
            this.IpTextBox.Location = new System.Drawing.Point(333, 156);
            this.IpTextBox.Name = "IpTextBox";
            this.IpTextBox.Size = new System.Drawing.Size(100, 20);
            this.IpTextBox.TabIndex = 15;
            this.IpTextBox.Text = "IpAddress";
            // 
            // mouse
            // 
            this.mouse.BackColor = System.Drawing.Color.Transparent;
            this.mouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mouse.Image = global::WindowsFormsApp1.Properties.Resources.curso;
            this.mouse.ImageLocation = "";
            this.mouse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mouse.Location = new System.Drawing.Point(371, 226);
            this.mouse.Name = "mouse";
            this.mouse.Size = new System.Drawing.Size(19, 21);
            this.mouse.TabIndex = 17;
            this.mouse.TabStop = false;
            // 
            // RinguePVP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.grace_liu_bc_bg_arena;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mouse);
            this.Controls.Add(this.IpTextBox);
            this.Controls.Add(this.Pronto);
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
            this.Name = "RinguePVP";
            this.Text = "Ringue";
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
        private System.Windows.Forms.Button Pronto;
        private System.Windows.Forms.TextBox IpTextBox;
        private System.Windows.Forms.PictureBox mouse;
    }
}