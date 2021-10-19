using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollServicesUsingADO
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepositoryUsingER repository = new EmployeeRepositoryUsingER();
            //UC2
            //repository.RetrieveAllEmployeeDetails();
            ////UC3
            //repository.UpdateSalaryofParticular();
            //UC4
            //ERModel model = new ERModel();
            //model.Basic_Pay = 7000000;
            //model.Name = "Veer";
            //repository.UpdateSalarybySP(model);
            //U5
            repository.RetrieveDataBasedOnDateRange();
            Console.ReadLine();
        }
    }
}
