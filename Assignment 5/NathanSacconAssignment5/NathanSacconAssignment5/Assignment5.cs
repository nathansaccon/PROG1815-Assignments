using NathanSacconAssignment5.NSUtilityClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Form1.cs
//
// Purpose: to show utilities classes to prove they work.
//
// Revision History:
//      Nathan Saccon, 2018.04.07: Created
//      Nathan Saccon, 2018.04.08: Finished
//

namespace NathanSacconAssignment5
{
    public partial class Assignment5 : Form
    {
        public Assignment5()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            #region NSNumericUtilitiesClass

            // IsNumeric Test
            lblIsNumericString.Text = NSNumericUtilities.IsNumeric(txtIsNumeric.Text).ToString();
            lblIsNumericString.Visible = true;
            // IsInteger Test
            lblIsIntegerString.Text = NSNumericUtilities.IsInteger(txtIsInteger.Text).ToString();
            lblIsIntegerString.Visible = true;

            #region Convert Try Catches
            try
            {
                lblIsNumericDouble.Text = NSNumericUtilities.IsNumeric(Convert.ToDouble(txtIsNumeric.Text)).ToString();
                lblIsNumericDouble.Visible = true;
            }
            catch
            {
                lblIsNumericDouble.Text = "Error";
                lblIsNumericDouble.Visible = true;
            }
            try
            {
                lblIsNumericInt.Text = NSNumericUtilities.IsNumeric(Convert.ToInt32(txtIsNumeric.Text)).ToString();
                lblIsNumericInt.Visible = true;
            }
            catch
            {
                lblIsNumericInt.Text = "Error";
                lblIsNumericInt.Visible = true;
            }
            try
            {
                lblIsNumericChar.Text = NSNumericUtilities.IsNumeric(Convert.ToChar(txtIsNumeric.Text)).ToString();
                lblIsNumericChar.Visible = true;
            }
            catch
            {
                lblIsNumericChar.Text = "Error";
                lblIsNumericChar.Visible = true;
            }
            try
            {
                lblIsIntegerDouble.Text = NSNumericUtilities.IsInteger(Convert.ToDouble(txtIsInteger.Text)).ToString();
                lblIsIntegerDouble.Visible = true;
            } catch
            {
                lblIsIntegerDouble.Text = "Error";
                lblIsIntegerDouble.Visible = true;
            }
            try
            {
                lblIsIntegerChar.Text = NSNumericUtilities.IsInteger(Convert.ToChar(txtIsInteger.Text)).ToString();
                lblIsIntegerChar.Visible = true;
            } catch
            {
                lblIsIntegerChar.Text = "Error";
                lblIsIntegerChar.Visible = true;
            }
            try
            {
                lblIsIntegerInt.Text = NSNumericUtilities.IsInteger(Convert.ToInt32(txtIsInteger.Text)).ToString();
                lblIsIntegerInt.Visible = true;
            }
            catch
            {
                lblIsIntegerInt.Text = "Error";
                lblIsIntegerInt.Visible = true;
            }
            #endregion

            // SiphonNumber Test
            lblSiphonNumber.Text = NSNumericUtilities.SiphonNumber(txtSiphonNumber.Text);
            lblSiphonNumber.Visible = true;

            #endregion

            #region NSStringUtilitiesClass

            // WordCapitalizatoin Test
            lblWordCapitalization.Text = NSStringUtilities.WordCapitalize(txtWordCapitalization.Text);
            lblWordCapitalization.Visible = true;
            // ExtractNumbers Test
            lblExtractNumbers.Text = NSStringUtilities.ExtractNumbers(txtExtractNumbers.Text);
            lblExtractNumbers.Visible = true;
            // TelephoneNumberFormat Test
            lblTelephoneNumberFormat.Text = NSStringUtilities.TelephoneNumberFormat(txtTelephoneNumber.Text);
            lblTelephoneNumberFormat.Visible = true;
            // PostalCodeCanadaFormat Test
            lblPostalCodeCanadaFormat.Text = NSStringUtilities.PostalCodeCanadaFormat(txtPostalCode.Text);
            lblPostalCodeCanadaFormat.Visible = true;
            // ZIPCodeUSAFormat Test
            lblZIPCodeUSAFormat.Text = NSStringUtilities.ZIPCodeUSAFormat(txtZipCode.Text);
            lblZIPCodeUSAFormat.Visible = true;
            // FullName Text 
            lblFullName.Text = NSStringUtilities.FullName(txtFirstName.Text, txtLastName.Text);
            lblFullName.Visible = true;

