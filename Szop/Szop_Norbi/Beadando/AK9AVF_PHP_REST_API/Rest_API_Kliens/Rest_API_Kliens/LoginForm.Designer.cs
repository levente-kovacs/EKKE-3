namespace Rest_API_Kliens
{
    partial class LoginForm
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
            this.exit = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.labelforUsername = new System.Windows.Forms.Label();
            this.labelforpassword = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.pwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exit.Location = new System.Drawing.Point(454, 224);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(145, 30);
            this.exit.TabIndex = 7;
            this.exit.Text = "Kilépés";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.login.Location = new System.Drawing.Point(51, 224);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(143, 30);
            this.login.TabIndex = 10;
            this.login.Text = "Bejelentkezés";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // labelforUsername
            // 
            this.labelforUsername.AutoSize = true;
            this.labelforUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelforUsername.Location = new System.Drawing.Point(60, 97);
            this.labelforUsername.Name = "labelforUsername";
            this.labelforUsername.Size = new System.Drawing.Size(157, 24);
            this.labelforUsername.TabIndex = 13;
            this.labelforUsername.Text = "Felhasználónév";
            // 
            // labelforpassword
            // 
            this.labelforpassword.AutoSize = true;
            this.labelforpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelforpassword.Location = new System.Drawing.Point(148, 140);
            this.labelforpassword.Name = "labelforpassword";
            this.labelforpassword.Size = new System.Drawing.Size(69, 24);
            this.labelforpassword.TabIndex = 14;
            this.labelforpassword.Text = "Jelszó";
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(296, 97);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(303, 20);
            this.user.TabIndex = 15;
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(296, 140);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(303, 20);
            this.pwd.TabIndex = 16;
            this.pwd.UseSystemPasswordChar = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 295);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.user);
            this.Controls.Add(this.labelforpassword);
            this.Controls.Add(this.labelforUsername);
            this.Controls.Add(this.login);
            this.Controls.Add(this.exit);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label labelforUsername;
        private System.Windows.Forms.Label labelforpassword;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox pwd;
    }
}

