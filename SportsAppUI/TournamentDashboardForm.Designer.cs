namespace SportsAppUI
{
    partial class TournamentDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentDashboardForm));
            this.TournamentDashboardLabel = new System.Windows.Forms.Label();
            this.LoadExistingTournamentDropDown = new System.Windows.Forms.ComboBox();
            this.LoadExistingTournamentLabel = new System.Windows.Forms.Label();
            this.LoadTournamentButton = new System.Windows.Forms.Button();
            this.CreateTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TournamentDashboardLabel
            // 
            this.TournamentDashboardLabel.AutoSize = true;
            this.TournamentDashboardLabel.Font = new System.Drawing.Font("Eras Demi ITC", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TournamentDashboardLabel.ForeColor = System.Drawing.Color.White;
            this.TournamentDashboardLabel.Location = new System.Drawing.Point(84, 45);
            this.TournamentDashboardLabel.Name = "TournamentDashboardLabel";
            this.TournamentDashboardLabel.Size = new System.Drawing.Size(439, 43);
            this.TournamentDashboardLabel.TabIndex = 26;
            this.TournamentDashboardLabel.Text = "Tournament Dashboard";
            // 
            // LoadExistingTournamentDropDown
            // 
            this.LoadExistingTournamentDropDown.FormattingEnabled = true;
            this.LoadExistingTournamentDropDown.Location = new System.Drawing.Point(92, 194);
            this.LoadExistingTournamentDropDown.Name = "LoadExistingTournamentDropDown";
            this.LoadExistingTournamentDropDown.Size = new System.Drawing.Size(431, 39);
            this.LoadExistingTournamentDropDown.TabIndex = 37;
            // 
            // LoadExistingTournamentLabel
            // 
            this.LoadExistingTournamentLabel.AutoSize = true;
            this.LoadExistingTournamentLabel.Location = new System.Drawing.Point(124, 159);
            this.LoadExistingTournamentLabel.Name = "LoadExistingTournamentLabel";
            this.LoadExistingTournamentLabel.Size = new System.Drawing.Size(364, 32);
            this.LoadExistingTournamentLabel.TabIndex = 36;
            this.LoadExistingTournamentLabel.Text = "Load Existing Tournament";
            // 
            // LoadTournamentButton
            // 
            this.LoadTournamentButton.ForeColor = System.Drawing.Color.Black;
            this.LoadTournamentButton.Location = new System.Drawing.Point(177, 250);
            this.LoadTournamentButton.Name = "LoadTournamentButton";
            this.LoadTournamentButton.Size = new System.Drawing.Size(261, 41);
            this.LoadTournamentButton.TabIndex = 38;
            this.LoadTournamentButton.Text = "Load Tournament";
            this.LoadTournamentButton.UseVisualStyleBackColor = true;
            // 
            // CreateTournamentButton
            // 
            this.CreateTournamentButton.Font = new System.Drawing.Font("Eras Demi ITC", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTournamentButton.ForeColor = System.Drawing.Color.Black;
            this.CreateTournamentButton.Location = new System.Drawing.Point(130, 349);
            this.CreateTournamentButton.Name = "CreateTournamentButton";
            this.CreateTournamentButton.Size = new System.Drawing.Size(342, 51);
            this.CreateTournamentButton.TabIndex = 43;
            this.CreateTournamentButton.Text = "Create Tournament";
            this.CreateTournamentButton.UseVisualStyleBackColor = true;
            // 
            // TournamentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(619, 449);
            this.Controls.Add(this.CreateTournamentButton);
            this.Controls.Add(this.LoadTournamentButton);
            this.Controls.Add(this.LoadExistingTournamentDropDown);
            this.Controls.Add(this.LoadExistingTournamentLabel);
            this.Controls.Add(this.TournamentDashboardLabel);
            this.Font = new System.Drawing.Font("Eras Demi ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "TournamentDashboardForm";
            this.Text = "Tournament Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TournamentDashboardLabel;
        private System.Windows.Forms.ComboBox LoadExistingTournamentDropDown;
        private System.Windows.Forms.Label LoadExistingTournamentLabel;
        private System.Windows.Forms.Button LoadTournamentButton;
        private System.Windows.Forms.Button CreateTournamentButton;
    }
}