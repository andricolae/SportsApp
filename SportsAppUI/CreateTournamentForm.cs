using SportsAppLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsAppUI
{
    public partial class CreateTournamentForm : Form, IPrizeCreator, ITeamCreator
    {
        List<Team> insertedTeams = GlobalConfiguration.Connection.GetAllTeams();
        List<Team> addedTeams = new List<Team>();
        List<Prize> addedPrizes = new List<Prize>();

        public CreateTournamentForm()
        {
            InitializeComponent();
            PopulateLists();
        }

        private void PopulateLists()
        {
            SelectTeamDropDown.DataSource = null;
            TournamentTeamsListBox.DataSource = null;
            PrizesListBox.DataSource = null;

            SelectTeamDropDown.DataSource = insertedTeams;
            SelectTeamDropDown.DisplayMember = "TeamName";

            TournamentTeamsListBox.DataSource = addedTeams;
            TournamentTeamsListBox.DisplayMember = "TeamName";

            PrizesListBox.DataSource = addedPrizes;
            PrizesListBox.DisplayMember = "PlaceName";
        }

        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            Team team = (Team)SelectTeamDropDown.SelectedItem;
            if (team != null)
            {
                insertedTeams.Remove(team);
                addedTeams.Add(team);
                PopulateLists();
            }
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            CreatePrizeForm form = new CreatePrizeForm(this);
            form.Show();

        }

        public void PrizeCreated(Prize model)
        {
            addedPrizes.Add(model);
            PopulateLists();
        }

        public void TeamCreatead(Team model)
        {
            addedTeams.Add(model);
            PopulateLists();
        }

        private void CreateTeamButton_Click(object sender, EventArgs e)
        {
            CreateTeamForm form = new CreateTeamForm(this);
            form.Show();
        }

        private void RemoveSelectedTeamButton_Click(object sender, EventArgs e)
        {
            Team team = (Team)TournamentTeamsListBox.SelectedItem;
            if (team != null)
            {
                addedTeams.Remove(team);
                insertedTeams.Add(team);
                PopulateLists();
            }
        }

        private void RemoveSelectedPrizesButton_Click(object sender, EventArgs e)
        {
            Prize prize = (Prize)PrizesListBox.SelectedItem;
            if (prize != null)
            {
                addedPrizes.Remove(prize);
                PopulateLists();
            }
        }

        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {
            double fee = 0;
            bool feeOK = double.TryParse(EntryFeeTextBox.Text, out fee);
            if (!feeOK)
            {
                MessageBox.Show("Entry Fee not valid!", "Valid number needed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Tournament tournament = new Tournament();
            tournament.TournamentName = TournamentNameTextBox.Text;
            tournament.Fee = fee;

            foreach (Prize prize in addedPrizes) 
            {
                tournament.Prizes.Add(prize);
            }

            foreach (Team team in addedTeams)
            {
                tournament.Teams.Add(team);
            }

            TournamentWork.CreateRounds(tournament);

            GlobalConfiguration.Connection.CreateTournament(tournament);

            this.Close();
            TournamentViewerForm form = new TournamentViewerForm(tournament);
            form.Show();
        }
    }
}
