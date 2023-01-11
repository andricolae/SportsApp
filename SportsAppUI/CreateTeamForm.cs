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
        public CreateTeamForm()
        {
            InitializeComponent();
            //CreateSampleData();
            PopulateLists();
        }

        private void CreateSampleData()
        {
            insertedPersons.Add(new Person { FirstName = "Nico", LastName = "Pop" });
            insertedPersons.Add(new Person { FirstName = "Andrei", LastName = "Nicolae" });
            addedTeamMembers.Add(new Person { FirstName = "Marius", LastName = "Calutiu" });
            addedTeamMembers.Add(new Person { FirstName = "Vlad", LastName = "Gherghe" });
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
            team = GlobalConfiguration.Connection.CreateTeam(team);
        }
    }
}
