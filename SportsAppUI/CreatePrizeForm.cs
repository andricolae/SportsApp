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
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        // TODO - Alert the user of all the invalidation reasons
        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValid = int.TryParse(PlaceNumberTextBox.Text, out placeNumber);
            decimal prizeAmount = 0;
            double prizePercentage = 0;
            bool prizeAmountValid = decimal.TryParse(PrizeAmountTextBox.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(PrizePercentageTextBox.Text, out prizePercentage);

            if (!placeNumberValid)
            {
                output = false;
            }
            if (placeNumber < 1)
            {
                output = false;
            }
            if (PlaceNameTextBox.Text.Length == 0)
            {
                output = false;
            }
            if (!prizeAmountValid || !prizePercentageValid)
            {
                output = false;
            }
            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }
            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }
            return output;
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Prize model = new Prize(PlaceNumberTextBox.Text, PlaceNameTextBox.Text,
                    PrizeAmountTextBox.Text, PrizePercentageTextBox.Text);

                foreach (IDataConnection dc in GlobalConfiguration.Connections)
                {
                    dc.CreatePrize(model);
                }
                PlaceNumberTextBox.Text = "";
                PlaceNameTextBox.Text = "";
                PrizeAmountTextBox.Text = "0"; 
                PrizePercentageTextBox.Text = "0";
            }
            else
            {
                MessageBox.Show("Invalid Information in the Form !");
            }
        }
    }
}