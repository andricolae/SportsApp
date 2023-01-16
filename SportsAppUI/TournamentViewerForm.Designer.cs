namespace SportsAppUI
{
    partial class TournamentViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentViewerForm));
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.TournamentNameLabel = new System.Windows.Forms.Label();
            this.RoundLabel = new System.Windows.Forms.Label();
            this.RoundDropDown = new System.Windows.Forms.ComboBox();
            this.UnplayedOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.MatchUpListBox = new System.Windows.Forms.ListBox();
            this.FirstTeamLabel = new System.Windows.Forms.Label();
            this.FirstTeamScoreLabel = new System.Windows.Forms.Label();
            this.SecondTeamScoreLabel = new System.Windows.Forms.Label();
            this.SecondTeamLabel = new System.Windows.Forms.Label();
            this.FirstTeamScoreValue = new System.Windows.Forms.TextBox();
            this.SecondTeamScoreValue = new System.Windows.Forms.TextBox();
            this.vsLabel = new System.Windows.Forms.Label();
            this.ScoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Eras Demi ITC", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.White;
            this.HeaderLabel.Location = new System.Drawing.Point(12, 40);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(247, 43);
            this.HeaderLabel.TabIndex = 0;
            this.HeaderLabel.Text = "Tournament:";
            // 
            // TournamentNameLabel
            // 
            this.TournamentNameLabel.AutoSize = true;
            this.TournamentNameLabel.Font = new System.Drawing.Font("Eras Demi ITC", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TournamentNameLabel.ForeColor = System.Drawing.Color.White;
            this.TournamentNameLabel.Location = new System.Drawing.Point(252, 40);
            this.TournamentNameLabel.Name = "TournamentNameLabel";
            this.TournamentNameLabel.Size = new System.Drawing.Size(57, 43);
            this.TournamentNameLabel.TabIndex = 1;
            this.TournamentNameLabel.Text = "<>";
            // 
            // RoundLabel
            // 
            this.RoundLabel.AutoSize = true;
            this.RoundLabel.Location = new System.Drawing.Point(36, 108);
            this.RoundLabel.Name = "RoundLabel";
            this.RoundLabel.Size = new System.Drawing.Size(103, 32);
            this.RoundLabel.TabIndex = 2;
            this.RoundLabel.Text = "Round";
            // 
            // RoundDropDown
            // 
            this.RoundDropDown.FormattingEnabled = true;
            this.RoundDropDown.Location = new System.Drawing.Point(171, 105);
            this.RoundDropDown.Name = "RoundDropDown";
            this.RoundDropDown.Size = new System.Drawing.Size(237, 39);
            this.RoundDropDown.TabIndex = 3;
            this.RoundDropDown.SelectedIndexChanged += new System.EventHandler(this.RoundDropDown_SelectedIndexChanged);
            // 
            // UnplayedOnlyCheckBox
            // 
            this.UnplayedOnlyCheckBox.AutoSize = true;
            this.UnplayedOnlyCheckBox.Font = new System.Drawing.Font("Eras Demi ITC", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnplayedOnlyCheckBox.Location = new System.Drawing.Point(171, 159);
            this.UnplayedOnlyCheckBox.Name = "UnplayedOnlyCheckBox";
            this.UnplayedOnlyCheckBox.Size = new System.Drawing.Size(196, 30);
            this.UnplayedOnlyCheckBox.TabIndex = 4;
            this.UnplayedOnlyCheckBox.Text = "Unplayed Only";
            this.UnplayedOnlyCheckBox.UseVisualStyleBackColor = true;
            this.UnplayedOnlyCheckBox.CheckedChanged += new System.EventHandler(this.UnplayedOnlyCheckBox_CheckedChanged);
            // 
            // MatchUpListBox
            // 
            this.MatchUpListBox.FormattingEnabled = true;
            this.MatchUpListBox.ItemHeight = 31;
            this.MatchUpListBox.Location = new System.Drawing.Point(42, 216);
            this.MatchUpListBox.Name = "MatchUpListBox";
            this.MatchUpListBox.Size = new System.Drawing.Size(366, 252);
            this.MatchUpListBox.TabIndex = 5;
            this.MatchUpListBox.SelectedIndexChanged += new System.EventHandler(this.MatchUpListBox_SelectedIndexChanged);
            // 
            // FirstTeamLabel
            // 
            this.FirstTeamLabel.AutoSize = true;
            this.FirstTeamLabel.Location = new System.Drawing.Point(445, 148);
            this.FirstTeamLabel.Name = "FirstTeamLabel";
            this.FirstTeamLabel.Size = new System.Drawing.Size(166, 32);
            this.FirstTeamLabel.TabIndex = 6;
            this.FirstTeamLabel.Text = "<first team>";
            // 
            // FirstTeamScoreLabel
            // 
            this.FirstTeamScoreLabel.AutoSize = true;
            this.FirstTeamScoreLabel.Location = new System.Drawing.Point(445, 195);
            this.FirstTeamScoreLabel.Name = "FirstTeamScoreLabel";
            this.FirstTeamScoreLabel.Size = new System.Drawing.Size(86, 32);
            this.FirstTeamScoreLabel.TabIndex = 7;
            this.FirstTeamScoreLabel.Text = "Score";
            // 
            // SecondTeamScoreLabel
            // 
            this.SecondTeamScoreLabel.AutoSize = true;
            this.SecondTeamScoreLabel.Location = new System.Drawing.Point(445, 368);
            this.SecondTeamScoreLabel.Name = "SecondTeamScoreLabel";
            this.SecondTeamScoreLabel.Size = new System.Drawing.Size(86, 32);
            this.SecondTeamScoreLabel.TabIndex = 9;
            this.SecondTeamScoreLabel.Text = "Score";
            // 
            // SecondTeamLabel
            // 
            this.SecondTeamLabel.AutoSize = true;
            this.SecondTeamLabel.Location = new System.Drawing.Point(445, 321);
            this.SecondTeamLabel.Name = "SecondTeamLabel";
            this.SecondTeamLabel.Size = new System.Drawing.Size(211, 32);
            this.SecondTeamLabel.TabIndex = 8;
            this.SecondTeamLabel.Text = "<second team>";
            // 
            // FirstTeamScoreValue
            // 
            this.FirstTeamScoreValue.Location = new System.Drawing.Point(537, 188);
            this.FirstTeamScoreValue.Name = "FirstTeamScoreValue";
            this.FirstTeamScoreValue.Size = new System.Drawing.Size(100, 39);
            this.FirstTeamScoreValue.TabIndex = 10;
            // 
            // SecondTeamScoreValue
            // 
            this.SecondTeamScoreValue.Location = new System.Drawing.Point(537, 361);
            this.SecondTeamScoreValue.Name = "SecondTeamScoreValue";
            this.SecondTeamScoreValue.Size = new System.Drawing.Size(100, 39);
            this.SecondTeamScoreValue.TabIndex = 11;
            // 
            // vsLabel
            // 
            this.vsLabel.AutoSize = true;
            this.vsLabel.Location = new System.Drawing.Point(486, 262);
            this.vsLabel.Name = "vsLabel";
            this.vsLabel.Size = new System.Drawing.Size(112, 32);
            this.vsLabel.TabIndex = 12;
            this.vsLabel.Text = "-versus-";
            // 
            // ScoreButton
            // 
            this.ScoreButton.ForeColor = System.Drawing.Color.Black;
            this.ScoreButton.Location = new System.Drawing.Point(464, 425);
            this.ScoreButton.Name = "ScoreButton";
            this.ScoreButton.Size = new System.Drawing.Size(163, 43);
            this.ScoreButton.TabIndex = 13;
            this.ScoreButton.Text = "Log Score";
            this.ScoreButton.UseVisualStyleBackColor = true;
            this.ScoreButton.Click += new System.EventHandler(this.ScoreButton_Click);
            // 
            // TournamentViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(693, 518);
            this.Controls.Add(this.ScoreButton);
            this.Controls.Add(this.vsLabel);
            this.Controls.Add(this.SecondTeamScoreValue);
            this.Controls.Add(this.FirstTeamScoreValue);
            this.Controls.Add(this.SecondTeamScoreLabel);
            this.Controls.Add(this.SecondTeamLabel);
            this.Controls.Add(this.FirstTeamScoreLabel);
            this.Controls.Add(this.FirstTeamLabel);
            this.Controls.Add(this.MatchUpListBox);
            this.Controls.Add(this.UnplayedOnlyCheckBox);
            this.Controls.Add(this.RoundDropDown);
            this.Controls.Add(this.RoundLabel);
            this.Controls.Add(this.TournamentNameLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Font = new System.Drawing.Font("Eras Demi ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TournamentViewerForm";
            this.Text = "Tournament Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Label TournamentNameLabel;
        private System.Windows.Forms.Label RoundLabel;
        private System.Windows.Forms.ComboBox RoundDropDown;
        private System.Windows.Forms.CheckBox UnplayedOnlyCheckBox;
        private System.Windows.Forms.ListBox MatchUpListBox;
        private System.Windows.Forms.Label FirstTeamLabel;
        private System.Windows.Forms.Label FirstTeamScoreLabel;
        private System.Windows.Forms.Label SecondTeamScoreLabel;
        private System.Windows.Forms.Label SecondTeamLabel;
        private System.Windows.Forms.TextBox FirstTeamScoreValue;
        private System.Windows.Forms.TextBox SecondTeamScoreValue;
        private System.Windows.Forms.Label vsLabel;
        private System.Windows.Forms.Button ScoreButton;
    }
}

