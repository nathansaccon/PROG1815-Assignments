using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
// NathanSacconAssignment4
//
// Purpose: To practice managing data within a class.
//
// Revision History:
//                  Nathan Saccon: March 19, 2018: Finished the coding
//                  Nathan Saccon: March 26, 2018: Finalized and documentation added.
//

namespace NathanSacconAssignment4.NSClasses
{
    public class NSProvince
    {
        #region Properties
        private string provinceCode, name, countryCode, taxCode;
        private double taxRate;
        private bool includesTaxRate;

        public string ProvinceCode { get => provinceCode; set => provinceCode = value; }
        public string Name { get => name; set => name = value; }
        public string CountryCode { get => countryCode; set => countryCode = value; }
        public string TaxCode { get => taxCode; set => taxCode = value; }
        public double TaxRate { get => taxRate; set => taxRate = value; }
        public bool IncludesTaxRate { get => includesTaxRate; set => includesTaxRate = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        #endregion

        #region Get Methods
        /// <summary>
        /// Returns an NSProvince that matches the string provinceCode or returns Null
        /// </summary>
        /// <param name="provinceCode"></param>
        /// <returns></returns>
        public  NSProvince NSGetByProvinceCode(string provinceCode)
        {
            try
            {
                reader = new StreamReader(fileName);
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    string[] fields = record.Split(new string[] { "::" }, StringSplitOptions.None);
                    if (provinceCode == fields[0])
                    {
                        return NSParseProvince(record);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting province by provinceCode.\n{ex.Message}");
            }
            finally
            {
                reader.Close();
            }
            return null;
                
        }
        /// <summary>
        /// Returns an NSProvince that matches the string provinceName or returns Null
        /// </summary>
        /// <param name="provinceName"></param>
        /// <returns></returns>
        public NSProvince NSGetByProvinceName(string provinceName)
        {
            try
            {
                reader = new StreamReader(fileName);
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    string[] fields = record.Split(new string[] { "::" }, StringSplitOptions.None);
                    if (provinceName == fields[1])
                    {
                        return NSParseProvince(record);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting province by provinceName.\n{ex.Message}");
            }
            finally
            {
                reader.Close();
            }
            return null;

        }
        /// <summary>
        /// Returns a list of all NSProvinces on file
        /// </summary>
        /// <returns></returns>
        public List<NSProvince> NSGetProvinces()
        {
            List<NSProvince> provinceList = new List<NSProvince>();
            try
            {
                reader = new StreamReader(fileName);
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    if (!String.IsNullOrEmpty(record))
                    {
                        provinceList.Add(NSParseProvince(record));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting province list in NSGetProvinces.\n{ex.Message}");
            }
            finally
            {
                reader.Close();
            }
            return provinceList;
        }


        #endregion

        #region Global Variables
        StreamReader reader;
        StreamWriter writer;
        string fileName = "NSProvince.txt";
        private bool isEdit = false;
        #endregion

        #region Add, Update, Delete
        /// <summary>
        /// Adds the NSProvince to the file.
        /// </summary>
        public void NSAdd()
        {
            try
            {
                NSEdit();
                if (!IsEdit)
                {
                    writer = new StreamWriter(fileName, append: true);
                    writer.WriteLine(ToString());
                    writer.Close();
                }
                else
                {
                    throw new Exception("Province is already on file.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding to the file.\n{ex.Message}");
            }
        }
        /// <summary>
        /// Deletes the NSProvince from the file.
        /// </summary>
        public void NSDelete()
        {
            try
            {
                List<string> newFile = new List<string>();
                bool deleteFound = false;
                reader = new StreamReader(fileName);
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    string[] fields = record.Split(new string[] { "::" }, StringSplitOptions.None);
                    if (ProvinceCode != fields[0])
                    {
                        newFile.Add(record);
                    }
                    else
                    {
                        deleteFound = true;
                    }
                }
                reader.Close();
                if (!deleteFound)
                {
                    throw new Exception("Unable to delete non-existant record.");
                }
                else
                {
                    writer = new StreamWriter(fileName, append: false);
                    foreach (string newRecord in newFile)
                    {
                        writer.WriteLine(newRecord);
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading records in NSDelete.\n{ex.Message}");
            }
           
        }
        /// <summary>
        /// Updates an existing record with the new information.
        /// </summary>
        public void NSUpdate()
        {
            NSEdit();

            if (!IsEdit)
            {
                throw new Exception($"Unable to update non-existant record.");
            }
            else
            {
                NSDelete();
                IsEdit = false;
                NSAdd();
            }
        }
            

        #endregion

        #region Utilities: Edit, Parse, ToString
        /// <summary>
        /// Concatinate the properties into a string with dilimeter '::'
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string record = $"{ProvinceCode}::{Name}::{CountryCode}::{TaxCode}::{TaxRate.ToString()}::{IncludesTaxRate.ToString()}";
            return record;
        }
        /// <summary>
        /// Parse a record from the data file into a province object.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public NSProvince NSParseProvince(string record)
        {
            try
            {
                string[] fields = record.Split(new string[] { "::" }, StringSplitOptions.None);
                NSProvince province = new NSProvince();
                province.ProvinceCode = fields[0];
                province.Name = fields[1];
                province.CountryCode = fields[2];
                province.TaxCode = fields[3];
                if (String.IsNullOrEmpty(fields[4]))
                {
                    province.TaxRate = 0;
                }
                else
                {
                    province.TaxRate = Convert.ToDouble(fields[4]);
                }
                province.IncludesTaxRate = Convert.ToBoolean(fields[5]);
                return province;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error parsing province data in NSParseProvince.\n{ex.Message}");
            }
        }
        /// <summary>
        /// Validates and reformats fields. 
        /// </summary>
        private void NSEdit()
        {
            string errors = "";
            Regex pattern = new Regex("^[A-Z][A-Z]$");
            Regex patternTwo = new Regex("^[A-Z][A-Z]+$");
            ProvinceCode = (ProvinceCode + "").Trim();
            ProvinceCode = ProvinceCode.ToUpper();
            Name = (Name + "").Trim();
            CountryCode = (CountryCode + "").Trim();
            CountryCode = CountryCode.ToUpper();
            TaxCode = (TaxCode + "").Trim();
            TaxCode = TaxCode.ToUpper();
            if(Name == "")
            {
                errors += "Name field cannot be empty.\n";
            } if (!pattern.IsMatch(ProvinceCode))
            {
                errors += "Province Code field must be exactly two letters.\n";
            }
            if (!pattern.IsMatch(CountryCode))
            {
                errors += "Country Code field must be exactly two letters.\n";
            }
        
            foreach (NSProvince province in NSGetProvinces())
            {
                if(province.ProvinceCode == ProvinceCode)
                {
                    IsEdit = true;
                }else if(province.Name == Name)
                {
                    errors += "Error editing file, name already in use for another province.\n";
                }
            }

            if (TaxCode != "")
            {
                if (!patternTwo.IsMatch(TaxCode))
                {
                    errors += "Tax Code field must be empty or contain letters only.\n";
                } else if (TaxRate < 0 || TaxRate > 1)
                {
                    errors += "Tax Rate field must be between 0 and 1 inclusive.\n";
                }
            }
            else
            {
                if (TaxRate != 0)
                {
                    errors += "If Tax Code field is empty Tax Rate must be 0.\n";
                }
            }

            if (TaxRate == 0 && IncludesTaxRate)
            {
                errors += "If tax rate is 0, the tax rate must not include tax.\n";
            }

            if (errors != "")
            {
                throw new Exception(errors);
            }
        }

        #endregion

    }
}
