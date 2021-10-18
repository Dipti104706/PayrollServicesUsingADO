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
            //Creating a object for employeerepository
            EmployeeRepository repository = new EmployeeRepository();
            repository.UpdateSalary();
            Console.ReadLine();
        }
    }
}
