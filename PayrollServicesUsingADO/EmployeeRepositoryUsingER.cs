using System;
using System.Data.SqlClient;

namespace PayrollServicesUsingADO
{
    class EmployeeRepositoryUsingER
    {
        public static string connection = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=payroleservice;Integrated Security=True";
        //Connecting to sql server
        SqlConnection sqlConnection = new SqlConnection(connection);

        //Create Object for EmployeeData Repository
        ERModel employeeModel = new ERModel();

        //UC9 Impliment ER diagram 
        public void RetrieveAllEmployeeDetails()
        {
            try
            {
                //Open Connection
                sqlConnection.Open();
                //Inner join query
                string query = @"select EmployeeId,EmployeeName,Gender,EmployeePhoneNumber,EmployeeAddress,StartDate,payroll.BasicPay,TaxablePay,IncomeTax,Deductions,NetPay,department_table.DeptName,company.company_Id,company.company_name 
                                from Employee
                                inner join company on company.company_Id = Employee.CompanyId
                                inner join payroll on payroll.EmpId = Employee.EmployeeId
                                inner join emp_Dept on Employee.EmployeeId = emp_Dept.EmpId
                                inner join department_table on department_table.DepartmentId = emp_Dept.DeptId;";
                //Passing the query and connection
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                //Check if rows
                if (reader.HasRows)
                {
                    //Read each row
                    while (reader.Read())
                    {
                        employeeModel.Id = Convert.ToInt32(reader["EmployeeId"] == DBNull.Value ? default : reader["EmployeeId"]);
                        employeeModel.Name = reader["EmployeeName"] == DBNull.Value ? default : reader["EmployeeName"].ToString();
                        employeeModel.Emp_Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
                        employeeModel.PhoneNumber = Convert.ToDouble(reader["EmployeePhoneNumber"] == DBNull.Value ? default : reader["EmployeePhoneNumber"]);
                        employeeModel.Address = reader["EmployeeAddress"] == DBNull.Value ? default : reader["EmployeeAddress"].ToString();
                        employeeModel.Start_Date = (DateTime)(reader["StartDate"] == DBNull.Value ? default(DateTime) : reader["StartDate"]);
                        employeeModel.Basic_Pay = Convert.ToDouble(reader["BasicPay"] == DBNull.Value ? default : reader["BasicPay"]);
                        employeeModel.Taxable_Pay = Convert.ToDouble(reader["TaxablePay"] == DBNull.Value ? default : reader["TaxablePay"]);
                        employeeModel.Income_Tax = Convert.ToDouble(reader["IncomeTax"] == DBNull.Value ? default : reader["IncomeTax"]);
                        employeeModel.Deduction = Convert.ToDouble(reader["Deductions"] == DBNull.Value ? default : reader["Deductions"]);
                        employeeModel.Net_Pay = Convert.ToDouble(reader["NetPay"] == DBNull.Value ? default : reader["NetPay"]);
                        employeeModel.Department = reader["DeptName"] == DBNull.Value ? default : reader["DeptName"].ToString();
                        employeeModel.CompanyID = Convert.ToInt32(reader["company_Id"] == DBNull.Value ? default : reader["company_Id"]);
                        employeeModel.CompanyName = reader["company_name"] == DBNull.Value ? default : reader["company_name"].ToString();
                        Console.WriteLine("{0} {1} {2}  {3} {4} {5}  {6}  {7} {8} {9} {10} {11} {12} {13}", employeeModel.Id, employeeModel.Name, employeeModel.Emp_Gender, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Start_Date, employeeModel.Basic_Pay, employeeModel.Taxable_Pay, employeeModel.Income_Tax, employeeModel.Deduction, employeeModel.Net_Pay, employeeModel.Department, employeeModel.CompanyID, employeeModel.CompanyName);
                        Console.WriteLine("\n");
                    }
                    //Close SQLDataReader Connection
                    reader.Close();
                }
                //Close Connection
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
