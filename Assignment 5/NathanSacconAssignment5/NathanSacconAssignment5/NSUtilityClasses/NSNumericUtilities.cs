using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
// NSNumericUtilities.cs
//
// Purpose: to obtain a numeric utilities class to use moving forward in the program.
//
// Revision History:
//      Nathan Saccon, 2018.04.07: Created
//      Nathan Saccon, 2018.04.08: Finished
//
namespace NathanSacconAssignment5.NSUtilityClasses
{
    public static class NSNumericUtilities
    {
        #region 1. IsNumeric
        /// <summary>
        /// Returns true if the value given is numeric.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean IsNumeric(String value)
        {
            Regex pattern = new Regex(@"^-?(\d+\.?\d*|\.\d+)$");
            return pattern.IsMatch(value);
        }
        /// <summary>
        /// Returns true is the value given is numeric.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean IsNumeric(Object value)
        {
            return IsNumeric(value.ToString());
        }
        #endregion

        #region 2. IsInteger
        /// <summary>
        /// Returns true if the value is an integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean IsInteger(String value)
        {
            return IsNumeric(value) && !value.Contains(".");
        }
        /// <summary>
        /// Returns true if the value is an integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean IsInteger(Double value)
        {
            return IsInteger(value.ToString());
        }
        /// <summary>
        /// Returns true if the value is an integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean IsInteger(Object value)
        {
            return IsInteger(value.ToString());
        }
        /// <summary>
        /// Returns true if the value is an integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean IsInteger(Char value)
        {
            return IsInteger(value.ToString());
        }
        #endregion

        #region 3. Siphon Number
        /// <summary>
        /// Returns numeric values in String value. Or null if there are more than one dash or decimal.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String SiphonNumber(String value)
        {
            value = (value + "").Trim();
            Boolean dashFound = false;
            String newValue = "";
            // Return null if there is more than one dash or decimal or value is empty.
            if ((value == "") || 
                (value.IndexOf(".") != value.LastIndexOf(".")) ||
                (value.IndexOf("-") != value.LastIndexOf("-")))
            {
                return null;
            }
            // Iterate through string to find integers, dashes and decimals.
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '-') // Get dash
                {
                    dashFound = true;
                } else if(value[i] == '.') // Get decimal
                {
                    newValue += value[i];
                } else if (IsInteger(value[i])) // Get integers
                {
                    newValue += value[i];
                }
            }
            // If the new string is numeric return it.
            if (IsNumeric(newValue))
            {
                if (dashFound)
                {
                    return "-" + newValue;
                }else
                {
                    return newValue;
                }
            } else
            {
                return null;
            }
        }

        #endregion

        #region 4. Numeric Key Press
        /// <summary>
        /// Will only allow you to enter numeric keys during an event.
        /// </summary>
        /// <param name="e"></param>
        public static void NumericKeyPress(KeyPressEventArgs e)
        {
            if (!IsInteger(e.KeyChar) && !Char.IsControl(e.KeyChar))// Allows backspace.
            {
                e.Handled = true;
            }
        }

        #endregion

    }
}
