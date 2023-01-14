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
    public partial class FrmUpdateMember : Form
    {

        ClubRegistrationQuery clubRegistrationQuery = new ClubRegistrationQuery(); 
        public FrmUpdateMember()
        {
            InitializeComponent();

            clubRegistrationQuery.IdSelect(cbStudentID);
            
        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery.IdSelect(cbStudentID);
        }

        private void cbStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            clubRegistrationQuery.AutoSearch(txtFirstName, txtMiddleName, txtLastName, txtAge, cbGender, cbProgram, Convert.ToInt32(cbStudentID.Text));
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            clubRegistrationQuery.UpdateStudent(Convert.ToInt32(cbStudentID.Text), txtFirstName.Text, txtLastName.Text, txtMiddleName.Text, Convert.ToInt32(txtAge.Text), cbGender.Text, cbProgram.Text);
            FrmClubRegistration frmClubRegistration = new FrmClubRegistration();
            frmClubRegistration.RefreshListOfClubMembers();
        }
    }
}
