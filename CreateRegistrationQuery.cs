using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace _07LaboratoryExercise
{
    class CreateRegistrationQuery
    {

        private static SqlConnection sqlConnect;
        private static SqlCommand sqlCommand;
        private static SqlDataAdapter sqlAdapater;
        private static SqlDataReader sqlReader;

        public static DataTable dataTable;
        public static BindingSource bindingSource;

        private static string connectionString;

        public static string _FirstName, _MiddleName, _LastName, _Gender, _Program;
        public static int _Age;

    }


}
