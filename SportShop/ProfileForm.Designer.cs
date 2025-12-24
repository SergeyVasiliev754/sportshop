namespace SportShop.Forms
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblBonus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblBonus = new System.Windows.Forms.Label();
            this.btnChangePhone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(20, 20);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(300, 25);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "ФИО: ";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(20, 60);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(300, 25);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email: ";
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(20, 100);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(300, 25);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Телефон: ";
            // 
            // lblBonus
            // 
            this.lblBonus.Location = new System.Drawing.Point(20, 140);
            this.lblBonus.Name = "lblBonus";
            this.lblBonus.Size = new System.Drawing.Size(300, 25);
            this.lblBonus.TabIndex = 3;
            this.lblBonus.Text = "Бонусы: 0";
            // 
            // btnChangePhone
            // 
            this.btnChangePhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnChangePhone.Location = new System.Drawing.Point(20, 180);
            this.btnChangePhone.Name = "btnChangePhone";
            this.btnChangePhone.Size = new System.Drawing.Size(150, 30);
            this.btnChangePhone.TabIndex = 4;
            this.btnChangePhone.Text = "Сменить номер";
            this.btnChangePhone.UseVisualStyleBackColor = false;
            // 
            // ProfileForm
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(350, 230);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblBonus);
            this.Controls.Add(this.btnChangePhone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Профиль";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnChangePhone;
    }
}
