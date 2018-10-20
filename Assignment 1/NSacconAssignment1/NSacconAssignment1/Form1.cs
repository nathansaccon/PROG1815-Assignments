// Nathan Saccon (7989163)
// PROG1815 Assignment 1
// February 9, 2018

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSacconAssignment1
{
    public partial class SeatingAssignment : Form
    {
        public SeatingAssignment()
        {
            InitializeComponent();
        }

        // Global variable declarations.
        string[,] seats = new string[5, 3];
        string[] waitList = new string[10];
        string rows = "ABCDE";
        bool isFull = false;
        bool isWaitingFull = false;
        bool playMessage = true;
        
        // seatsFull() updates the boolean 'isFull' depending on whether or not all the seats are full.
        private void seatsFull()
        {
            int seatsEmpty = 0;

            for (int r = 0; r < seats.GetLength(0); r++)
            {
                for (int c = 0; c < seats.GetLength(1); c++)
                {
                    if (String.IsNullOrEmpty(seats[r, c]))
                    {
                        seatsEmpty += 1;
                    }
                }
            }
            if (seatsEmpty == 0)
            {
                isFull = true;
            }else
            {
                isFull = false;
            }
        }

        // waitingListFull() updates the boolean 'isWaitingFull' depending on whether or not all the spots are full.
        private void waitingListFull()
        {
            int spotsEmpty = 0;
            for (int i = 0; i < waitList.Length; i++)
            {
               if (String.IsNullOrEmpty(waitList[i]))
                {
                    spotsEmpty += 1;
                }
            }
            if (spotsEmpty == 0)
            {
                isWaitingFull = true;
            }else
            {
                isWaitingFull = false;
            }
        }

        // btnFillAll_Click fills all the seats with the name 'Nathan'
        private void btnFillAll_Click(object sender, EventArgs e)
        {
            for (int r = 0; r < seats.GetLength(0); r++)
            {
                for (int c = 0; c < seats.GetLength(1); c++)
                {
                    if (String.IsNullOrEmpty(seats[r, c]))
                    {
                        seats[r, c] = "Nathan";
                    }
                }
            }
            isFull = true;
        }

        // btnShowAll_Click displays a list of seats with the name of the person that reserved them, or the word 'EMPTY'
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtBoxShowAll.Text = "";
            for (int r = 0; r < seats.GetLength(0); r++)
            {
                for (int c = 0; c < seats.GetLength(1); c++)
                {
                    // Case where seat is not empty
                    if (!String.IsNullOrEmpty(seats[r, c]))
                    {
                        txtBoxShowAll.Text += seats[r, c] + ": Seat " + rows[r] + c + "\n";
                    } else // Case for empty seat
                    {
                        txtBoxShowAll.Text += "Seat " + rows[r] + c + " is EMPTY\n";
                    }
                }
            }
        }

        // btnStatus_Click updates the text in the status area based on if the seats are full or avalable.
        private void btnStatus_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "";
            seatsFull();

            // Case where no seat is selected
            if (lbxLetters.SelectedIndex == -1 || lbxNumbers.SelectedIndex == -1)
            {
                txtStatus.Text = "Error: Select a row AND a column.";
            } // Case where selected seat is empty.
            else if (String.IsNullOrEmpty(seats[lbxLetters.SelectedIndex, lbxNumbers.SelectedIndex]))
            {
                txtStatus.Text = "This seat is available!";
            }// Case where all the seats are full.
            else if (isFull)
            {
                txtStatus.Text = "All seats are FULL.";
            }else // Case where selected seat is already taken.
            {
                string statusMessage = "This seat is already taken. You may choose from the following seats: ";
                for (int r = 0; r < seats.GetLength(0); r++)
                {
                    for (int c = 0; c < seats.GetLength(1); c++)
                    {
                        if (String.IsNullOrEmpty(seats[r,c]))
                        {
                            statusMessage += rows[r].ToString() + c.ToString() + " ";
                        }
                    }
                }
                txtStatus.Text = statusMessage;
                if (playMessage)
                {
                    MessageBox.Show(statusMessage, "Booking Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // btnWaitList_Click adds the current name to the waitlist, or informs the user that there are still seats available.
        private void btnWaitList_Click(object sender, EventArgs e)
        {
            waitingListFull();
            btnStatus_Click(sender, e);

            // Case where there are still seats avalable.
            if (txtStatus.Text.Contains("available!"))
            {
                if (playMessage)
                {
                    MessageBox.Show("There are still seats available!", "Booking Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // Case where seats are full and waitingList is NOT full
            else if ((txtStatus.Text.Contains("FULL")) && !isWaitingFull)
            {
                for (int i =0; i < waitList.Length; i++)
                {
                    if (String.IsNullOrEmpty(waitList[i]))
                    {
                        waitList[i] = txtName.Text;
                        break;
                    }
                }
                txtStatus.Text += " You have been added to the Waiting List.";
                if (playMessage)
                {
                    MessageBox.Show("You have been added to the Waiting List.", "Waiting List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // Case where seats and waiting list are full.
            else if ((txtStatus.Text.Contains("FULL")) && isWaitingFull)
            {
                txtStatus.Text += " And there is no room left on the waiting list. Please try again later.";
            }

        }

        // btnBook_Click registers the current name to the selected seat, or adds the person to the waitlist.
        private void btnBook_Click(object sender, EventArgs e)
        {
            // Case where name field was left empty
            if (String.IsNullOrEmpty(txtName.Text))
            {
                txtStatus.Text = "You must enter a name.";
                if (playMessage)
                {
                    MessageBox.Show("You must enter a name.", "Booking Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Case where name was entered
            {
                btnStatus_Click(sender, e);
            }
            // Case where selected seat is available.
            if (txtStatus.Text.Contains("available!"))
            {
                seats[lbxLetters.SelectedIndex, lbxNumbers.SelectedIndex] = txtName.Text;
                string statusText = txtName.Text + " is registered to seat " + rows[lbxLetters.SelectedIndex] + lbxNumbers.SelectedIndex;
                txtStatus.Text = statusText;
                if (playMessage)
                {
                    MessageBox.Show(statusText, "Successful Booking", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            } // Case where all seats are full
            else if (txtStatus.Text.Contains("FULL"))
            {
                btnWaitList_Click(sender, e);
            }
        }

        // btnShowWaitList_Click displays a list of everyone currently in the waitlist.
        private void btnShowWaitList_Click(object sender, EventArgs e)
        {
            txtBoxShowWaitList.Text = "";
            for (int i = 0; i < waitList.Length; i++)
            {
                txtBoxShowWaitList.Text += waitList[i] + "\n";
            }
        }

        // btnCancel_Click cancels the booking for the selected seat, or tells user that the seat is not registered.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            waitingListFull();
            txtStatus.Text = "";
            int letterChoice = lbxLetters.SelectedIndex;
            int numChoice = lbxNumbers.SelectedIndex;
            // Case where no seat is selected.
            if (letterChoice == -1 || numChoice == -1)
            {
                txtStatus.Text = "Error: Select a row AND a column.";
                if (playMessage)
                {
                    MessageBox.Show("You must choose a seat to cancel.", "Cancellation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // Case where cancellation is attempted on non-reserved seat.
            else if (String.IsNullOrEmpty(seats[letterChoice, numChoice]))
            {
                txtStatus.Text = "This seat is available! Cancellation request denied.";
            } // Case where waitingList is empty.
            else if (String.IsNullOrEmpty(waitList[0]))
            {
                seats[letterChoice, numChoice] = "";
                string statusText = "The reservation for seat " + rows[letterChoice] + numChoice + " has been cancelled.";
                txtStatus.Text = statusText;
                if (playMessage)
                {
                    MessageBox.Show(statusText, "Successful Cancel", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }else // Case where waitingList has a person waiting.
            {
                // Sets first person in list to the now empty seat.
                string statusText = "The reservation for seat " + rows[letterChoice] + numChoice + " has been cancelled.";
                seats[letterChoice, numChoice] = "";
                txtStatus.Text = statusText;
                seats[letterChoice, numChoice] = waitList[0];
                if (playMessage)
                {
                    MessageBox.Show(statusText, "Successful Cancel", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                // Loop moves everyone up one place in the waiting list.
                for (int i = 0; i < waitList.Length; i++)
                {
                    if ((i != 0) && !String.IsNullOrEmpty(waitList[i]))
                    {
                        waitList[i - 1] = waitList[i];
                    }
                    if ((i != waitList.Length - 1) && String.IsNullOrEmpty(waitList[i+1]))
                    {
                        waitList[i] = "";
                    }
                    if (i == waitList.Length-1)
                    {
                        waitList[i] = "";
                    }
                }
            }
        }
        // cbxHideBoxes_CheckedChanged Disables messageboxes for easier debug.
        private void cbxHideBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxHideBoxes.Checked)
            {
                playMessage = false;
            } else
            {
                playMessage = true;
            }
        }
        // btnFillWaitList_Click Fills the waitingList for debug/testing.
        private void btnFillWaitList_Click(object sender, EventArgs e)
        {
            int spotTrack = 1;
            for (int i = 0; i < waitList.Length; i++)
            {
                if (String.IsNullOrEmpty(waitList[i]))
                {
                    waitList[i] = "Person" + spotTrack.ToString();
                    spotTrack += 1;
                }
            }
        }
        // btnAbout_Click Displays inforamtion about the creator.
        private void btnAbout_Click(object sender, EventArgs e)
        {
            string message = "Creator: Nathan Saccon\nEmail: nathansaccon10@hotmail.com\nPhone #: 613-770-0281";
            MessageBox.Show(message, "About", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
    }
}
