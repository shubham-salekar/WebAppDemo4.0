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
                new Employee(){ Id = 1 , Name = "shubham" , Email= "a@a.com",Department = "HR" },
                new Employee(){ Id = 2 , Name = "max" , Email= "a@a.com",Department = "HR" },
                new Employee(){ Id = 3 , Name = "james" , Email= "a@a.com",Department = "HR"}
            };
            Console.WriteLine("MockEmpRepository ctor end");
        }
        public Employee GetEmployee(int id)
        {
            Console.WriteLine("GetEmployee");

            return _employeeList.FirstOrDefault( emp => emp.Id == id);
        }
    }
}
