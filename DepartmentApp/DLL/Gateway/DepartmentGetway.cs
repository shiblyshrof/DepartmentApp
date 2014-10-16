using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentApp.DLL.DAO;

namespace DepartmentApp.DLL.Gateway
{
    class DepartmentGetway
    {
        private SqlConnection connection;
        public DepartmentGetway()
        {
            string conn = @"server=SHIBLY-PC; database=Department; integrated security=true";

            connection = new SqlConnection();

            connection.ConnectionString = conn;
        }

        public string Save(Department aDepartment)
        {
            
            connection.Open();

            string query = string.Format("INSERT INTO t_Department VALUES ('{0}','{1}')", aDepartment.Name, aDepartment.Code);

            SqlCommand command = new SqlCommand(query, connection);
            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)

                return "insert success";

            else
                return "problem";
        }

        public bool HasThisNameValid(string name)
        {
            connection.Open();

            string query = string.Format("SELECT * FROM t_Department WHERE Name='{0}'", name);

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }

        public bool HasThisCodeValid(string code)
        {
            connection.Open();

            string query = string.Format("SELECT * FROM t_Department WHERE code='{0}'", code);

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }

        public List<Department> GetAllStudent()
        {
            connection.Open();

            string query = string.Format("SELECT * FROM t_Department");

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader aReader = command.ExecuteReader();

            List<Department> departments = new List<Department>();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Department aDepartment = new Department();
                    aDepartment.DepartmentId = (int)aReader[0];
                    aDepartment.Name = aReader[1].ToString();
                    aDepartment.Code = aReader[2].ToString();
                    

                    departments.Add(aDepartment);
                }

            }
            connection.Close();
            return departments;

        }
    }
}
