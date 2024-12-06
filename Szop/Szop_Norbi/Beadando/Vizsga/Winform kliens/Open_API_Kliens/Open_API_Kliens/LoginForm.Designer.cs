namespace Open_API_Kliens
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
            this.labelForUsername = new System.Windows.Forms.Label();
            this.labelForPassword = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.pwd = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelForUsername
            // 
            this.labelForUsername.AutoSize = true;
            this.labelForUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelForUsername.Location = new System.Drawing.Point(149, 71);
            this.labelForUsername.Name = "labelForUsername";
            this.labelForUsername.Size = new System.Drawing.Size(157, 24);
            this.labelForUsername.TabIndex = 0;
            this.labelForUsername.Text = "Felhasználónév";
            // 
            // labelForPassword
            // 
            this.labelForPassword.AutoSize = true;
            this.labelForPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelForPassword.Location = new System.Drawing.Point(237, 126);
            this.labelForPassword.Name = "labelForPassword";
            this.labelForPassword.Size = new System.Drawing.Size(69, 24);
            this.labelForPassword.TabIndex = 1;
            this.labelForPassword.Text = "Jelszó";
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(323, 76);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(330, 20);
            this.user.TabIndex = 2;
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(323, 131);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(330, 20);
            this.pwd.TabIndex = 3;
            this.pwd.UseSystemPasswordChar = true;
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.login.Location = new System.Drawing.Point(153, 215);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(153, 35);
            this.login.TabIndex = 4;
            this.login.Text = "Bejelentkezés";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exit.Location = new System.Drawing.Point(526, 215);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(127, 35);
            this.exit.TabIndex = 5;
            this.exit.Text = "Kilépés";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 320);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.login);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.user);
            this.Controls.Add(this.labelForPassword);
            this.Controls.Add(this.labelForUsername);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelForUsername;
        private System.Windows.Forms.Label labelForPassword;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button exit;
    }
}

