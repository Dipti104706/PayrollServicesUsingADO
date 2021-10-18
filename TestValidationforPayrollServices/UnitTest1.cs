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
    }
}
