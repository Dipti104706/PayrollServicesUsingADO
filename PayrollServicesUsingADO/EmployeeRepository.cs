using System;
using System.Data;
using System.Data.SqlClient;

namespace PayrollServicesUsingADO
{
    public class EmployeeRepository
    {
        //Connecting to Database
        public static string connectionString = @"Data Source = (localdb)\ProjectsV13;Initial Catalog = payroleserviceADO; Integrated Security = True";
        //passing the string to sqlconnection to make connection 
        SqlConnection sqlconnection = new SqlConnection(connectionString);

        //Uc2/////
        //GetAllEmployee method
        public void GetAllEmployee()
        {
            try
            {
                //Creating object for employeemodel and access the fields
                EmployeeModel employeeModel = new EmployeeModel();
                //Retrieve query
                string query = @"select * from employee_payroll";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                //Open the connection
                this.sqlconnection.Open();
                //ExecuteReader: Returns data as rows.
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeModel.EmployeeId = Convert.ToInt32(reader["id"] == DBNull.Value ? default : reader["id"]);
                        employeeModel.EmployeeName = reader["name"] == DBNull.Value ? default : reader["name"].ToString();
                        employeeModel.BasicPay = Convert.ToDouble(reader["Base_Pay"] == DBNull.Value ? default : reader["Base_Pay"]);
                        employeeModel.StartDate = (DateTime)(reader["startDate"] == DBNull.Value ? default(DateTime) : reader["startDate"]);
                        employeeModel.Gender = reader["gender"] == DBNull.Value ? default : reader["gender"].ToString();
                        employeeModel.Department = reader["department"] == DBNull.Value ? default : reader["department"].ToString();
                        employeeModel.PhoneNumber = Convert.ToDouble(reader["phone"] == DBNull.Value ? default : reader["phone"]);
                        employeeModel.Address = reader["address"] == DBNull.Value ? default : reader["address"].ToString();
                        employeeModel.Deductions = Convert.ToDouble(reader["Deductions"] == DBNull.Value ? default : reader["Deductions"]);
                        employeeModel.TaxablePay = Convert.ToDouble(reader["TaxablePay"] == DBNull.Value ? default : reader["TaxablePay"]);
                        employeeModel.IncomeTax = Convert.ToDouble(reader["IncomeTax"] == DBNull.Value ? default : reader["IncomeTax"]);
                        employeeModel.NetPay = Convert.ToDouble(reader["NetPay"] == DBNull.Value ? default : reader["NetPay"]);
                        Console.WriteLine("{0} {1} {2}  {3} {4} {5}  {6}  {7} {8} {9} {10} {11}", employeeModel.EmployeeId, employeeModel.EmployeeName, employeeModel.BasicPay, employeeModel.StartDate, employeeModel.Gender, employeeModel.Department, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Deductions, employeeModel.TaxablePay, employeeModel.IncomeTax, employeeModel.NetPay);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("No data found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }

        //Uc3 to updated salary of perticular person
        public void UpdateSalary()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                sqlconnection.Open();
                string query = @"update employee_payroll set Base_pay=3000000 where name='Terissa'";
                SqlCommand command = new SqlCommand(query, sqlconnection);

                int result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    Console.WriteLine("Salary Updated Successfully ");
                }
                else
                {
                    Console.WriteLine("Unsuccessfull");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlconnection.Close();

            }
        }

        //UC4 Update salary using Stored procedure
        public string UpdateSalaryUsingStoredProcedure(EmployeeModel model)
        {
            try
            {
                using (this.sqlconnection)
                {
                    SqlCommand command = new SqlCommand("dbo.SpUpdateSalary", this.sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.EmployeeName);
                    command.Parameters.AddWithValue("@basePay", model.BasicPay);
                    sqlconnection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Updated Successfully");

                    }
                    else
                    {
                        Console.WriteLine("Unsuccessfull");
                    }

                }
                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }

        //UC5 retrieve employee details within a date range
        public string RetrieveDataBasedOnDateRange(EmployeeModel model)
        {
            try
            {
                using (sqlconnection)
                {
                    //query execution
                    string query = @"select * from employee_payroll where startDate between('2019-05-01') and getdate()";
                    //passing the query and connection
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    //open sql connection
                    sqlconnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.EmployeeId = Convert.ToInt32(reader["id"] == DBNull.Value ? default : reader["id"]);
                            model.EmployeeName = reader["name"] == DBNull.Value ? default : reader["name"].ToString();
                            model.BasicPay = Convert.ToDouble(reader["Base_Pay"] == DBNull.Value ? default : reader["Base_Pay"]);
                            model.StartDate = (DateTime)(reader["startDate"] == DBNull.Value ? default(DateTime) : reader["startDate"]);
                            model.Gender = reader["gender"] == DBNull.Value ? default : reader["gender"].ToString();
                            model.Department = reader["department"] == DBNull.Value ? default : reader["department"].ToString();
                            model.PhoneNumber = Convert.ToDouble(reader["phone"] == DBNull.Value ? default : reader["phone"]);
                            model.Address = reader["address"] == DBNull.Value ? default : reader["address"].ToString();
                            model.Deductions = Convert.ToDouble(reader["Deductions"] == DBNull.Value ? default : reader["Deductions"]);
                            model.TaxablePay = Convert.ToDouble(reader["TaxablePay"] == DBNull.Value ? default : reader["TaxablePay"]);
                            model.IncomeTax = Convert.ToDouble(reader["IncomeTax"] == DBNull.Value ? default : reader["IncomeTax"]);
                            model.NetPay = Convert.ToDouble(reader["NetPay"] == DBNull.Value ? default : reader["NetPay"]);
                            Console.WriteLine("{0} {1} {2}  {3} {4} {5}  {6}  {7} {8} {9} {10} {11}", model.EmployeeId, model.EmployeeName, model.BasicPay, model.StartDate, model.Gender, model.Department, model.PhoneNumber, model.Address, model.Deductions, model.TaxablePay, model.IncomeTax, model.NetPay);
                            Console.WriteLine("\n");
                        }
                    }
                    //close reader
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
            finally
            {
                sqlconnection.Close();
            }
            return "Get the details within date range successfully";
        }

        //Uc6 to find sum,average,min,max of salary group by gender
        public string PerformAggregateFunctions(EmployeeModel model)
        {
            try
            {
                SqlCommand command = new SqlCommand("dbo.SpFindSumAverage", this.sqlconnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Gender", model.Gender);
                sqlconnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(" Total Salary: {0} \n Average Salary: {1} \n Minimum Salary: {2} \n Max Salary:{3} \n Count of employess:{4} Group by {5}", reader[0], reader[1], reader[2], reader[3], reader[5], reader[4]);
                    }
                }
                else
                {
                    return "There is no row present";
                }
                reader.Close();
                return "Get the details successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
    }
}
