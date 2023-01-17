using SportsAppLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsAppUI
{
    public partial class CreatePrizeForm : Form
    {
        IPrizeCreator callingForm;
        public CreatePrizeForm(IPrizeCreator caller)
        {
            InitializeComponent();
            callingForm = caller;
        }

        private string ValidateData()
        {
            string output = "";
            bool placeNumberValid = int.TryParse(PlaceNumberTextBox.Text, out int placeNumber);
            bool prizeAmountValid = decimal.TryParse(PrizeAmountTextBox.Text, out decimal prizeAmount);
            bool prizePercentageValid = double.TryParse(PrizePercentageTextBox.Text, out double prizePercentage);

            if (!placeNumberValid || placeNumber > 5 || placeNumber < 1)
            {
                output = "\nPlace number must be a digit between 1 and 5";
            }
            if (PlaceNameTextBox.Text.Length == 0)
            {
                output += "\nPlace name can not be empty";
            }
            if (!prizeAmountValid || !prizePercentageValid || (prizeAmount <= 0 && prizePercentage <= 0))
            {
                output += "\nPrize amount and percentage must be numbers and can not be both 0 and/or negative";
            }
            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output += "\nPrize percentage must be in range 1 - 100";
            }
            return output;
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            string err = ValidateData();
            if (err.Length > 0)
            {
                MessageBox.Show($"Error: {err}");
                return;
            }
            Prize model = new Prize(PlaceNumberTextBox.Text, PlaceNameTextBox.Text,
                PrizeAmountTextBox.Text, PrizePercentageTextBox.Text);

            GlobalConfiguration.Connection.CreatePrize(model);

            callingForm.PrizeCreated(model);

            this.Close();

            PlaceNumberTextBox.Text = "";
            PlaceNameTextBox.Text = "";
            PrizeAmountTextBox.Text = "0"; 
            PrizePercentageTextBox.Text = "0";            
        }
    }
}