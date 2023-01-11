namespace SportsAppUI
{
    partial class CreateTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTeamForm));
            this.TeamNameTextBox = new System.Windows.Forms.TextBox();
            this.TeamNameLabel = new System.Windows.Forms.Label();
            this.CreateTeamLabel = new System.Windows.Forms.Label();
            this.AddTeamMemberButton = new System.Windows.Forms.Button();
            this.SelectTeamMemberDropDown = new System.Windows.Forms.ComboBox();
            this.SelectTeamMemberLabel = new System.Windows.Forms.Label();
            this.AddNewMember = new System.Windows.Forms.GroupBox();
            this.CreateMemberButton = new System.Windows.Forms.Button();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.TeamMembersListBox = new System.Windows.Forms.ListBox();
            this.RemoveSelectedMembersButton = new System.Windows.Forms.Button();
            this.CreateTeamtButton = new System.Windows.Forms.Button();
            this.AddNewMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // TeamNameTextBox
            // 
            this.TeamNameTextBox.Location = new System.Drawing.Point(42, 143);
            this.TeamNameTextBox.Name = "TeamNameTextBox";
            this.TeamNameTextBox.Size = new System.Drawing.Size(363, 39);
            this.TeamNameTextBox.TabIndex = 27;
            // 
            // TeamNameLabel
            // 
            this.TeamNameLabel.AutoSize = true;
            this.TeamNameLabel.Location = new System.Drawing.Point(36, 107);
            this.TeamNameLabel.Name = "TeamNameLabel";
            this.TeamNameLabel.Size = new System.Drawing.Size(173, 32);
            this.TeamNameLabel.TabIndex = 26;
            this.TeamNameLabel.Text = "Team Name";
            // 
            // CreateTeamLabel
            // 
            this.CreateTeamLabel.AutoSize = true;
            this.CreateTeamLabel.Font = new System.Drawing.Font("Eras Demi ITC", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTeamLabel.ForeColor = System.Drawing.Color.White;
            this.CreateTeamLabel.Location = new System.Drawing.Point(13, 38);
            this.CreateTeamLabel.Name = "CreateTeamLabel";
            this.CreateTeamLabel.Size = new System.Drawing.Size(239, 43);
            this.CreateTeamLabel.TabIndex = 25;
            this.CreateTeamLabel.Text = "Create Team";
            // 
            // AddTeamMemberButton
            // 
            this.AddTeamMemberButton.ForeColor = System.Drawing.Color.Black;
            this.AddTeamMemberButton.Location = new System.Drawing.Point(107, 302);
            this.AddTeamMemberButton.Name = "AddTeamMemberButton";
            this.AddTeamMemberButton.Size = new System.Drawing.Size(228, 41);
            this.AddTeamMemberButton.TabIndex = 36;
            this.AddTeamMemberButton.Text = "Add Member";
            this.AddTeamMemberButton.UseVisualStyleBackColor = true;
            this.AddTeamMemberButton.Click += new System.EventHandler(this.AddTeamMemberButton_Click);
            // 
            // SelectTeamMemberDropDown
            // 
            this.SelectTeamMemberDropDown.FormattingEnabled = true;
            this.SelectTeamMemberDropDown.Location = new System.Drawing.Point(42, 235);
            this.SelectTeamMemberDropDown.Name = "SelectTeamMemberDropDown";
            this.SelectTeamMemberDropDown.Size = new System.Drawing.Size(363, 39);
            this.SelectTeamMemberDropDown.TabIndex = 35;
            // 
            // SelectTeamMemberLabel
            // 
            this.SelectTeamMemberLabel.AutoSize = true;
            this.SelectTeamMemberLabel.Location = new System.Drawing.Point(36, 200);
            this.SelectTeamMemberLabel.Name = "SelectTeamMemberLabel";
            this.SelectTeamMemberLabel.Size = new System.Drawing.Size(288, 32);
            this.SelectTeamMemberLabel.TabIndex = 34;
            this.SelectTeamMemberLabel.Text = "Select Team Member";
            // 
            // AddNewMember
            // 
            this.AddNewMember.Controls.Add(this.CreateMemberButton);
            this.AddNewMember.Controls.Add(this.PhoneTextBox);
            this.AddNewMember.Controls.Add(this.PhoneLabel);
            this.AddNewMember.Controls.Add(this.EmailTextBox);
            this.AddNewMember.Controls.Add(this.EmailLabel);
            this.AddNewMember.Controls.Add(this.LastNameTextBox);
            this.AddNewMember.Controls.Add(this.LastNameLabel);
            this.AddNewMember.Controls.Add(this.FirstNameTextBox);
            this.AddNewMember.Controls.Add(this.FirstNameLabel);
            this.AddNewMember.Location = new System.Drawing.Point(449, 107);
            this.AddNewMember.Name = "AddNewMember";
            this.AddNewMember.Size = new System.Drawing.Size(363, 298);
            this.AddNewMember.TabIndex = 37;
            this.AddNewMember.TabStop = false;
            this.AddNewMember.Text = "Add New Member";
            // 
            // CreateMemberButton
            // 
            this.CreateMemberButton.ForeColor = System.Drawing.Color.Black;
            this.CreateMemberButton.Location = new System.Drawing.Point(65, 241);
            this.CreateMemberButton.Name = "CreateMemberButton";
            this.CreateMemberButton.Size = new System.Drawing.Size(228, 41);
            this.CreateMemberButton.TabIndex = 38;
            this.CreateMemberButton.Text = "Create Member";
            this.CreateMemberButton.UseVisualStyleBackColor = true;
            this.CreateMemberButton.Click += new System.EventHandler(this.CreateMemberButton_Click);
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(142, 173);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(207, 39);
            this.PhoneTextBox.TabIndex = 32;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Font = new System.Drawing.Font("Eras Demi ITC", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneLabel.Location = new System.Drawing.Point(6, 180);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(83, 26);
            this.PhoneLabel.TabIndex = 31;
            this.PhoneLabel.Text = "Phone";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(142, 128);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(207, 39);
            this.EmailTextBox.TabIndex = 30;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Eras Demi ITC", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(6, 135);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(72, 26);
            this.EmailLabel.TabIndex = 29;
            this.EmailLabel.Text = "Email";
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(142, 83);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(207, 39);
            this.LastNameTextBox.TabIndex = 28;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Font = new System.Drawing.Font("Eras Demi ITC", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLabel.Location = new System.Drawing.Point(6, 90);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(127, 26);
            this.LastNameLabel.TabIndex = 27;
            this.LastNameLabel.Text = "Last Name";
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(142, 38);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(207, 39);
            this.FirstNameTextBox.TabIndex = 26;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Font = new System.Drawing.Font("Eras Demi ITC", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLabel.Location = new System.Drawing.Point(6, 45);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(130, 26);
            this.FirstNameLabel.TabIndex = 25;
            this.FirstNameLabel.Text = "First Name";
            // 
            // TeamMembersListBox
            // 
            this.TeamMembersListBox.FormattingEnabled = true;
            this.TeamMembersListBox.ItemHeight = 31;
            this.TeamMembersListBox.Location = new System.Drawing.Point(42, 373);
            this.TeamMembersListBox.Name = "TeamMembersListBox";
            this.TeamMembersListBox.Size = new System.Drawing.Size(363, 190);
            this.TeamMembersListBox.TabIndex = 38;
            // 
            // RemoveSelectedMembersButton
            // 
            this.RemoveSelectedMembersButton.ForeColor = System.Drawing.Color.Black;
            this.RemoveSelectedMembersButton.Location = new System.Drawing.Point(504, 456);
            this.RemoveSelectedMembersButton.Name = "RemoveSelectedMembersButton";
            this.RemoveSelectedMembersButton.Size = new System.Drawing.Size(248, 41);
            this.RemoveSelectedMembersButton.TabIndex = 39;
            this.RemoveSelectedMembersButton.Text = "Remove Selected";
            this.RemoveSelectedMembersButton.UseVisualStyleBackColor = true;
            this.RemoveSelectedMembersButton.Click += new System.EventHandler(this.RemoveSelectedMembersButton_Click);
            // 
            // CreateTeamtButton
            // 
            this.CreateTeamtButton.Font = new System.Drawing.Font("Eras Demi ITC", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTeamtButton.ForeColor = System.Drawing.Color.Black;
            this.CreateTeamtButton.Location = new System.Drawing.Point(460, 514);
            this.CreateTeamtButton.Name = "CreateTeamtButton";
            this.CreateTeamtButton.Size = new System.Drawing.Size(338, 49);
            this.CreateTeamtButton.TabIndex = 42;
            this.CreateTeamtButton.Text = "Create Team";
            this.CreateTeamtButton.UseVisualStyleBackColor = true;
            this.CreateTeamtButton.Click += new System.EventHandler(this.CreateTeamtButton_Click);
            // 
            // CreateTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(843, 600);
            this.Controls.Add(this.CreateTeamtButton);
            this.Controls.Add(this.RemoveSelectedMembersButton);
            this.Controls.Add(this.TeamMembersListBox);
            this.Controls.Add(this.AddNewMember);
            this.Controls.Add(this.AddTeamMemberButton);
            this.Controls.Add(this.SelectTeamMemberDropDown);
            this.Controls.Add(this.SelectTeamMemberLabel);
            this.Controls.Add(this.TeamNameTextBox);
            this.Controls.Add(this.TeamNameLabel);
            this.Controls.Add(this.CreateTeamLabel);
            this.Font = new System.Drawing.Font("Eras Demi ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CreateTeamForm";
            this.Text = "Create Team";
            this.AddNewMember.ResumeLayout(false);
            this.AddNewMember.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TeamNameTextBox;
        private System.Windows.Forms.Label TeamNameLabel;
        private System.Windows.Forms.Label CreateTeamLabel;
        private System.Windows.Forms.Button AddTeamMemberButton;
        private System.Windows.Forms.ComboBox SelectTeamMemberDropDown;
        private System.Windows.Forms.Label SelectTeamMemberLabel;
        private System.Windows.Forms.GroupBox AddNewMember;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Button CreateMemberButton;
        private System.Windows.Forms.ListBox TeamMembersListBox;
        private System.Windows.Forms.Button RemoveSelectedMembersButton;
        private System.Windows.Forms.Button CreateTeamtButton;
    }
}