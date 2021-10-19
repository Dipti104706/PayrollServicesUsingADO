using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollServicesUsingADO;
using System;

namespace TestValidationforPayrollServices
{
    [TestClass]
    public class UnitTest1
    {
        EmployeeRepository repository;
        EmployeeModel model;
        [TestInitialize]
        public void SetUp()
        {
            repository = new EmployeeRepository();
            model = new EmployeeModel();
        }

        //Uc4 update salary of terissa using stored procedure
        [TestMethod]
        public void UpdateSalaryPerticularPerson()
        {
            string expected = "Updated Successfully";
            model.EmployeeName = "Terissa";
            model.BasicPay = 30000000;
            string actual = repository.UpdateSalaryUsingStoredProcedure(model);
            Assert.AreEqual(actual, expected);
        }

        //Uc5 retrieve employee within a daterange
        [TestMethod]
        public void RetrieveDetailsWithinDateRange()
        {
            string expected = "Get the details within date range successfully";
            string actual = repository.RetrieveDataBasedOnDateRange(model);
            Assert.AreEqual(actual, expected);
        }

        //UC6 Find Sum, average, max, min group by gender
        [TestMethod]
        public void FindSumAvgMinMax()
        {
            string expected = "Get the details successfully";
            model.Gender = "M";
            string actual = repository.PerformFunctions(model);
            Assert.AreEqual(actual, expected);
        }

        //Uc7 Add new employee
        [TestMethod]
        [TestCategory ("Positivecase")]
        public void AddingNewEmployeesuccesfully()
        {
            string expected = "Successfully inserted the records";
            model.EmployeeName = "Sabita";
            model.BasicPay = 900000;
            model.StartDate = DateTime.Today;
            model.Gender = "M";
            model.PhoneNumber = 45698741256;
            model.Address = "Pune";
            model.Department = "Sales";
            model.TaxablePay = 3500;
            string actual = repository.AddEmployee(model);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        [TestCategory("Negativecase")]
        public void PassWrongSPReturnCustomException()
        {
            string expected = "Stored Procedure is not found";
            model.EmployeeName = "Kabita";
            model.BasicPay = 900000;
            model.StartDate = DateTime.Today;
            model.Gender = "M";
            model.PhoneNumber = 45698741256;
            model.Address = "Pune";
            model.Department = "Sales";
            model.TaxablePay = 3500;
            string actual = "";
            try
            {
                actual = repository.AddEmployee(model);
            }
            catch (CustomException ex)
            {
                //ASSERT
                Assert.AreEqual(expected, ex.Message);
            }
        }

    }
}
