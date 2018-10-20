using NathanSacconAssignment4.NSClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// NathanSacconAssignment4
//
// Purpose: To showcase the class NSProvinces
//
// Revision History:
//                  Nathan Saccon: March 19, 2018: Finished the coding
//                  Nathan Saccon: March 26, 2018: Finalized and documentation added.
//

namespace NathanSacconAssignment4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // fieldsToProvince() returns a province with the data from the form
        public NSProvince fieldsToProvince()
        {
            string record = $"{txtProvinceCode.Text}::" +
                $"{txtProvinceName.Text}::" +
                $"{txtCountryCode.Text}::" +
                $"{txtTaxCode.Text}::" +
                $"{txtTaxRate.Text}::" +
                $"{chkIncludesFederalTax.Checked}";
            NSProvince province = new NSProvince();
            return province.NSParseProvince(record);
        }
        // clearAllTextboxes() clears all textboxes
        private void clearAllTextboxes()
        {
            txtProvinceCode.Text = "";
            txtProvinceName.Text = "";
            txtCountryCode.Text = "";
            txtTaxCode.Text = "";
            txtTaxRate.Text = "";
            chkIncludesFederalTax.Checked = false;
        }
        // btnNewRecord_Click() Will add a new province to the listbox
        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            try
            {
                NSProvince province = fieldsToProvince();
                province.NSAdd();
                Form1_Load(sender, e);
                clearAllTextboxes();
                txtProvinceList.SelectedIndex = -1;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // btnClose_Click() Closes the form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Form1_Load() Gets province data from file and populates listbox
        private void Form1_Load(object sender, EventArgs e)
        {
            writeLegend();
            txtProvinceList.Items.Clear();
            NSProvince province = new NSProvince();
            foreach (NSProvince currentProvince in province.NSGetProvinces())
            {
                txtProvinceList.Items.Add(currentProvince.ProvinceCode);
            }
        }
        // txtProvinceList_SelectedIndexChanged() Updates form data to match selected item in listbox
        private void txtProvinceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearAllTextboxes();
            string currentCode = txtProvinceList.GetItemText(txtProvinceList.SelectedItem);
            NSProvince province = new NSProvince();
            string[] fields = province.NSGetByProvinceCode(currentCode).ToString().Split(new string[] { "::" }, StringSplitOptions.None);
            txtProvinceCode.Text = fields[0];
            txtProvinceName.Text = fields[1];
            txtCountryCode.Text = fields[2];
            txtTaxCode.Text = fields[3];
            txtTaxRate.Text = fields[4];
            if (Convert.ToBoolean(fields[5]))
            {
                chkIncludesFederalTax.Checked = true;
            }

        }
        // btnSave_Click() Will save the changes to an existing record
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                NSProvince province = fieldsToProvince();
                province.NSUpdate();
                Form1_Load(sender, e);
                clearAllTextboxes();
                txtProvinceList.SelectedIndex = txtProvinceList.Items.IndexOf(province.ProvinceCode);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        // btnDelete_Click() Will delete a province from the listbox
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                fieldsToProvince().NSDelete();
                Form1_Load(sender, e);
                clearAllTextboxes();
                txtProvinceList.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // btnClear_Click() Clears all textboxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAllTextboxes();
        }
        // Writes the legend
        private void writeLegend()
        {
            txtLegend.Text = "Clear All: clears all textboxes\n\n" +
                "New Record(Add) will save a new record after you clear and fill out the forms.\n" +
                "(This doesn't exactly match the rubric, but the example in the assignment doesn't even include an 'Add' button so it was very unclear as to what 'Add' even meant.)\n\n" +
                "Save: will update a record after the inforamtion is changed\n\n" +
                "Delete: will delete the current record.\n\n" +
                "Close: will close the form.";
        }
        
    }
}
