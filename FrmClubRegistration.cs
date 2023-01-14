using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07LaboratoryExercise
{
    public partial class FrmClubRegistration : Form
    {

        // adds #9 
        private ClubRegistrationQuery clubRegistrationQuery = new ClubRegistrationQuery();
        private static int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentID;

        public FrmClubRegistration()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            // add #11
            RefreshListOfClubMembers();
        }

        // add #10
        public void RefreshListOfClubMembers()
        {

            // add #10 a. 
            clubRegistrationQuery.DisplayList();

            // add #10 b.
            dgvClubMembers.DataSource = clubRegistrationQuery.bindingSource;

        }

        // adds #12 
        public int RegistrationID()
        {
            count++;
            return count;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // adds #13
            ID = RegistrationID();

            StudentID = Convert.ToInt32(txtStudentID.Text);

            FirstName = txtFirstName.Text;
            MiddleName = txtMiddleName.Text;
            LastName = txtLastName.Text;

            Gender = cbGender.Text;
            Program = cbProgram.Text;

            Age = Convert.ToInt32(txtAge.Text);


            clubRegistrationQuery.RegisterStudent(ID, StudentID, FirstName, MiddleName, LastName, Age, Gender, Program);
            RegistrationID();

            // adds #14

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmUpdateMember frmUpdateMember = new FrmUpdateMember();
            frmUpdateMember.Show();
        }

       
       
    }
}