            #endregion

            #region NSValidations

            // TelephoneNumberValidate Test
            lblTelephoneNumberValidate.Text = NSValidations.TelephoneNumberValidate(txtTelephoneNumber.Text).ToString();
            lblTelephoneNumberValidate.Visible = true;
            //PostalCodeValidate Test
            lblPostalCodeCanadaValidate.Text = NSValidations.PostalCodeCanadaValidate(txtPostalCode.Text).ToString();
            lblPostalCodeCanadaValidate.Visible = true;
            // ZIPCodeUSAValidate Test
            lblZIPCodeUSAValidate.Text = NSValidations.ZIPCodeUSAValidate(txtZipCode.Text).ToString();
            lblZIPCodeUSAValidate.Visible = true;

            #endregion
        }

        private void txtNumericKeyPress_KeyPress(object sender, KeyPressEventArgs e)
        {
            NSNumericUtilities.NumericKeyPress(e);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtIsNumeric.Text = "";
            lblIsNumericString.Text = "";
            txtIsInteger.Text = "";
            lblIsIntegerChar.Text = "";
            lblIsIntegerDouble.Text = "";
            lblIsIntegerString.Text = "";
            txtSiphonNumber.Text = "";
            lblSiphonNumber.Text = "";
            txtNumericKeyPress.Text = "";
            txtWordCapitalization.Text = "";
            lblWordCapitalization.Text = "";
            txtExtractNumbers.Text = "";
            lblExtractNumbers.Text = "";
            txtFirstName.Text = "";
            lblFullName.Text = "";
            txtLastName.Text = "";
            txtTelephoneNumber.Text = "";
            lblTelephoneNumberFormat.Text = "";
            lblTelephoneNumberValidate.Text = "";
            lblPostalCodeCanadaFormat.Text = "";
            lblPostalCodeCanadaValidate.Text = "";
            txtPostalCode.Text = "";
            txtZipCode.Text = "";
            lblZIPCodeUSAFormat.Text = "";
            lblZIPCodeUSAValidate.Text = "";
            lblIsNumericChar.Text = "";
            lblIsNumericDouble.Text = "";
            lblIsNumericInt.Text = "";
            lblIsIntegerInt.Text = "";
        }

        private void btnAutoFillTrue_Click(object sender, EventArgs e)
        {
            txtIsNumeric.Text = "-48.267";
            txtIsInteger.Text = "7";
            txtSiphonNumber.Text = "A1B2C.D3F-";
            txtWordCapitalization.Text = "nOrMaL WOrds, yEaH?";
            txtExtractNumbers.Text = "A1B2C.D3F-";
            txtFirstName.Text = "JiM";
            txtLastName.Text = "SmItH";
            txtTelephoneNumber.Text = "6137700281";
            txtPostalCode.Text = "k7l4t3";
            txtZipCode.Text = "12345";
        }

        private void btnAutoFillFalse_Click(object sender, EventArgs e)
        {
            txtIsNumeric.Text = "A-48.267";
            txtIsInteger.Text = "-12.01A";
            txtSiphonNumber.Text = "A1B2C.D3F--";
            txtWordCapitalization.Text = "nOrMaL WOrds, yEaH?";
            txtExtractNumbers.Text = "A1B2C.D3F--";
            txtFirstName.Text = "";
            txtLastName.Text = "Smith";
            txtTelephoneNumber.Text = "123";
            txtPostalCode.Text = "K7L";
            txtZipCode.Text = "12345-12";
        }
    }
}
