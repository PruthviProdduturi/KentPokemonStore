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
        /// Cost and number of pokemons
        /// </summary>
        double pikaCost = 6, squCost = 5, charmCost = 5, totalCost = 0.00;
        double pikNum, squNum, charmNum = 0;

        public PokemonStoreForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to capture number of pokemons on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void subBtn_Click(object sender, EventArgs e)
        {
            pikNum = Convert.ToInt32(pikaBox.Text);
            squNum = Convert.ToInt32(squBox.Text);
            charmNum = Convert.ToInt32(charmBox.Text);
            totalCost = PriceCalculator(pikNum, squNum, charmNum);
            priceLb.Text = Convert.ToString(totalCost) + " $";
            totalCost = 0;
        }

        /// <summary>
        /// Method to calculate price of pokemons purchased 
        /// </summary>
        /// <param name="pNum">Number of Pikachu</param>
        /// <param name="sNum">Number of Squirtle</param>
        /// <param name="cNum">Number of Charmander</param>
        /// <returns></returns>
        public double PriceCalculator(double pikNum, double squNum,  double charmNum)
        {
            double maxNum = Math.Max(Math.Max(pikNum, squNum), charmNum); // Calulating max value 
            while (maxNum != 0)
            {
                double minNum = Math.Min(Math.Min(pikNum, squNum), charmNum);
                if (minNum != 0)
                {
                    // Cost of three different pokemons with 20% discount 
                    totalCost = totalCost + ((((pikaCost + squCost + charmCost) * 80) / 100) * minNum);
                    pikNum = pikNum - minNum;
                    squNum = squNum - minNum;
                    charmNum = charmNum - minNum;
                    maxNum = Math.Max(Math.Max(pikNum, squNum), charmNum);
                }
                // Cost of two differnt pokemons with 10% discount 
                else if (pikNum != 0 && squNum != 0)
                {
                    minNum = Math.Min(pikNum, squNum);
                    totalCost = totalCost + (((pikaCost + squCost) * 90) / 100) * minNum;
                    pikNum = pikNum - minNum;
                    squNum = squNum - minNum;
                    maxNum = Math.Max(pikNum, squNum);
                }
                else if (pikNum != 0 && charmNum != 0)
                {
                    minNum = Math.Min(pikNum, charmNum);
                    totalCost = totalCost + (((pikaCost + charmCost) * 90) / 100) * minNum;
                    pikNum = pikNum - minNum;
                    charmNum = charmNum - minNum;
                    maxNum = Math.Max(pikNum, charmNum);
                }
                else if (squNum != 0 && charmNum != 0)
                {
                    minNum = Math.Min(squNum, charmNum);
                    totalCost = totalCost + (((squCost + charmCost) * 90) / 100) * minNum;
                    squNum = squNum - minNum;
                    charmNum = charmNum - minNum;
                    maxNum = Math.Max(squNum, charmNum);
                }
                //Cost of individual pokemons without discount 
                else
                {
                    totalCost = totalCost + (pikaCost * pikNum + squCost * squNum + charmCost * charmNum);
                    maxNum = 0;
                }
            }
            return Math.Round(totalCost, 2);
        
        }
    }
}
