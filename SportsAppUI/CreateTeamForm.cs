using SportsAppLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsAppUI
{
    public partial class CreateTeamForm : Form
    {
        private List<Person> insertedPersons = GlobalConfiguration.Connection.GetAllPersons();
        private List<Person> addedTeamMembers = new List<Person>();
        private ITeamCreator callingForm;
        public CreateTeamForm(ITeamCreator caller)
        {
            InitializeComponent();
            callingForm = caller;
            PopulateLists();
        }

        private void PopulateLists()
        {
            SelectTeamMemberDropDown.DataSource = null;
            SelectTeamMemberDropDown.DataSource = insertedPersons;
            SelectTeamMemberDropDown.DisplayMember = "FullName";

            TeamMembersListBox.DataSource = null;
            TeamMembersListBox.DataSource = addedTeamMembers;
            TeamMembersListBox.DisplayMember = "FullName";
        }

        // TODO - Validate member data at adding 
        // TODO - Team members list can t be empty at member adding
        // TODO - Team name can t be empty
        private string ValidateData()
        {
            string output = "";
            bool feeOK = double.TryParse(EntryFeeTextBox.Text, out double fee);

            if (TournamentNameTextBox.Text.Length == 0)
            {
                output = "\nTournament must have a name";
            }
            if (!feeOK)
            {
                output += "\nFee must be a number";
            }
            if (addedTeams.Count < 2)
            {
                output += "\nTournament must have at least 2 teams";
            }
            return output;
        }
        private bool ValidateForm()
        {
            bool output = true;
            if (FirstNameTextBox.Text.Length == 0)
            {
                output = false;
            }
            if (LastNameTextBox.Text.Length == 0)
            {
                output = false;
            }
            if (EmailTextBox.Text.Length == 0)
            {
                output = false;
            }
            if (PhoneTextBox.Text.Length == 0)
            {
                output = false;
            }
            return output;
        }

        private void CreateMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Person model = new Person();
                model.FirstName = FirstNameTextBox.Text;
                model.LastName = LastNameTextBox.Text;
                model.Email = EmailTextBox.Text;
                model.Phone = PhoneTextBox.Text;

                model = GlobalConfiguration.Connection.CreatePerson(model);

                addedTeamMembers.Add(model);
                PopulateLists();

                FirstNameTextBox.Text = "";
                LastNameTextBox.Text = "";
                EmailTextBox.Text = "";
                PhoneTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("There is missing information in the Form!");
            }
            
        }

        private void AddTeamMemberButton_Click(object sender, EventArgs e)
        {
            Person person = (Person) SelectTeamMemberDropDown.SelectedItem;
            if (person != null)
            {
                insertedPersons.Remove(person);
                addedTeamMembers.Add(person);
                PopulateLists();
            }
                
        }

        private void RemoveSelectedMembersButton_Click(object sender, EventArgs e)
        {
            Person person = (Person)TeamMembersListBox.SelectedItem;
            if (person != null)
            {
                addedTeamMembers.Remove(person);
                insertedPersons.Add(person);
                PopulateLists(); 
            }
        }

        private void CreateTeamtButton_Click(object sender, EventArgs e)
        {
            Team team = new Team();
            team.TeamName = TeamNameTextBox.Text;
            team.TeamMembers = addedTeamMembers;
            GlobalConfiguration.Connection.CreateTeam(team);
            callingForm.TeamCreatead(team);
            this.Close();
        }
    }
}
