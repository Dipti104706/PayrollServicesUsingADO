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
            repository.RetrieveAllEmployeeDetails();
            Console.ReadLine();
        }
    }
}
