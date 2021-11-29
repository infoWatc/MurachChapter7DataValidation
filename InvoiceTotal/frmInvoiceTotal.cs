/*
 * 1.	Open the application that’s in the \\C#\Chapter 07\InvoiceTotal 
 *		directory. This is the version that you worked on in chapter 4.
 * 
 * 2.	Add a try-catch statement to the btnCalculate_Click() method so
 *		it catches any exception that the ToDecimal() method of the Convert
 *		class might throw. The catch block should display a dialog box like
 *		the one in figure 7-2. Then, test the application to make sure this
 *		works correctly. 
 * 
 * 3.	Add code to the try block that checks that the user enters a value 
 *		in the Subtotal text box. If a value isn’t entered, a dialog box 
 *		should be displayed with a message indicating that Subtotal is a 
 *		required field. Then, test this enhancement.
 * 
 * 4.	Add code to the try block that range checks the user entry so it’s
 *		greater than zero and less than 10,000. If it isn’t, a dialog box 
 *		should be displayed that specifies the acceptable range. Then, test 
 *		this enhancement. When you’re satisfied that the application works 
 *		correctly, close it.
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
	public partial class frmInvoiceTotal : Form
	{
        public frmInvoiceTotal()
		{
			InitializeComponent();
		}

		private void btnCalculate_Click(object sender, EventArgs e)
        {
            ValidateAndWork();                  

        }

        // Validate & Work
        private void ValidateAndWork()
        {
            if (txtSubtotal.Text == "")
            {
                MessageBox.Show(
                    "Subtotal requires a field.",
                    "Entry Error");

            }
            else
            {

                // Custom method to pass through try catch, easy validate to catch exceptions
                try
                {

                    // Validation for negative number and numbers larger than range
                    if  (!(Decimal.Parse(txtSubtotal.Text) > 0))
                    {
                        MessageBox.Show(
                            "Number ar not in range. enter a number 0 - 10,000");                                                    
                    }
                    else if (!(Decimal.Parse(txtSubtotal.Text) < 10001))
                    {
                        MessageBox.Show(
                            "Number to larger, please enter a number to or less than 10,000");
                    }                       
                    else
                    {
                        // Finally Time to do some work Method => Begin
                        DoSomeWorkMethod();

                    }
   

                }

                // Format Exception handling to pop-up Message Box
                catch (FormatException)
                {
                    MessageBox.Show(
                        "A format exception has occured. Please check all entries.",
                        "Entry Error");
                }
                catch (OverflowException) // another exception handling overflows
                {
                    MessageBox.Show(
                        "An overflow exception has occured. Plese enter smaller values.",
                        "Entry Error");
                }
                catch (Exception ex) // all other exceptions
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
                finally  // this code runs whether or not an exception occurs
                {

                }
            }
        }

     
        // Custom Method for doing some work
        private void DoSomeWorkMethod()
        {

            decimal subtotal = Decimal.Parse(txtSubtotal.Text);
            decimal discountPercent = .25m;
            decimal discountAmount = subtotal * discountPercent;
            decimal invoiceTotal = subtotal - discountAmount;

            discountAmount = Math.Round(discountAmount, 2);
            invoiceTotal = Math.Round(invoiceTotal, 2);

            //Using ToString format percentage for one decimal place
            txtDiscountPercent.Text = discountPercent.ToString("p1");

            // Using ToString format for Cash = C stands for $
            txtDiscountAmount.Text = discountAmount.ToString("C");
            txtTotal.Text = invoiceTotal.ToString("C");

            // Focus on txtSubtoal
            txtSubtotal.Focus();
        }

        // Exit Button
        private void btnExit_Click(object sender, EventArgs e)
		{
            // Close Form
			this.Close();
		}

	}
}