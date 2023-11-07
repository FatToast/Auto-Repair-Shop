using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_Repair_Shop
{
    public partial class JoesAutomotive : Form
    {
        public JoesAutomotive()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Call the necessary functions to calculate the total charges
            double maintenanceCharges = OilLubeCharges() + FlushCharges() + MiscCharges();
            double laborCharges = TotalLaborCharges();

            if (double.TryParse(txtBoxPartsCost.Text, out double partsCost))
            {
                double taxCharges = TaxCharges(partsCost);
                double totalCharges = maintenanceCharges + laborCharges + taxCharges;

                TotalChargesBox.Text = totalCharges.ToString("C");
                lblTax.Text = taxCharges.ToString("C");
                lblPartsTotal.Text = partsCost.ToString("C");
                lblLaborCost.Text = laborCharges.ToString("C");
            }
        }
        // Maintenance Charges functions
        private double OilLubeCharges()
        {
            double totalCharges = 0.0;

            if (chkBoxOilChange.Checked == true)
            {
                totalCharges += 26.00; // Oil Change cost
            }

            if (chkBoxLube.Checked)
            {
                totalCharges += 18.00; // Lube Job cost
            }

            return totalCharges;
        }
        private double FlushCharges()
        {
            double totalCharges = 0.0;

            if (chkBoxRadiatorFlush.Checked)
            {
                totalCharges += 30.00; // Radiator Flush cost
            }

            if (chkBoxTrasmission.Checked)
            {
                totalCharges += 80.00; // Transmission Flush cost
            }

            return totalCharges;
        }
        private double MiscCharges()
        {
            double totalCharges = 0.0;

            if (chkInspection.Checked)
            {
                totalCharges += 15.00; // Inspection cost
            }

            if (chkMuffler.Checked)
            {
                totalCharges += 100.00; // Muffler Replacement cost
            }

            if (chkRotation.Checked)
            {
                totalCharges += 20.00; // Tire Rotation cost
            }

            return totalCharges;
        }



        // Labor Charges functions
        private double TotalLaborCharges()
        {
            // Assuming the labor rate is $29 per hour
            if (double.TryParse(txtBoxLaborHours.Text, out double laborHours))
            {
                double hourlyRate = 29.00;
                double charges = laborHours * hourlyRate;
                return charges;
            }

            return 0.0; // Return 0 if labor hours are not valid
        }

        private void ClearOilLube()
        {
            chkBoxOilChange.Checked = false;
            chkBoxLube.Checked = false;
        }

        private void ClearFlushes()
        {
            chkBoxRadiatorFlush.Checked = false;
            chkBoxTrasmission.Checked = false;
        }

        private void ClearMisc()
        {
            chkInspection.Checked = false;
            chkMuffler.Checked = false;
            chkRotation.Checked = false;
        }

        private void ClearFees()
        {
            txtBoxPartsCost.Clear();
            txtBoxLaborHours.Clear();
        }

        private double TaxCharges(double partsCost)
        {
            // Sales tax is 6% and is charged only on parts.
            return 0.06 * partsCost;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearOilLube();
            ClearFlushes();
            ClearMisc();
            ClearFees();
        }
    }
}