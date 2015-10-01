using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace NIC
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Calcuulator();
        }

        private void txtnic_TextChanged(object sender, EventArgs e)
        {
            if(txtnic.TextLength==9)
            {
                Calcuulator();
            }
            else
            {
                txtdob.Text = "";
                txtgender.Text = "";
                txterror.Text = "";
                picGender.ImageLocation = "";
            }
        }

        private void Calcuulator()
        {
            String sNICNo = txtnic.Text;//Getting The Entered NIC Number 
            String sYear = "";
            String sMonth = "";
            int iDay = 0;
            string gender = "";

            if (sNICNo.Length == 9)//Validate 1::Checking The Length Of The NIC Entered
            
            {
                sNICNo = sNICNo.Substring(0, 9);
                bool bchk9 = Int32.TryParse(sNICNo, out iDay);
                if (bchk9)//Validate 2::Checking The First Nine Digit Of The NIC Entered Are Integers
                {
                    sYear = "19"+sNICNo.Substring(0, 2);//Saving The Year
                    sNICNo = sNICNo.Substring(2, 3);
                    iDay = int.Parse(sNICNo);
                    if (iDay > 500)
                    {
                        iDay = iDay - 500;
                        gender = "Female";
                    }
                    else
                    {
                        gender = "Male";
                    }
                    if (iDay > 366 || iDay == 0)//Validate 3::Validating The Days In The Entered NIC
                    {
                        txterror.Text = "Please Enter A Valid NIC No";
                    }
                    else
                    {
                        if (iDay > 335)
                        {
                            iDay = iDay - 335;
                            sMonth = "December";
                        }
                        else if (iDay > 305)
                        {
                            iDay = iDay - 305;
                            sMonth = "November";
                        }
                        else if (iDay > 274)
                        {
                            iDay = iDay - 274;
                            sMonth = "October";
                        }
                        else if (iDay > 244)
                        {
                            iDay = iDay - 244;
                            sMonth = "September";
                        }
                        else if (iDay > 213)
                        {
                            iDay = iDay - 213;
                            sMonth = "Auguest";
                        }
                        else if (iDay > 182)
                        {
                            iDay = iDay - 182;
                            sMonth = "July";
                        }
                        else if (iDay > 152)
                        {
                            iDay = iDay - 152;
                            sMonth = "June";
                        }
                        else if (iDay > 121)
                        {
                            iDay = iDay - 121;
                            sMonth = "May";
                        }
                        else if (iDay > 91)
                        {
                            iDay = iDay - 91;
                            sMonth = "April";
                        }
                        else if (iDay > 60)
                        {
                            iDay = iDay - 60;
                            sMonth = "March";
                        }
                        else if (iDay < 32)
                        {
                            sMonth = "January";
                        }
                        else if (iDay > 31)
                        {
                            iDay = iDay - 31;
                            sMonth = "Febuary";
                        }

                        txtdob.Text = iDay + " - " + sMonth + " - " + sYear;
                        txtgender.Text = gender;
                        picGender.ImageLocation = gender == "Male" ? "male.png" : "female.png"; 
                    }                    
                }
                else
                {
                    txterror.Text = "Please Enter A Valid NIC No";
                }
            }
            else
            {
                txterror.Text = "Please Enter A Valid NIC No";
            }
        }
    }
}
