using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Net.Cache;
using System.Security.Policy;

namespace _07LaboratoryExercise
{
    class ClubRegistrationQuery
    {
        // Adds #5
        private SqlConnection sqlConnect = new SqlConnection(connectionString);
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapater;
        private SqlDataReader sqlReader;

        // Dili diay e static ang variable para matawag didto sa FrmClubRegistration
        public DataTable dataTable = new DataTable();
        public BindingSource bindingSource = new BindingSource();

        // adds #5 b. establish local connection
        private static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\CLAB1-\\Documents\\07LaboratoryExercise\\ClubDB.mdf;Integrated Security=True;";
      
        public string _FirstName, _MiddleName, _LastName, _Gender, _Program;
        public int _Age;

        // Initialize DataTable and DataSource (kulang? Hmmm)

        // adds #7
        public void DisplayList()
        {
            // dapat sa constructor class ni(kanang naa sa taas) pero ambot nganong dili ma invoke/tawag. Maong dri nlng ibutang
            new SqlConnection(connectionString);

            // adds #7 a.
            string ViewClubMembers = "SELECT StudentId, FirstName, MiddleName, LastName, Age, Gender, Program FROM ClubMembers";

            // adds #7 b.
            sqlAdapater = new SqlDataAdapter(ViewClubMembers, connectionString);

            // adds #7 c.
            dataTable.Clear();
            sqlAdapater.Fill(dataTable);
            bindingSource.DataSource = dataTable; 
        }

        // adds #8
        public bool RegisterStudent(int ID, long StudentID, string FirstName, string
            MiddleName, string LastName, int Age, string Gender, string Program)
        {
            sqlCommand = new SqlCommand("INSERT INTO ClubMembers VALUES(@ID, @StudentID, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Program)", sqlConnect);
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            sqlCommand.Parameters.Add("@RegistrationID", SqlDbType.BigInt).Value = StudentID;
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = StudentID;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            return true; // Dapat ka mag return og value so return true 

        }

        public void IdSelect(ComboBox cb)
        {
            string selectId = "SELECT StudentId FROM ClubMembers ";
            sqlCommand = new SqlCommand(selectId, sqlConnect);
            sqlCommand.CommandText = selectId;
            sqlConnect.Open();
            sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                cb.Items.Add(sqlReader["StudentId"].ToString());
            }
            sqlConnect.Close();

        }

        public void AutoSearch(TextBox tbFirstName, TextBox tbMiddleName, TextBox tbLastName, TextBox tbAge, ComboBox cbGender, ComboBox cbProgram, int ID)
        {
            string selectId = "SELECT FirstName,MiddleName,LastName,Age,Gender,Program FROM ClubMembers WHERE StudentId = @ID ";
            sqlCommand = new SqlCommand(selectId, sqlConnect);
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            sqlCommand.CommandText = selectId;
            sqlConnect.Open();
            sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                tbFirstName.Text = (sqlReader["FirstName"].ToString());
                tbMiddleName.Text = (sqlReader["MiddleName"].ToString());
                tbLastName.Text = (sqlReader["LastName"].ToString());
                tbAge.Text = (sqlReader["Age"].ToString());
                cbGender.Text = (sqlReader["Gender"].ToString());
                cbProgram.Text = (sqlReader["Program"].ToString());
            }
            sqlConnect.Close();
        }

        public void UpdateStudent(long StudentID, string FirstName, string
                                 MiddleName, string LastName, int Age, string Gender, string Program)
        {
            sqlCommand = new SqlCommand("UPDATE ClubMembers SET FirstName = @FirstName,MiddleName = @MiddleName,LastName= @LastName,Age= @Age,Gender= @Gender,Program= @Program WHERE StudentId = @StudentID", sqlConnect);

            sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = StudentID;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;
            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }


    }


}
