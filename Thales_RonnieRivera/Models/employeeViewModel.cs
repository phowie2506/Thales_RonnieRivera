using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Thales_RonnieRivera.Models
{
    public class Employee
    {
        public string employee_name { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal employee_salary { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal anual_salary { get { return employee_salary * 12; }}
        public int employee_age { get; set; }
        public string profile_image { get; set; }

    }

    public class _employeeViewModel {
        public string status { get; set; }

        public List<Employee> data { get; set; }

    }

    public class employeeViewModel
    {
        public string status { get; set; }

        public Employee data { get; set; }

    }
}