using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAppDemo4._0.Models
{
    public class MockEmpRepository : IEmpRepository
    {
      
        private List<Employee> _employeeList;

        public MockEmpRepository()
        {
            Console.WriteLine("MockEmpRepository ctor start");

            _employeeList = new List<Employee>()
            {
                new Employee(){ Id = 1 , Name = "shubham" , Email= "a@a.com",Department = Dept.IT },
                new Employee(){ Id = 2 , Name = "max" , Email= "b@a.com",Department =  Dept.DEV },
                new Employee(){ Id = 3 , Name = "james" , Email= "c@a.com",Department =  Dept.HR}
            };
            Console.WriteLine("MockEmpRepository ctor end");
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(x => x.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            Console.WriteLine("GetEmployee");

            return _employeeList.FirstOrDefault( emp => emp.Id == id);
        }
    }
}
