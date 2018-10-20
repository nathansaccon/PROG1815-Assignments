using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
// NSStringUtilities.cs
//
// Purpose: to obtain a string utilities class to use moving forward in the program.
//
// Revision History:
//      Nathan Saccon, 2018.04.07: Created
//      Nathan Saccon, 2018.04.08: Finished
//
namespace NathanSacconAssignment5.NSUtilityClasses
{
    public static class NSStringUtilities
    {
        #region 1. Word Capitalization
        /// <summary>
        /// Returns the string with all words capitalized.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String WordCapitalize(String str)
        {
            str = (str + "").Trim().ToLower();

            if (str != "")
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
                return null;
            }
        }

        #endregion

        #region 2. Extract Numbers
        /// <summary>
        /// Returns all the numbers from the String value as a string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ExtractNumbers(String value)
        {
            value = (value + "").Trim();
            String newValue = "";
            if (value != "") // If starting value is not null.
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (NSNumericUtilities.IsInteger(value[i])) // Add integer values to newValue
                    {
                        newValue += value[i];
                    }
                }
                if (newValue != "") // If new value is not empty return it.
                {
                    return newValue;
                } else // Return null if newValue is empty.
                {
                    return null;
                }
            } else // If starting value is null return null.
            {
                return null;
            }
        }

        #endregion

        #region 3. Standard Formats

        #region a. Telephone Format
        /// <summary>
        /// Returns String value reformatted as a telephone number, or null otherwise.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String TelephoneNumberFormat(String value)
        {
            value = ExtractNumbers(value);
            if (value == null)
            {
                return value;
            } else if (value.Length != 7 && value.Length != 10)
            {
                return null;
            } else
            {
                if (value.Length == 7)
                {
                    value = value.Insert(3, "-");
                    return value;
                } else
                {
                    value = value.Insert(3, "-").Insert(7, "-");
                    return value;
                }
            }
        }

        #endregion

        #region b. Canadian Postal Code Format
        /// <summary>
        /// Returns String value reformatted as a Canadian postal code, or null otherwise.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String PostalCodeCanadaFormat(String value)
        {
            value = (value + "").Trim().ToUpper();
            Regex pattern = new Regex(@"^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][- ]?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$");
            if (!pattern.IsMatch(value)) // Return null if this isn't a postal code.
            {
                return null;
            }else
            {
                String newValue = "";
                // Use loop to remove any extra chars to format newValue as A0A0A0.
                for (int i = 0; i < value.Length; i++)
                {
                    if (Char.IsLetterOrDigit(value[i]))
                    {
                        newValue += value[i];
                    }
                }
                return newValue.Insert(3, " "); //Insert space into correct spot.
            }
        }

        #endregion

        #region c. American ZIP Code Format
        /// <summary>
        /// Returns String value reformatted as a USA zip code, or null otherwise.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ZIPCodeUSAFormat(String value)
        {
            value = ExtractNumbers(value);
            if (value == null || (value.Length != 5 && value.Length != 9))
            {
                return null;
            } else
            {
                if(value.Length == 5)
                {
                    return value;
                }else
                {
                    return value.Insert(5, "-");
                }
            }
        }

        #endregion


        #endregion

        #region 4. Full Name
        /// <summary>
        /// Returns the full name of the person in for Last, First.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public static String FullName(String first, String last)
        {
            first = (first + "").Trim().ToLower();
            last = (last + "").Trim().ToLower();
            if (first == "" && last == "") // If both are null
            {
                return null;
            }else if (first == "" || last == "") // If one is null
            {
                return WordCapitalize(first + last);
            } else // Neither are null
            {
                return WordCapitalize(last + ", " + first);
            }
        }

        #endregion
    }
}
