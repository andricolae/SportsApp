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
                        selectedMatchups.Add(m);
                    }
                }
            }
            LoadMatchup(selectedMatchups.First());
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
    }
}
