﻿using System.Collections.Generic;

namespace WebAppDemo4._0.Models
{
    public interface IEmpRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();

    }
}
