// NSMember.cs
//
// Purpose: to practice string manipulation and validation.
//
// Revision History:
//      Nathan Saccon, 2018.02.10: Created
//      Nathan Saccon, 2018.02.23: Finalized

// PLEASE READ NOTE BELOW FOR MARKING
// NOTE: This assignment was done from the first .docx file posted on eConestoga.
//       Thus, when I was origianlly writing this file, method names were not given such as XXCapitalize
//      I have done my best to accomidate the new rubric. If possible I request to be marked by the ORIGINAL
//      Rubric. Students who start/finish assignments early should not be punished.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace NSMember
{
    public partial class NSMember : Form
    {
        public NSMember()
        {
            InitializeComponent();
        }
        // String to store error messages.
        string errorMessages = "";
        // nameRequired() adds an error if the member's name is not filled out.
        public void nameRequired()
        {
            if (String.IsNullOrEmpty(txtMemberFirst.Text) || String.IsNullOrWhiteSpace(txtMemberFirst.Text))
            {
                errorMessages += "Member's first name is required.\n";
            } else if (String.IsNullOrEmpty(txtMemberLast.Text) || String.IsNullOrWhiteSpace(txtMemberLast.Text))
            {
                errorMessages += "Member's last name is required.\n";
            }
        }
        // postalInfoRequired() gives an error if there is no email, or no mailing information.
        public void postalInfoRequired()
        {
            if (String.IsNullOrEmpty(txtEmail.Text) && (String.IsNullOrEmpty(txtAddress.Text)
                || String.IsNullOrEmpty(txtCity.Text) || String.IsNullOrEmpty(txtPostalCode.Text)
                || String.IsNullOrWhiteSpace(txtAddress.Text) || String.IsNullOrWhiteSpace(txtCity.Text)
                || String.IsNullOrWhiteSpace(txtPostalCode.Text)))
            {
                errorMessages += "You must provide an email or address, city, and postal code.\n";
            }
        }
        // provinceCodeRequired() gives an error if the province code isn't two letters.
        public void provinceCodeRequired()
        {
            if (!String.IsNullOrEmpty(txtProvinceCode.Text) && (txtProvinceCode.Text.Length != 2))
            {
                errorMessages += "Province code must be a two character province code.\n";
            } else if (!String.IsNullOrEmpty(txtProvinceCode.Text) && (!Char.IsLetter(txtProvinceCode.Text[0]) || !Char.IsLetter(txtProvinceCode.Text[1])))
            {
                errorMessages += "Province code must be a two character province code.\n";
            }
        }
        // postalCodeRequired() validates the postal code and gives error otherwise.
        public void postalCodeRequired()
        {
            string code = txtPostalCode.Text.ToUpper();

            if (!NSPostalCodeValidation(code))
            {
                errorMessages += "Postal code must be valid.\n";
            }
           
        }
        // phoneNumRequired() gives an error if there is no valid phone number
        public void phoneNumRequired()
        {
            string phoneNumber = txtHomePhone.Text.Trim();
            if (!NSPhoneNumberValidation(phoneNumber))
            {
                errorMessages += "You must use a valid 10 digit phone number.\n";
            }
            
        }
        // emailRequired() gives an error if the email is invalid. 
        private void emailRequired()
        {
            string email = txtEmail.Text;

            if (!String.IsNullOrEmpty(email))
            {
                try
                {
                    MailAddress copy = new MailAddress(email);
                } catch
                {
                    errorMessages += "You must use a valid email address.\n";
                }
            }
        }
        // feeRequired() gives an error if the fee is not a double.
        // Didn't use NSIsNumeric, because its useless the way it is implemented in the rubric.
        private void feeRequired()
        {
            string fee = txtFee.Text;

            if (!String.IsNullOrEmpty(fee))
            {
                try
                {
                    double feeDouble = Double.Parse(fee);

                    if (feeDouble < 0)
                    {
                        errorMessages += "Fee must be a number, zero or greater.\n";
                    }
                }
                catch
                {
                    errorMessages += "Fee must be a number, zero or greater.\n";
                }
            }

        }
        // wordCapitalization() capitalizes the first letter of every word in a given textbox.
        private void wordCapitalization (TextBox txtBox)
        {
            string text = txtBox.Text;

            if (!String.IsNullOrEmpty(text))
            {
                txtBox.Text = NSCapitalize(text);
            }
        }
        // memberFullName() writes the member's full name at the top of the form. (Name already valid)
        private string memberFullName()
        {
            string first = txtMemberFirst.Text;
            string last = txtMemberLast.Text;
            string sFirst = txtSpouseFirst.Text;
            string sLast = txtSpouseLast.Text;

            if (String.IsNullOrEmpty(sFirst))
            {
                return (last + ", " + first);
            }else if (String.IsNullOrEmpty(sLast) || (sLast == last)){
                return last + ", " + first + " && " + sFirst;
            }
            else
            {
                return last + ", " + first + " && " + sLast + ", " + sFirst;
            }
        }
        //capitalizeWhole() capitalizes all letters in the given textbox.
        private void capitalizeWhole(TextBox txtBox)
        {
            txtBox.Text = txtBox.Text.ToUpper();
        }
        // addPostalSpace() formats the postal code to "A0A 0A0" format. (it has already been validated)
        private void addPostalSpace()
        {
            string code = txtPostalCode.Text;
            string newPostalCode = "";
            if (code.Length == 6)
            {
                for (int i = 0; i < code.Length; i++)
                {
                    if (i == 3)
                    {
                        newPostalCode += " ";
                    }
                    newPostalCode += code[i];
                }
                txtPostalCode.Text = newPostalCode;
            }
        }
        // addPhoneDash() formats phone number to "000-000-0000" format (already validated)
        private void addPhoneDash()
        {
            string number = txtHomePhone.Text;
            string newNumber = "";

            if (number.Length == 10)
            {
                for (int i = 0; i < number.Length; i++)
                {
                    if (i == 3 || i == 6)
                    {
                        newNumber += "-";
                    }
                    newNumber += number[i];
                }
                txtHomePhone.Text = newNumber;
            }
        }
        // formatFee() formats the fee, by rounding to two decimal places. (Already validated)
        private void formatFee()
        {
            if (!String.IsNullOrEmpty(txtFee.Text))
            {
                try
                {
                    txtFee.Text = Math.Round(Double.Parse(txtFee.Text), 2).ToString();
                }
                catch
                {
                    
                }
            }
        }
        // btnSubmit_Click() Validates and formats all fields, and displays errors.
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Check Requirements - Adds Error Messages
            nameRequired();
            postalInfoRequired();
            provinceCodeRequired();
            postalCodeRequired();
            phoneNumRequired();
            emailRequired();
            feeRequired();
            // Capitalizes Each Word In Selected Text Boxes
            wordCapitalization(txtMemberFirst);
            wordCapitalization(txtMemberLast);
            wordCapitalization(txtSpouseFirst);
            wordCapitalization(txtSpouseLast);
            wordCapitalization(txtAddress);
            wordCapitalization(txtCity);
            // Capitalize Province/Postal Code
            capitalizeWhole(txtProvinceCode);
            capitalizeWhole(txtPostalCode);
            // Add dashes/space to phone number/postal code
            addPostalSpace();
            addPhoneDash();
            // Make Email Lower Case
            txtEmail.Text = txtEmail.Text.ToLower();
            // Round Fee
            formatFee();
            // Add Full Name
            if (!String.IsNullOrEmpty(txtMemberFirst.Text) && (!String.IsNullOrEmpty(txtMemberLast.Text))){ lblFullName.Text = memberFullName();}
            // If there are errors, display them in a messagebox.
            displayErrors();
        }
        //displayErrors() Displays any errors in a message box, and changes focus.
        private void displayErrors()
        {
            if (errorMessages != "")
            {
                MessageBox.Show(errorMessages, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Sets focus to first field that added an error to the list.
                string[] errorKeyWords = { "first", "last", "email or address", "province code", "Postal code", "10 digit", "valid email", "Fee" };
                bool firstFound = false;
                string firstError = "";
                // Set focus to the input with error.
                for (int i = 0; i < errorKeyWords.Length; i++)
                {
                    if (errorMessages.Contains(errorKeyWords[i]))
                    {
                        if (!firstFound)
                        {
                            firstError = errorKeyWords[i];
                            firstFound = true;
                        }
                    }
                }
                if (firstError == "first")
                {
                    txtMemberFirst.Focus();
                }
                else if (firstError == "last")
                {
                    txtMemberLast.Focus();
                }
                else if (firstError == "email or address" && txtEmail.Text == "")
                {
                    txtEmail.Focus();
                }
                else if (firstError == "province code")
                {
                    txtProvinceCode.Focus();
                }
                else if (firstError == "Postal code")
                {
                    txtPostalCode.Focus();
                }
                else if (firstError == "10 digit")
                {
                    txtHomePhone.Focus();
                }
                else if (firstError == "valid email")
                {
                    txtEmail.Focus();
                }
                else if (firstError == "Fee")
                {
                    txtFee.Focus();
                }
                // Resets errore.
                errorMessages = "";
            }
            else
            {
                MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        // btnPreFill_Click() Fills all the fields with poorly formated, valid entries.
        private void btnPreFill_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "1527 sunnyside rd.";
            txtCity.Text = "kingston";
            txtEmail.Text = "NSaccon9163@conestogac.on.ca";
            txtFee.Text = "45.2398";
            txtHomePhone.Text = "6137700281";
            txtMemberFirst.Text = "nAthan";
            txtMemberLast.Text = "sacCon";
            txtPostalCode.Text = "k7L4v4";
            txtProvinceCode.Text = "on";
            txtSpouseFirst.Text = "tIna";
            txtSpouseLast.Text = "smiTh";
        }
        // btnClose_Click() closes the program.
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // NSIsNumeric Returns true only if the string has at least one digit.
        // Optional leading dash and decimal place are irrelevant in context of rubric.
        // Rubric also fails to mention that there cannot be chars that are not digits.
        private bool NSIsNumeric(string str)
        {
            bool numberFound = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    numberFound = true;
                }
            }
            return numberFound;
        }
        // NSIsPhoneNumberValidation Returns true only if the string is a valid phone number.
        private bool NSPhoneNumberValidation(string str)
        {
            Regex pattern = new Regex(@"^[0-9]{3}-?[0-9]{3}-?[0-9]{4}$");

            return pattern.IsMatch(str) || String.IsNullOrEmpty(str);
        }
        // NSIsPostalCodeValidation Returns true only if the string is a valid postal code.
        private bool NSPostalCodeValidation(string str)
        {
            Regex pattern = new Regex(@"^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$", RegexOptions.IgnoreCase);

            return pattern.IsMatch(str) || String.IsNullOrEmpty(str);
        }
        // NSCapitalize accepts a string and returns a string.
        private string NSCapitalize(string str)
        {
            str = (str + "").Trim().ToLower();

            if (!String.IsNullOrEmpty(str))
            {
                string fixedText = "";

                for (int i = 0; i < str.Length; i++)
                {
                    // If first char is letter capitalize it.
                    if (i == 0 && Char.IsLetter(str[i]))
                    {
                        fixedText += str[i].ToString().ToUpper();
                    }
                    // If previous char is a space capitalize the following char
                    else if ((i != 0) && (str[i - 1] == ' ') && (Char.IsLetter(str[i])))
                    {
                        fixedText += str[i].ToString().ToUpper();
                    }
                    // Not eligible for capitalization.
                    else
                    {
                        fixedText += str[i];
                    }
                }
                return fixedText;
            }
            else
            {
                return "";
            }
        }
    }
}
