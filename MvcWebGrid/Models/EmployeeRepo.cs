using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Employee
{
    public int employeeId { get; set; }
    public string employeeName { get; set; }
    public string address { get; set; }
    public string designation { get; set; }
    public decimal age { get; set; }
}

public static class EmployeeRepo
{
    public static IEnumerable<Employee> GetEmployees()
    {
        var employee = new List<Employee>();

        employee.Add(new Employee { employeeId = 1, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 2, employeeName = "test2", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 3, employeeName = "test3", address = "Kolkata", age = 25, designation = "A" });
        employee.Add(new Employee { employeeId = 4, employeeName = "test4", address = "Kolkata", age = 25, designation = "A" });
        employee.Add(new Employee { employeeId = 5, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 6, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 7, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 8, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 9, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 10, employeeName = "test1", address = "Kolkata", age = 25, designation = "SA" });
        employee.Add(new Employee { employeeId = 11, employeeName = "test1", address = "Kolkata", age = 25, designation = "SA" });
        employee.Add(new Employee { employeeId = 12, employeeName = "test1", address = "Kolkata", age = 25, designation = "M" });
        employee.Add(new Employee { employeeId = 13, employeeName = "test1", address = "Kolkata", age = 25, designation = "M" });
        employee.Add(new Employee { employeeId = 14, employeeName = "test1", address = "Kolkata", age = 25, designation = "A" });
        employee.Add(new Employee { employeeId = 15, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 16, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });

        return employee;
    }
    public static List<Employee> GetEmployeesList()
    {
        var employee = new List<Employee>();

        employee.Add(new Employee { employeeId = 1, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 2, employeeName = "test2", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 3, employeeName = "test3", address = "Kolkata", age = 25, designation = "A" });
        employee.Add(new Employee { employeeId = 4, employeeName = "test4", address = "Kolkata", age = 25, designation = "A" });
        employee.Add(new Employee { employeeId = 5, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 6, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 7, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 8, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 9, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 10, employeeName = "test1", address = "Kolkata", age = 25, designation = "SA" });
        employee.Add(new Employee { employeeId = 11, employeeName = "test1", address = "Kolkata", age = 25, designation = "SA" });
        employee.Add(new Employee { employeeId = 12, employeeName = "test1", address = "Kolkata", age = 25, designation = "M" });
        employee.Add(new Employee { employeeId = 13, employeeName = "test1", address = "Kolkata", age = 25, designation = "M" });
        employee.Add(new Employee { employeeId = 14, employeeName = "test1", address = "Kolkata", age = 25, designation = "A" });
        employee.Add(new Employee { employeeId = 15, employeeName = "test1", address = "Kolkata", age = 25, designation = "PA" });
        employee.Add(new Employee { employeeId = 16, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });
        employee.Add(new Employee { employeeId = 17, employeeName = "test1", address = "Kolkata", age = 25, designation = "SM" });

        return employee;
    }
}