using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollServicesUsingADO
{
    public class ERModel
    {
        //Getter and setter fields(present in db)
        public int Id { get; set; }
        public string Name { get; set; }
        public double PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Emp_Gender { get; set; }
        public double Basic_Pay { get; set; }
        public double Deduction { get; set; }
        public double Taxable_Pay { get; set; }
        public double Income_Tax { get; set; }
        public double Net_Pay { get; set; }
        public DateTime Start_Date { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
    }
}
