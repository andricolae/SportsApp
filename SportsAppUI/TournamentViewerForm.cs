using SportsAppLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsAppUI
{
    public partial class TournamentViewerForm : Form
    {
        private Tournament tournament;
        BindingList<int> rounds = new BindingList<int>();   
        BindingList<Matchup> selectedMatchups = new BindingList<Matchup>();
        
        public TournamentViewerForm(Tournament model)
        {
            InitializeComponent();
            tournament = model;
            LoadLists();
            LoadFormData();
            LoadRounds();
        }
        private void LoadFormData()
        {
            TournamentNameLabel.Text = tournament.TournamentName;
        }
        public void LoadLists()
        {
            RoundDropDown.DataSource = rounds;
            MatchUpListBox.DataSource = selectedMatchups;
            MatchUpListBox.DisplayMember = "Display";
        }

        private void LoadRounds()
        {
            rounds.Clear();
            rounds.Add(1);
            int currentRound = 1;
            foreach (List<Matchup> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currentRound)
                {
                    currentRound = matchups.First().MatchupRound;
                    rounds.Add(currentRound);
                }
            }
            LoadMatchups(1);
        }

        private void RoundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)RoundDropDown.SelectedItem);
        }
        private void LoadMatchups(int round)
        {
            foreach (List<Matchup> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    selectedMatchups.Clear();
                    foreach (Matchup m in matchups)
                    {
                        if (m.Winner == null || !UnplayedOnlyCheckBox.Checked)
                        {
                            selectedMatchups.Add(m);
                        }                    
                    }
                }
            }

            if (selectedMatchups.Count > 0)
            {
                LoadMatchup(selectedMatchups.First());

            }
            DisplayMatchupCtrls();
        }
        private void DisplayMatchupCtrls()
        {
            bool visible = (selectedMatchups.Count > 0);
            FirstTeamLabel.Visible = visible;
            FirstTeamScoreLabel.Visible = visible;
            FirstTeamScoreValue.Visible = visible;
            SecondTeamLabel.Visible = visible;
            SecondTeamScoreLabel.Visible = visible;
            SecondTeamScoreValue.Visible = visible;
            ScoreButton.Visible = visible;
            vsLabel.Visible = visible;
        }

        private void LoadMatchup(Matchup m)
        {
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        FirstTeamLabel.Text = m.Entries[0].TeamCompeting.TeamName;
                        FirstTeamScoreValue.Text = m.Entries[0].Score.ToString();

                        SecondTeamLabel.Text = "<dummy>";
                        SecondTeamScoreValue.Text = "0";
                    }
                    else
                    {
                        FirstTeamLabel.Text = "Too Soon";
                        FirstTeamScoreValue.Text = "0";

                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        SecondTeamLabel.Text = m.Entries[1].TeamCompeting.TeamName;
                        SecondTeamScoreValue.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        SecondTeamLabel.Text = "Too Soon";
                        SecondTeamScoreValue.Text = m.Entries[1].Score.ToString();
                    }
                }
            }
            if (SecondTeamLabel.Text.Equals("<dummy>"))
            {
                FirstTeamScoreValue.Text = "1";
            }
        }
        private void MatchUpListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((Matchup)MatchUpListBox.SelectedItem == null)
            {
                MatchUpListBox.SetSelected(0, true);
            }
            LoadMatchup((Matchup)MatchUpListBox.SelectedItem);
        }

        private void UnplayedOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)RoundDropDown.SelectedItem);
        }

        private string ValidateData()
        {
            string output = "";
            double score1 = 0, score2 = 0;
            bool score1Valid = double.TryParse(FirstTeamScoreValue.Text, out score1);
            bool score2Valid = double.TryParse(SecondTeamScoreValue.Text, out score2);
            if (!score1Valid || !score2Valid)
            {
                output = "Scores are not valid numbers";
            }
            if (score1 == score2 && score1Valid == true && score2Valid == true)
            {
                output = "Ties not allowed";
            }
            return output;
        }
        private void ScoreButton_Click(object sender, EventArgs e)
        {
            string err = ValidateData();
            if (err.Length > 0)
            {
                MessageBox.Show($"Error: {err}");
                return;
            }

            Matchup m = (Matchup)MatchUpListBox.SelectedItem;
            double score1 = 0, score2 = 0;

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0) 
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(FirstTeamScoreValue.Text, out score1);

                        if (scoreValid)
                        {
                            m.Entries[0].Score = score1;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 1");
                            return;
                        }
                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(SecondTeamScoreValue.Text, out score2);

                        if (scoreValid)
                        {
                            m.Entries[1].Score = score2;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 2");
                            return;
                        }
                    }
                }
            }
            try
            {
                if (score1 > score2)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                }
                else if (score2 > score1)
                {
                    m.Winner = m.Entries[1].TeamCompeting;
                }
                else
                {
                    throw new Exception("I can't stand ties!");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Application had an error>>> {exc.Message}");
            }

            foreach (List<Matchup> round in tournament.Rounds)
            {
                foreach (Matchup rm in round)
                {
                    foreach (MatchupEntry me in rm.Entries)
                    {
                        if (me.ParentMatchup != null)
                        {
                            if (me.ParentMatchup.Id == m.Id)
                            {
                                me.TeamCompeting = m.Winner;
                                GlobalConfiguration.Connection.UpdateMatchup(rm);
                            } 
                        }
                    }
                }
            }
            LoadMatchups((int)RoundDropDown.SelectedItem);
           
            GlobalConfiguration.Connection.UpdateMatchup(m);
        }
    }
}
