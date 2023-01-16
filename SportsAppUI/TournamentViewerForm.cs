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
                    if (m.Entries[0].Team != null)
                    {
                        FirstTeamLabel.Text = m.Entries[0].Team.TeamName;
                        FirstTeamScoreValue.Text = m.Entries[0].Score.ToString();

                        SecondTeamLabel.Text = "<dummy>";
                        SecondTeamScoreValue.Text = m.Entries[0].Score.ToString();
                    }
                    else
                    {
                        FirstTeamLabel.Text = "Too Soon";
                        FirstTeamScoreValue.Text = "0";

                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].Team != null)
                    {
                        SecondTeamLabel.Text = m.Entries[1].Team.TeamName;
                        SecondTeamScoreValue.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        SecondTeamLabel.Text = "Too Soon";
                        SecondTeamScoreValue.Text = m.Entries[0].Score.ToString();
                    }
                }
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

        private void ScoreButton_Click(object sender, EventArgs e)
        {
            Matchup m = (Matchup)MatchUpListBox.SelectedItem;
            double score1 = 0, score2 = 0;

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].Team != null)
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
                    if (m.Entries[1].Team != null)
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
            if (score1 > score2)
            {
                m.Winner = m.Entries[0].Team;
            }
            else if (score2 > score1)
            {
                m.Winner = m.Entries[1].Team;
            }
            else
            {
                MessageBox.Show("I can't stand ties!");
            }

            foreach (List<Matchup> round in tournament.Rounds)
            {
                foreach (Matchup match in round)
                {
                    foreach (MatchupEntry entry in match.Entries)
                    {
                        if (entry.ParentMatchup != null)
                        {
                            if (entry.ParentMatchup.Id == match.Id)
                            {
                                entry.Team = m.Winner;
                                GlobalConfiguration.Connection.UpdateMatchup(match);

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
