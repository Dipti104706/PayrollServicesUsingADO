using System;
using System.Data.SqlClient;

namespace PayrollServicesUsingADO
{
    public class EmployeeRepository
    {
        //Connecting to Database
        public static string connectionString = @"Data Source = (localdb)\ProjectsV13;Initial Catalog = payroleserviceADO; Integrated Security = True";
        //passing the string to sqlconnection to make connection 
        SqlConnection sqlconnection = new SqlConnection(connectionString);
    }
}
