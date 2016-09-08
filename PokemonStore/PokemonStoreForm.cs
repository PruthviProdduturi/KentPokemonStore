using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonStore
{
    public partial class PokemonStoreForm : Form
    {
        /// <summary>
        /// Unit price for each Pokemon type
        /// </summary>
        double pikaCost = 6, squCost = 5, charmCost = 5;

        public PokemonStoreForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Captures quantities and displays the discounted total on button click
        /// </summary>
        private void subBtn_Click(object sender, EventArgs e)
        {
            int pikNum, squNum, charmNum;

            if (!int.TryParse(pikaBox.Text, out pikNum) || pikNum < 0)
            {
                MessageBox.Show("Please enter a valid number (0 or more) for Pikachu.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pikaBox.Focus();
                return;
            }
            if (!int.TryParse(squBox.Text, out squNum) || squNum < 0)
            {
                MessageBox.Show("Please enter a valid number (0 or more) for Squirtle.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                squBox.Focus();
                return;
            }
            if (!int.TryParse(charmBox.Text, out charmNum) || charmNum < 0)
            {
                MessageBox.Show("Please enter a valid number (0 or more) for Charmander.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                charmBox.Focus();
                return;
            }

            double totalCost = PriceCalculator(pikNum, squNum, charmNum);
            priceLb.Text = totalCost.ToString("F2") + " $";
        }

        /// <summary>
        /// Resets all quantities and the total price
        /// </summary>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            pikaBox.Text = "0";
            squBox.Text = "0";
            charmBox.Text = "0";
            priceLb.Text = "0.00 $";
        }

        /// <summary>
        /// Calculates the total price with tiered discounts:
        ///   - 20% off when buying all 3 types together
        ///   - 10% off when buying 2 types together
        ///   - No discount for single-type purchases
        /// </summary>
        /// <param name="pikNum">Number of Pikachu</param>
        /// <param name="squNum">Number of Squirtle</param>
        /// <param name="charmNum">Number of Charmander</param>
        /// <returns>Total discounted price rounded to 2 decimal places</returns>
        public double PriceCalculator(double pikNum, double squNum, double charmNum)
        {
            double totalCost = 0;
            double maxNum = Math.Max(Math.Max(pikNum, squNum), charmNum);

            while (maxNum != 0)
            {
                double minNum = Math.Min(Math.Min(pikNum, squNum), charmNum);
                if (minNum != 0)
                {
                    // Cost of three different Pokemon with 20% discount
                    totalCost += (((pikaCost + squCost + charmCost) * 80) / 100) * minNum;
                    pikNum -= minNum;
                    squNum -= minNum;
                    charmNum -= minNum;
                    maxNum = Math.Max(Math.Max(pikNum, squNum), charmNum);
                }
                // Cost of two different Pokemon with 10% discount
                else if (pikNum != 0 && squNum != 0)
                {
                    minNum = Math.Min(pikNum, squNum);
                    totalCost += (((pikaCost + squCost) * 90) / 100) * minNum;
                    pikNum -= minNum;
                    squNum -= minNum;
                    maxNum = Math.Max(pikNum, squNum);
                }
                else if (pikNum != 0 && charmNum != 0)
                {
                    minNum = Math.Min(pikNum, charmNum);
                    totalCost += (((pikaCost + charmCost) * 90) / 100) * minNum;
                    pikNum -= minNum;
                    charmNum -= minNum;
                    maxNum = Math.Max(pikNum, charmNum);
                }
                else if (squNum != 0 && charmNum != 0)
                {
                    minNum = Math.Min(squNum, charmNum);
                    totalCost += (((squCost + charmCost) * 90) / 100) * minNum;
                    squNum -= minNum;
                    charmNum -= minNum;
                    maxNum = Math.Max(squNum, charmNum);
                }
                // Cost of individual Pokemon without discount
                else
                {
                    totalCost += (pikaCost * pikNum + squCost * squNum + charmCost * charmNum);
                    maxNum = 0;
                }
            }
            return Math.Round(totalCost, 2);
        }
    }
}
