using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// NSValidations.cs
//
// Purpose: to obtain a validations class to use moving forward in the program.
//
// Revision History:
//      Nathan Saccon, 2018.04.07: Created
//      Nathan Saccon, 2018.04.08: Finished
//
namespace NathanSacconAssignment5.NSUtilityClasses
{
    public static class NSValidations
    {
        #region 1. Canada Postal Code Validation
        /// <summary>
        /// Returns a boolean based on is Value is a Canadian Postal Code
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean PostalCodeCanadaValidate(String value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return true;
            }
            value = NSStringUtilities.PostalCodeCanadaFormat(value);
            if (value == null)
            {
                return false;
            }else
            {
                return true;
            }
        }
        #endregion

        #region 2. USA ZIP Code Validation
        /// <summary>
        /// Returns a boolean based on is Value is a USA ZIP Code
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// RETURNS TRUE WHEN GIVEN NULL TO STAY CONSISTENT WITH POSTAL CODE
        public static Boolean ZIPCodeUSAValidate(String value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return true;
            }
            value = NSStringUtilities.ZIPCodeUSAFormat(value);
            if (value == null)
            {
                return false;
            }else
            {
                return true;
            }
        }

        #endregion

        #region 3. Telephone Number Validate
        /// <summary>
        /// Returns a boolean based on is Value is a Phone Number
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// /// RETURNS TRUE WHEN GIVEN NULL TO STAY CONSISTENT WITH POSTAL CODE
        public static Boolean TelephoneNumberValidate(String value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return true;
            }
            value = NSStringUtilities.TelephoneNumberFormat(value);
            if(value == null) 
            {
                return false;
            }else if (value.Length == 12) // 12 because above method adds dashes
            {
                return true;
            } else
            {
                return false;
            }
        }

        #endregion

    }
}
