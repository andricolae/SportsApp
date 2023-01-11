namespace SportsAppUI
{
    partial class CreateTournamentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTournamentForm));
            this.TournamentNameTextBox = new System.Windows.Forms.TextBox();
            this.TournamentNameLabel = new System.Windows.Forms.Label();
            this.CreateTournamentLabel = new System.Windows.Forms.Label();
            this.EntryFeeLabel = new System.Windows.Forms.Label();
            this.EntryFeeTextBox = new System.Windows.Forms.TextBox();
            this.SelectTeamDropDown = new System.Windows.Forms.ComboBox();
            this.SelectTeamLabel = new System.Windows.Forms.Label();
            this.CreateTeamButton = new System.Windows.Forms.Button();
            this.AddTeamButton = new System.Windows.Forms.Button();
            this.CreatePrizeButton = new System.Windows.Forms.Button();
            this.TournamentTeamsListBox = new System.Windows.Forms.ListBox();
            this.TeamsLabel = new System.Windows.Forms.Label();
            this.DeleteSelectedPlayersButton = new System.Windows.Forms.Button();
            this.DeleteSelectedPrizesButton = new System.Windows.Forms.Button();
            this.PrizesLabel = new System.Windows.Forms.Label();
            this.PrizesListBox = new System.Windows.Forms.ListBox();
            this.CreateTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TournamentNameTextBox
            // 
            this.TournamentNameTextBox.Location = new System.Drawing.Point(45, 142);
            this.TournamentNameTextBox.Name = "TournamentNameTextBox";
            this.TournamentNameTextBox.Size = new System.Drawing.Size(318, 39);
            this.TournamentNameTextBox.TabIndex = 24;
            // 
            // TournamentNameLabel
            // 
            this.TournamentNameLabel.AutoSize = true;
            this.TournamentNameLabel.Location = new System.Drawing.Point(39, 106);
            this.TournamentNameLabel.Name = "TournamentNameLabel";
            this.TournamentNameLabel.Size = new System.Drawing.Size(265, 32);
            this.TournamentNameLabel.TabIndex = 16;
            this.TournamentNameLabel.Text = "Tournament Name";
            // 
            // CreateTournamentLabel
            // 
            this.CreateTournamentLabel.AutoSize = true;
            this.CreateTournamentLabel.Font = new System.Drawing.Font("Eras Demi ITC", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTournamentLabel.ForeColor = System.Drawing.Color.White;
            this.CreateTournamentLabel.Location = new System.Drawing.Point(12, 39);
            this.CreateTournamentLabel.Name = "CreateTournamentLabel";
            this.CreateTournamentLabel.Size = new System.Drawing.Size(361, 43);
            this.CreateTournamentLabel.TabIndex = 14;
            this.CreateTournamentLabel.Text = "Create Tournament";
            // 
            // EntryFeeLabel
            // 
            this.EntryFeeLabel.AutoSize = true;
            this.EntryFeeLabel.Location = new System.Drawing.Point(39, 207);
            this.EntryFeeLabel.Name = "EntryFeeLabel";
            this.EntryFeeLabel.Size = new System.Drawing.Size(140, 32);
            this.EntryFeeLabel.TabIndex = 28;
            this.EntryFeeLabel.Text = "Entry Fee";
            // 
            // EntryFeeTextBox
            // 
            this.EntryFeeTextBox.Location = new System.Drawing.Point(183, 204);
            this.EntryFeeTextBox.Name = "EntryFeeTextBox";
            this.EntryFeeTextBox.Size = new System.Drawing.Size(121, 39);
            this.EntryFeeTextBox.TabIndex = 29;
            this.EntryFeeTextBox.Text = "0.0";
            // 
            // SelectTeamDropDown
            // 
            this.SelectTeamDropDown.FormattingEnabled = true;
            this.SelectTeamDropDown.Location = new System.Drawing.Point(45, 310);
            this.SelectTeamDropDown.Name = "SelectTeamDropDown";
            this.SelectTeamDropDown.Size = new System.Drawing.Size(318, 39);
            this.SelectTeamDropDown.TabIndex = 31;
            // 
            // SelectTeamLabel
            // 
            this.SelectTeamLabel.AutoSize = true;
            this.SelectTeamLabel.Location = new System.Drawing.Point(39, 267);
            this.SelectTeamLabel.Name = "SelectTeamLabel";
            this.SelectTeamLabel.Size = new System.Drawing.Size(171, 32);
            this.SelectTeamLabel.TabIndex = 30;
            this.SelectTeamLabel.Text = "Select Team";
            // 
            // CreateTeamButton
            // 
            this.CreateTeamButton.Font = new System.Drawing.Font("Eras Demi ITC", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTeamButton.ForeColor = System.Drawing.Color.Black;
            this.CreateTeamButton.Location = new System.Drawing.Point(235, 267);
            this.CreateTeamButton.Name = "CreateTeamButton";
            this.CreateTeamButton.Size = new System.Drawing.Size(128, 27);
            this.CreateTeamButton.TabIndex = 32;
            this.CreateTeamButton.Text = "Create New";
            this.CreateTeamButton.UseVisualStyleBackColor = true;
            // 
            // AddTeamButton
            // 
            this.AddTeamButton.ForeColor = System.Drawing.Color.Black;
            this.AddTeamButton.Location = new System.Drawing.Point(97, 403);
            this.AddTeamButton.Name = "AddTeamButton";
            this.AddTeamButton.Size = new System.Drawing.Size(182, 41);
            this.AddTeamButton.TabIndex = 33;
            this.AddTeamButton.Text = "Add Team";
            this.AddTeamButton.UseVisualStyleBackColor = true;
            this.AddTeamButton.Click += new System.EventHandler(this.AddTeamButton_Click);
            // 
            // CreatePrizeButton
            // 
            this.CreatePrizeButton.ForeColor = System.Drawing.Color.Black;
            this.CreatePrizeButton.Location = new System.Drawing.Point(97, 459);
            this.CreatePrizeButton.Name = "CreatePrizeButton";
            this.CreatePrizeButton.Size = new System.Drawing.Size(182, 41);
            this.CreatePrizeButton.TabIndex = 34;
            this.CreatePrizeButton.Text = "Create Prize";
            this.CreatePrizeButton.UseVisualStyleBackColor = true;
            // 
            // TournamentTeamsListBox
            // 
            this.TournamentTeamsListBox.FormattingEnabled = true;
            this.TournamentTeamsListBox.ItemHeight = 31;
            this.TournamentTeamsListBox.Location = new System.Drawing.Point(410, 142);
            this.TournamentTeamsListBox.Name = "TournamentTeamsListBox";
            this.TournamentTeamsListBox.Size = new System.Drawing.Size(374, 190);
            this.TournamentTeamsListBox.TabIndex = 35;
            // 
            // TeamsLabel
            // 
            this.TeamsLabel.AutoSize = true;
            this.TeamsLabel.Location = new System.Drawing.Point(404, 106);
            this.TeamsLabel.Name = "TeamsLabel";
            this.TeamsLabel.Size = new System.Drawing.Size(99, 32);
            this.TeamsLabel.TabIndex = 36;
            this.TeamsLabel.Text = "Teams";
            // 
            // DeleteSelectedPlayersButton
            // 
            this.DeleteSelectedPlayersButton.ForeColor = System.Drawing.Color.Black;
            this.DeleteSelectedPlayersButton.Location = new System.Drawing.Point(483, 338);
            this.DeleteSelectedPlayersButton.Name = "DeleteSelectedPlayersButton";
            this.DeleteSelectedPlayersButton.Size = new System.Drawing.Size(226, 41);
            this.DeleteSelectedPlayersButton.TabIndex = 37;
            this.DeleteSelectedPlayersButton.Text = "Delete Selected";
            this.DeleteSelectedPlayersButton.UseVisualStyleBackColor = true;
            // 
            // DeleteSelectedPrizesButton
            // 
            this.DeleteSelectedPrizesButton.ForeColor = System.Drawing.Color.Black;
            this.DeleteSelectedPrizesButton.Location = new System.Drawing.Point(483, 567);
            this.DeleteSelectedPrizesButton.Name = "DeleteSelectedPrizesButton";
            this.DeleteSelectedPrizesButton.Size = new System.Drawing.Size(226, 41);
            this.DeleteSelectedPrizesButton.TabIndex = 40;
            this.DeleteSelectedPrizesButton.Text = "Delete Selected";
            this.DeleteSelectedPrizesButton.UseVisualStyleBackColor = true;
            // 
            // PrizesLabel
            // 
            this.PrizesLabel.AutoSize = true;
            this.PrizesLabel.Location = new System.Drawing.Point(404, 397);
            this.PrizesLabel.Name = "PrizesLabel";
            this.PrizesLabel.Size = new System.Drawing.Size(90, 32);
            this.PrizesLabel.TabIndex = 39;
            this.PrizesLabel.Text = "Prizes";
            // 
            // PrizesListBox
            // 
            this.PrizesListBox.FormattingEnabled = true;
            this.PrizesListBox.ItemHeight = 31;
            this.PrizesListBox.Location = new System.Drawing.Point(410, 432);
            this.PrizesListBox.Name = "PrizesListBox";
            this.PrizesListBox.Size = new System.Drawing.Size(374, 128);
            this.PrizesListBox.TabIndex = 38;
            // 
            // CreateTournamentButton
            // 
            this.CreateTournamentButton.Font = new System.Drawing.Font("Eras Demi ITC", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTournamentButton.ForeColor = System.Drawing.Color.Black;
            this.CreateTournamentButton.Location = new System.Drawing.Point(20, 561);
            this.CreateTournamentButton.Name = "CreateTournamentButton";
            this.CreateTournamentButton.Size = new System.Drawing.Size(342, 47);
            this.CreateTournamentButton.TabIndex = 41;
            this.CreateTournamentButton.Text = "Create Tournament";
            this.CreateTournamentButton.UseVisualStyleBackColor = true;
            // 
            // CreateTournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(824, 656);
            this.Controls.Add(this.CreateTournamentButton);
            this.Controls.Add(this.DeleteSelectedPrizesButton);
            this.Controls.Add(this.PrizesLabel);
            this.Controls.Add(this.PrizesListBox);
            this.Controls.Add(this.DeleteSelectedPlayersButton);
            this.Controls.Add(this.TeamsLabel);
            this.Controls.Add(this.TournamentTeamsListBox);
            this.Controls.Add(this.CreatePrizeButton);
            this.Controls.Add(this.AddTeamButton);
            this.Controls.Add(this.CreateTeamButton);
            this.Controls.Add(this.SelectTeamDropDown);
            this.Controls.Add(this.SelectTeamLabel);
            this.Controls.Add(this.EntryFeeTextBox);
            this.Controls.Add(this.EntryFeeLabel);
            this.Controls.Add(this.TournamentNameTextBox);
            this.Controls.Add(this.TournamentNameLabel);
            this.Controls.Add(this.CreateTournamentLabel);
            this.Font = new System.Drawing.Font("Eras Demi ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CreateTournamentForm";
            this.Text = "Create Tournament";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TournamentNameTextBox;
        private System.Windows.Forms.Label TournamentNameLabel;
        private System.Windows.Forms.Label CreateTournamentLabel;
        private System.Windows.Forms.Label EntryFeeLabel;
        private System.Windows.Forms.TextBox EntryFeeTextBox;
        private System.Windows.Forms.ComboBox SelectTeamDropDown;
        private System.Windows.Forms.Label SelectTeamLabel;
        private System.Windows.Forms.Button CreateTeamButton;
        private System.Windows.Forms.Button AddTeamButton;
        private System.Windows.Forms.Button CreatePrizeButton;
        private System.Windows.Forms.ListBox TournamentTeamsListBox;
        private System.Windows.Forms.Label TeamsLabel;
        private System.Windows.Forms.Button DeleteSelectedPlayersButton;
        private System.Windows.Forms.Button DeleteSelectedPrizesButton;
        private System.Windows.Forms.Label PrizesLabel;
        private System.Windows.Forms.ListBox PrizesListBox;
        private System.Windows.Forms.Button CreateTournamentButton;
    }
}