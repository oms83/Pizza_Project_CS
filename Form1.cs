using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        float GetSelectedCrustPrice()
        {
            if (rbThickType.Checked)
            {
                return Convert.ToSingle(rbThickType.Tag);
            }
            else
            {
                return Convert.ToSingle(rbThinType.Tag);
            }
        }
        float GetSelectedToppingsPrice()
        {
            float ToppingsTotalPrice = 0;
            if (chkExtraChees.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkExtraChees.Tag);
            }
            if (chkMushrooms.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkMushrooms.Tag);
            }
            if(chkGreenPeppers.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkGreenPeppers.Tag);
            }
            if (chkOlives.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOlives.Tag);
            }
            if (chkOnion.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOnion.Tag);
            }
            if (chkTomatoes.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkTomatoes.Tag);
            }
            return ToppingsTotalPrice;
        }
        float GetSelectedSizePrice()
        {
            if (rbLargSize.Checked) 
            {
                return Convert.ToSingle(rbLargSize.Tag); 
            }
            else if (rbSmallSize.Checked) 
            {
                return Convert.ToSingle(rbSmallSize.Tag);
            }
            else
            {
                return Convert.ToSingle(rbMeduimSize.Tag);
            }
        }
        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + GetSelectedToppingsPrice() + GetSelectedCrustPrice();
        }
        void UpdateWhereToEat()
        {
            if(rbTakeOUT.Checked)
            {
                lblWhereToEatSummary.Text = rbTakeOUT.Text;
            }
            else
            {
                lblWhereToEatSummary.Text = rbEatIN.Text;
            }
        }
        void UpdateTotalPrice()
        {
            lblPrice.Text = "$" + CalculateTotalPrice().ToString();
        }
        void UpdateSize()
        {
            UpdateTotalPrice();

            if(rbSmallSize.Checked) 
            {
                lblSizeSummary.Text = rbSmallSize.Text; 
            }

            if(rbMeduimSize.Checked)
            {
                lblSizeSummary.Text = rbMeduimSize.Text;
            }
            
            if(rbLargSize.Checked)
            {
                lblSizeSummary.Text = rbLargSize.Text;
            }
        }
        void UpdateCrust()
        {
            UpdateTotalPrice();

            if (rbThinType.Checked)
            {
                lblCrustTypeSummary.Text = rbThinType.Text;
            }

            if (rbThickType.Checked)
            {
                lblCrustTypeSummary.Text = rbThickType.Text;
            }

        }
        void UpdateToppings()
        {
            string sToppings = String.Empty;

            if (chkGreenPeppers.Checked)
            {
                sToppings += ", " + chkGreenPeppers.Text;
            }

            if (chkExtraChees.Checked)
            {
                sToppings += ", " + chkExtraChees.Text;
            }

            if (chkMushrooms.Checked)
            {
                sToppings += ", " + chkMushrooms.Text;
            }

            if (chkOlives.Checked)
            {
                sToppings += ", " + chkOlives.Text;
            }

            if (chkOnion.Checked)
            {
                sToppings += ", " + chkOnion.Text;
            }

            if (chkTomatoes.Checked)
            {
                sToppings += ", " + chkTomatoes.Text;
            }

            if(sToppings.StartsWith(","))
            {
                sToppings = sToppings.Substring(1, sToppings.Length-1);
            }

            if(sToppings == string.Empty)
            {
                sToppings = "No Toppings";
            }

            lblToppingsSummary.Text = sToppings;
        }
        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }
        private void btnResetForm_Click(object sender, EventArgs e)
        {

            chkExtraChees.Checked = false;
            chkGreenPeppers.Checked = false;    
            chkMushrooms.Checked = false;   
            chkOlives.Checked = false;
            chkTomatoes.Checked = false;
            chkOnion.Checked = false;   

            rbTakeOUT.Checked = false;
            rbEatIN.Checked = true;

            rbLargSize.Checked = false;
            rbSmallSize.Checked = false;


            rbMeduimSize.Checked = true;
            rbThickType.Checked = false;
            rbThinType.Checked = false; 

            lblCrustTypeSummary.Text = string.Empty;
            lblSizeSummary.Text = string.Empty;
            lblToppingsSummary.Text = string.Empty;
            lblWhereToEatSummary.Text = string.Empty;



        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rbMeduimSize.Checked = true; 
            rbThickType.Checked = true;
            UpdateOrderSummary();
        }
        private void rbSmallSize_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }
        private void rbLargSize_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }
        private void rbMeduimSize_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }
        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grCrust.Enabled = false;
                grSize.Enabled = false;
                grToppings.Enabled = false;
                grWhereToEat.Enabled = false;
                btnOrderPizza.Enabled = false;
            }
        }
        private void rbThickType_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }
        private void rbThinType_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }
        private void rbTakeOUT_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }
        private void rbEatIN_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }
    }
}
