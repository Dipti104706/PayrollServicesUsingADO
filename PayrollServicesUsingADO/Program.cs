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
            Console.WriteLine("Id Name BasicPay Startdate Gender Department PhoneNumber Address Deduction Tax IncomeTax NetPay \n");
            repository.GetAllEmployee();
            Console.ReadLine();
        }
    }
}
