using SportsAppLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

        private string ValidateTeamData()
        {
            string output = "";
            if (TeamNameTextBox.Text.Length == 0)
            {
                output = "\nTeam must have a name";
            }
            if (addedTeamMembers.Count < 1)
            {
                output += "\nTeams must have at least 1 member";
            }
            return output;
        }
        private string ValidateMemberData()
        {
            string output = "";
            if (FirstNameTextBox.Text.Length == 0)
            {
                output = "\nTeam Member must have at least a first name";
            }
            if (EmailTextBox.Text.Length != 0 || PhoneTextBox.Text.Length != 0)
            {
                string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|ro)$";
                if (EmailTextBox.Text.Length != 0)
                {
                    bool validEmail = Regex.IsMatch(EmailTextBox.Text, regex, RegexOptions.IgnoreCase);
                    if (!validEmail)
                    {
                        output += "\nMember Email not valid";
                    }
                }
                if (PhoneTextBox.Text.Length != 0)
                {
                    bool validPhone = true;
                    foreach (char c in PhoneTextBox.Text)
                    {
                        if (!Char.IsDigit(c))
                        {
                            validPhone = false;
                            break;
                        }
                    }
                    if (!validPhone)
                    {
                        output += "\nMember Phone not valid";
                    }
                }
            }
            else
            {
                output += "\nMember must have an email or phone number";
            }
            return output;
        }

        private void CreateMemberButton_Click(object sender, EventArgs e)
        {
            string err = ValidateMemberData();
            if (err.Length > 0)
            {
                MessageBox.Show($"Error: {err}");
                return;
            }
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
            string err = ValidateTeamData();
            if (err.Length > 0)
            {
                MessageBox.Show($"Error: {err}");
                return;
            }
            Team team = new Team();
            team.TeamName = TeamNameTextBox.Text;
            team.TeamMembers = addedTeamMembers;
            GlobalConfiguration.Connection.CreateTeam(team);
            callingForm.TeamCreatead(team);
            this.Close();
        }
    }
}
