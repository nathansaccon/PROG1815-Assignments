using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

// NSacconAssignment3
//
// Purpose: To practice file IO and exceptions.
//
// Revision History
//      Nathan Saccon, 2018.02.26: Created, Files Open.
//      Nathan Saccon, 2018.02.27: Textbox data validation, display features.
//      Nathan Saccon, 2018.02.28: Final Touches
//      Nathan Saccon, 2018.03.4: Extra features for easy testing/data entry.
//      Nathan Saccon, 2018.03.13: Final documentation.
namespace NSacconAssignment3
{
    public partial class NSacconAssignment3 : Form
    {
        public NSacconAssignment3()
        {
            InitializeComponent();
        }
        // Initialize Variables
        string errors = "";
        StreamWriter writer;
        StreamReader reader;
        // Form1_Load() Sets default filename for ease of testing, and sets up placeholder for date.
        private void Form1_Load(object sender, EventArgs e)
        {
            txtDate_Leave(sender, e);
            txtFilename.Text = "Manu.txt";
        }
        // txtDate_Enter() On enter clears placeholder, and changes font colour to default.
        private void txtDate_Enter(object sender, EventArgs e)
        {
            if (txtDate.Text == "dd/mm/yyyy")
            {
                txtDate.Text = "";
                txtDate.ForeColor = SystemColors.WindowText;
            }
        }
        // txtDate_Leave() On leave if empty, sets up placeholder.
        private void txtDate_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDate.Text))
            {
                txtDate.Text = "dd/mm/yyyy";
                txtDate.ForeColor = Color.LightSlateGray;
            }
        }
        // dateValidation() Returns true if the date is in valid format, and the date is reasonable.
        private bool dateValidation(string date)
        {
            txtDate.Text = (date + "").Trim();
            Regex pattern = new Regex(@"^[0-3][0-9]/[01][0-9]/[12][0-9]{3}$");

            if (pattern.IsMatch(txtDate.Text))
            {
                return true;
            } else
            {
                return false;
            }
        }
        // btnWriteRecord_Click() Validates all applicable text fields, and writes 
        //                        the record to file as long as there are no errors.
        private void btnWriteRecord_Click(object sender, EventArgs e)
        {
            // Perform Validations
            if(lblFileStatus.Text != "Open")
            {
                errors += "You must have an open file to write a record.\n";
            } if (!textboxNumberValidate(txtTransationNumber))
            {
                errors += "Transaction number must be a positive integer.\n";
            } if (!dateValidation(txtDate.Text))
            {
                errors += "Date must be entered as dd/mm/yyyy\n";
            } if (!textboxNumberValidate(txtSerialNumber))
            {
                errors += "Serial number must be a positive integer.\n";
            } if (!textboxCapitalize(txtTool))
            {
                errors += "Tool purchased cannot be empty.\n";
            } if (!textboxCurrencyValidate(txtPrice))
            {
                errors += "Price must be a postitive real number.\n";
            } if (!textboxNumberValidate(txtQuantity))
            {
                errors += "Quantity must be a positive integer.\n";
            }
            // Error handling
            if (errors != "")
            {
                MessageBox.Show(errors, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                focusOnError();
                errors = "";
            }else // If there are no errors
            {
                string record = $"{txtTransationNumber.Text}::{txtDate.Text}::{txtSerialNumber.Text}::{txtTool.Text}::{txtPrice.Text}::{txtQuantity.Text}::{txtAmount.Text}";
                try
                {
                    writer.WriteLine(record);
                    txtDisplayMessage.Text = $"Record with transaction number: {txtTransationNumber.Text} has been successfully added.\n";
                    txtTransationNumber.Text = "";
                    txtDate.Text = "dd/mm/yyyy";
                    txtDate.ForeColor = Color.LightSlateGray;
                    txtSerialNumber.Text = "";
                    txtTool.Text = "";
                    txtPrice.Text = "";
                    txtQuantity.Text = "";
                    txtAmount.Text = "";
                    if (chkAutoUpdate.Checked)
                    {
                        btnDisplayData_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error writing record: {ex.Message}");
                }
            }
        }
        // filenameValidation() Returns true if the file name has a .txt extension with at
        //                      least one letter or digit before the '.'.
        private bool filenameValidation(string filename)
        {
            Regex pattern = new Regex(@"\w.txt$");

            if (String.IsNullOrEmpty(filename))
            {
                return false;
            }else if (!pattern.IsMatch(filename))
            {
                return false;
            } else if (filename.Contains("\\") || filename.Contains("/"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // btnOpenFile_Click() If no file is open, this button opens a file, ready for writing.
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if(lblFileStatus.Text == "Open") // File already open.
            {
                MessageBox.Show("You cannot create or open a file while another file is already open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!filenameValidation(txtFilename.Text))
            {
                MessageBox.Show("Error: Filename must be in valid format with a .txt extension.\n\nExample: 'MyFile.txt'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFilename.Focus();
            }
            else if (radExisting.Checked) // Use existing file
            {
                try
                {
                    if (File.Exists(txtFilename.Text)) // Make sure file exists
                    {
                        writer = new StreamWriter(txtFilename.Text, append: true);
                        lblFileStatus.Text = "Open";
                        lblFileStatus.ForeColor = Color.Green;
                        txtDisplayMessage.Text = "You have successfully opened the file.";
                        txtFilename.ReadOnly = true;
                        if (chkAutoUpdate.Checked)
                        {
                            btnDisplayData_Click(sender, e);
                        }
                    }
                    else // File does not exist
                    {
                        MessageBox.Show("Error: File does not exist. Consider creating it instead.\n","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFilename.Focus();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error creating file: {ex.Message}");
                    writer.Close();
                    return;
                }
            }
            else // Create new file.
            {
                try
                {
                    writer = new StreamWriter(txtFilename.Text, append: false);
                    lblFileStatus.Text = "Open";
                    lblFileStatus.ForeColor = Color.Green;
                    txtDisplayMessage.Text = "You have successfully opened the file.";
                    txtFilename.ReadOnly = true;
                    radExisting.Checked = true;
                    if (chkAutoUpdate.Checked)
                    {
                        btnDisplayData_Click(sender, e);
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show($"Error creating file: {ex.Message}");
                    writer.Close();
                    return;
                }
            }
        }
        // textboxNumberValidate() Returns true if textbox contains positive integer.
        private bool textboxNumberValidate(TextBox textbox)
        {
            string text = (textbox.Text + "").Trim();
            textbox.Text = text;
            Regex pattern = new Regex(@"^\d+$");

            if (String.IsNullOrEmpty(text))
            {
                return false;
            } else if (pattern.IsMatch(text))
            {
                return true;
            }else
            {
                return false;
            }
        }
        // textboxCurrencyValidate() Returns true if value in textbox can be parsed as a double >= 0.
        private bool textboxCurrencyValidate(TextBox textbox)
        {
            string text = (textbox.Text + "").Trim();
            textbox.Text = text;
            try
            {
                double number = double.Parse(text);
                number = Math.Round(number, 2);
                textbox.Text = number.ToString();
                if (number >= 0)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        // updateAmount() Updates amount to be (price * quantity).
        private void updateAmount()
        {
            if (textboxNumberValidate(txtQuantity) && textboxCurrencyValidate(txtPrice))
            {
                try
                {
                    txtAmount.Text = (int.Parse(txtQuantity.Text) * double.Parse(txtPrice.Text)).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"There was an error with the amount: {ex.Message}");
                }
            }else
            {
                txtAmount.Text = "";
            }
        }
        // txtQuantity_TextChanged() Updates amount when quanitity text is changed.
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            updateAmount();
        }
        // txtPrice_Leave() Updates amount when the price textbox is left.
        //      Used 'leave' instead of 'text changed' because text changed was causing issues with decimals.
        private void txtPrice_Leave(object sender, EventArgs e)
        {
            updateAmount();
        }
        // btnAutoFill_Click() Fills textboxes with reasonable random data, so testing isn't as boring.
        private void btnAutoFill_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            txtTransationNumber.Text = random.Next(0,999).ToString();
            txtDate.Text = random.Next(0, 3).ToString()+ random.Next(1, 9).ToString()+ "/0" + random.Next(1, 10).ToString()+ "/20" + random.Next(0, 3).ToString()+ random.Next(0, 10).ToString();
            txtDate.ForeColor = SystemColors.WindowText;
            txtSerialNumber.Text = random.Next(0,9999).ToString();
            string[] someItems = { "Oatmeal", "Sugar", "Milk", "Cereal", "Chicken", "Sea Salt", "Salad", "Water Bottles", "Pure Gold", "Pork", "Bananas", "Corn", "Apples","Hammer","Computer","Bag Of Air",
                "Soap","Chocolate","Paper","Oranges","Pickles","Peanut Butter","Honda Civic","Eggs","Nuts","Beans","Corn","Peppers","Kale","Spinach","Celery","Popcorn", "Levels","Cords","Paper","Rulers","Pens",
                "Pencils","Markers","Coffee","Mulch","Water Fountain","Q-Tips","Shelf","Watch","Video Games","Crock Pot","Blender","Toaster","Microwave","Windex","Silver","Backpack","Cabin Air Filter","Stuff"};
            txtTool.Text = someItems[random.Next(0,someItems.Length)];
            txtPrice.Text = random.Next(0, 100).ToString() + "." + random.Next(11, 99).ToString();
            txtQuantity.Text = random.Next(1,9).ToString();
        }
        // textboxCapitalize() Capitalizes the first letter of each word in the textbox, then returns true if non-empty.
        private bool textboxCapitalize(TextBox textbox)
        {
            string text = (textbox.Text + "").Trim().ToLower();
            string newText = "";

            if (!String.IsNullOrEmpty(text))
            {
                for (int i = 0; i <text.Length; i++)
                {
                    if (i==0 && Char.IsLetter(text[i]))
                    {
                        newText += text[i].ToString().ToUpper();
                    } else if (text[i-1] == ' ' && Char.IsLetter(text[i]))
                    {
                        newText += text[i].ToString().ToUpper();
                    }else
                    {
                        newText += text[i];
                    }
                }
                textbox.Text = newText;
                return true;
            }else
            {
                return false;
            }
        }
        // btnAbout_Click() displays information about the creator.
        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creator: Nathan Saccon\n\nPhone #: 613-770-0281\n\nEmail: nathansaccon10@hotmail.com\n\n", "Author Details", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        // btnCloseFile_Click() If the writer is open, this function closes it.
        private void btnCloseFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblFileStatus.Text == "Open")
                {
                    writer.Close();
                    lblFileStatus.Text = "Closed";
                    lblFileStatus.ForeColor = Color.Red;
                    txtDisplayMessage.Text = "You have successfully closed the file.";
                    txtFilename.ReadOnly = false;
                    txtFilename.Focus();  
                    if (chkAutoUpdate.Checked)
                    {
                        txtDisplayData.Text = "";
                    }
                }else
                {
                    MessageBox.Show("A file must be open in order to close a file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDisplayMessage.Text = "A file must be open in order to close a file.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error closing the file: {ex.Message}");
            }
        }
        // btnDeleteFile_Click() Deletes the currently open file.
        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (lblFileStatus.Text == "Closed")
            {
                MessageBox.Show("You cannot delete a closed file.\nOpen a file to delete it.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }else
            {
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to permanently delete {txtFilename.Text}?", "Just Making Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    btnCloseFile_Click(sender, e);
                    File.Delete(txtFilename.Text);
                    txtDisplayMessage.Text = $"The file {txtFilename.Text} has been successfully deleted.";
                    if (chkAutoUpdate.Checked)
                    {
                        txtDisplayData.Text = "";
                    }
                }
                else
                {
                    txtDisplayMessage.Text = $"The file {txtFilename.Text} was NOT deleted.";
                }
            }
            
        }
        // btnDisplayData_Click() Displays the data into the rich text box
        private void btnDisplayData_Click(object sender, EventArgs e)
        {
            if (lblFileStatus.Text == "Closed")
            {
                MessageBox.Show("You must have an open file to display data.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    if (lblFileStatus.Text == "Open")
                    {
                        writer.Close();
                    }
                    reader = new StreamReader(txtFilename.Text);
                    txtDisplayData.Text = $"{"#".PadRight(10)}{"Purchase-Date".PadRight(15)}{"Serial #".PadRight(12)}{"Manufacturing Tools".PadRight(27)}{"Price".PadRight(15)}{"Qty".PadRight(8)}{"Amount".PadRight(10)}\n{"".PadRight(97, '_')}\n";
                    int records = 0;
                    while (!reader.EndOfStream)
                    {
                        String record = reader.ReadLine();
                        string[] fields = record.Split(new string[] { "::" }, StringSplitOptions.None);
                        txtDisplayData.Text += $"{fields[0].Substring(0, Math.Min(fields[0].Length, 10)).PadRight(10)}" +
                            $"{fields[1].Substring(0, Math.Min(fields[1].Length, 14)).PadRight(15)}" +
                            $"{fields[2].Substring(0, Math.Min(fields[2].Length, 11)).PadRight(12)}" +
                            $"{fields[3].Substring(0, Math.Min(fields[3].Length, 26)).PadRight(27)}" +
                            $"{fields[4].Substring(0, Math.Min(fields[4].Length, 14)).PadRight(15)}" +
                            $"{fields[5].Substring(0, Math.Min(fields[5].Length, 7)).PadRight(8)}" +
                            $"{fields[6].Substring(0, Math.Min(fields[6].Length, 9)).PadRight(10)}\n";
                        records += 1;
                    }
                    txtDisplayData.Text += $"{"".PadRight(97, '_')}";
                    txtDisplayMessage.Text = $"Currently displaying {records} records.";
                    reader.Close();
                    if (lblFileStatus.Text == "Open")
                    {
                        writer = new StreamWriter(txtFilename.Text, append: true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error displaying data: {ex.Message}\n\nConsider creating the file instead.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // btnDeleteRecord_Click() Deletes a record by the transaction number given.
        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (lblFileStatus.Text != "Open")
            {
                MessageBox.Show("You must have an open file in order to delete a record", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (!textboxNumberValidate(txtTransationNumberToDelete))
            {
                MessageBox.Show("Transaction number must be a positive integer.", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    writer.Close();
                    List<string> transactions = new List<string>();
                    List<string> transactionNums = new List<string>();
                    reader = new StreamReader(txtFilename.Text);
                    while (!reader.EndOfStream)
                    {
                        string transaction = reader.ReadLine();
                        string transactionNumber = transaction.Split(new string[] { "::" }, StringSplitOptions.None)[0];
                        if (transactionNumber != txtTransationNumberToDelete.Text)
                        {
                            transactions.Add(transaction);
                        }
                        transactionNums.Add(transactionNumber);
                    }
                    reader.Close();
                    if (transactionNums.Contains(txtTransationNumberToDelete.Text))
                    {
                        writer = new StreamWriter(txtFilename.Text, append: false);
                        foreach (string item in transactions)
                        {
                            writer.WriteLine(item);
                        }
                        txtDisplayMessage.Text = $"Record with transaction number: {txtTransationNumberToDelete.Text} has been successfully deleted.";
                        txtTransationNumberToDelete.Text = "";
                        if (chkAutoUpdate.Checked)
                        {
                            btnDisplayData_Click(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: Transaction Number Does Not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTransationNumberToDelete.Focus();
                    }


                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Error while deleting record: {ex.Message}");
                }
            }
        }
        // txtFilename_Leave() Adds a '.txt' extension to filename if user forgets extension.
        private void txtFilename_Leave(object sender, EventArgs e)
        {
            Regex pattern = new Regex(@".txt$");
            if (!pattern.IsMatch(txtFilename.Text))
            {
                txtFilename.Text = txtFilename.Text + ".txt";
            }
        }
        // chkAutoUpdate_CheckedChanged() If auto-update is turned on, this updates the screen right away.
        private void chkAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoUpdate.Checked)
            {
                if (lblFileStatus.Text == "Open")
                {
                    btnDisplayData_Click(sender, e);
                }
                else
                {
                    txtDisplayData.Text = "";
                }
            }
        }
        // focusOnError() sets focus to the first field in error.
        private void focusOnError()
        {
            if (errors.Contains("open file"))
            {
                txtFilename.Focus();
            }else if (errors.Contains("Transaction"))
            {
                txtTransationNumber.Focus();
            } else if (errors.Contains("dd/mm/yyyy"))
            {
                txtDate.Focus();
            } else if (errors.Contains("Serial"))
            {
                txtSerialNumber.Focus();
            } else if (errors.Contains("Tool"))
            {
                txtTool.Focus();
            } else if (errors.Contains("Price"))
            {
                txtPrice.Focus();
            } else if (errors.Contains("Quantity"))
            {
                txtQuantity.Focus();
            }
        }
        // NSacconAssignment3_FormClosing() If someone closes the program without closing their file, this closes it for them.
        // Prevents data loss.
        private void NSacconAssignment3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lblFileStatus.Text == "Open")
            {
                btnCloseFile_Click(sender, e);
            }
        }
        // lblFileStatus_Click() Makes the word 'Open'/'Closed' a button
        private void lblFileStatus_Click(object sender, EventArgs e)
        {
            if (lblFileStatus.Text == "Closed")
            {
                btnOpenFile_Click(sender, e);
            }else
            {
                btnCloseFile_Click(sender, e);
            }
        }
    }
}
