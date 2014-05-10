namespace makit.TheCoconutCraniumDecisionEngine.Initiator
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.TheLoginButton = new System.Windows.Forms.Button();
            this.ThePasswordLabel = new System.Windows.Forms.Label();
            this.TheNameOfTheUserLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(126, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 24);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(126, 137);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(192, 24);
            this.textBox2.TabIndex = 1;
            // 
            // TheLoginButton
            // 
            this.TheLoginButton.Location = new System.Drawing.Point(243, 175);
            this.TheLoginButton.Name = "TheLoginButton";
            this.TheLoginButton.Size = new System.Drawing.Size(75, 26);
            this.TheLoginButton.TabIndex = 2;
            this.TheLoginButton.Text = "Login";
            this.TheLoginButton.UseVisualStyleBackColor = true;
            this.TheLoginButton.Click += new System.EventHandler(this.TheLoginButton_Click);
            // 
            // ThePasswordLabel
            // 
            this.ThePasswordLabel.AutoSize = true;
            this.ThePasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThePasswordLabel.Location = new System.Drawing.Point(49, 142);
            this.ThePasswordLabel.Name = "ThePasswordLabel";
            this.ThePasswordLabel.Size = new System.Drawing.Size(61, 15);
            this.ThePasswordLabel.TabIndex = 3;
            this.ThePasswordLabel.Text = "Password";
            // 
            // TheNameOfTheUserLabel
            // 
            this.TheNameOfTheUserLabel.AutoSize = true;
            this.TheNameOfTheUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheNameOfTheUserLabel.Location = new System.Drawing.Point(45, 104);
            this.TheNameOfTheUserLabel.Name = "TheNameOfTheUserLabel";
            this.TheNameOfTheUserLabel.Size = new System.Drawing.Size(65, 15);
            this.TheNameOfTheUserLabel.TabIndex = 4;
            this.TheNameOfTheUserLabel.Text = "Username";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 75);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form3
            // 
            this.AcceptButton = this.TheLoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 213);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TheNameOfTheUserLabel);
            this.Controls.Add(this.ThePasswordLabel);
            this.Controls.Add(this.TheLoginButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Coconut Cranium Decision Engine";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button TheLoginButton;
        private System.Windows.Forms.Label ThePasswordLabel;
        private System.Windows.Forms.Label TheNameOfTheUserLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}