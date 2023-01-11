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
    public partial class CreateTournamentForm : Form
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
    }
}
