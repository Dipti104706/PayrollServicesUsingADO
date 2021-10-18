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
            string actual = repository.PerformAggregateFunctions(model);
            Assert.AreEqual(actual, expected);
        }
    }
}
