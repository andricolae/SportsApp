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
    public partial class TournamentDashboardForm : Form
    {
        List<Tournament> tournaments = GlobalConfiguration.Connection.GetTournaments();
        public TournamentDashboardForm()
        {
            InitializeComponent();

            LoadTournamentsList();
        }

        public void LoadTournamentsList()
        {
            LoadExistingTournamentDropDown.DataSource = tournaments;
            LoadExistingTournamentDropDown.DisplayMember= "TournamentName";
        }

        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {
            CreateTournamentForm form = new CreateTournamentForm();
            form.Show();
        }

        private void LoadTournamentButton_Click(object sender, EventArgs e)
        {
            Tournament tournament = (Tournament)LoadExistingTournamentDropDown.SelectedItem;
            TournamentViewerForm form = new TournamentViewerForm(tournament);
            form.Show();
        }
    }
}
