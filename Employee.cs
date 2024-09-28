using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prac1
{
    internal class Employee
    {
        public string EmployeeFullName { get; set; }
        public string EmployeeID { get; set; }
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }

        public Employee(string EmplloyeeFullName, string EmployeeID, double HoursWorked, double HourlyRate = 9.5)
        {
            this.EmployeeFullName = EmplloyeeFullName;
            this.EmployeeID = EmployeeID;
            this.HoursWorked = HoursWorked;
            this.HourlyRate = HourlyRate;
        }

        public override string ToString()
        {
            return $"{EmployeeFullName}({EmployeeID})";
        }
        public double TotalWage()
        {
            return HoursWorked * HourlyRate;
        }
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length >= 1 && name.Length <= 50;
        }
        public static bool IsValidID(string id)
        {
            return Regex.IsMatch(id, @"^[A-Za-z]\d{2}$");
        }
        public static bool HourValid(double hoursWorked)
        {
            return hoursWorked >= 1 && hoursWorked <= 100;
        }

        public static string GetValidName()
        {
            string name;
            do
            {
                Console.Write("Enter your name: (must be 1-50 characters): ");
                name = Console.ReadLine();

                if (!Employee.IsValidName(name))
                {
                    Console.WriteLine("Error invalid name");
                }
            } while (!Employee.IsValidName(name));
            return name;

        }

        public static string GetValidID()
        {
            string Id;
            do
            {
                Console.Write("Enter Employee ID: (Must be 1 Letter and 2 numbers): ");
                Id = Console.ReadLine();
                if (!Employee.IsValidID(Id))
                {
                    Console.WriteLine("Error Invalid ID");
                }
            } while (!Employee.IsValidID(Id));
            return Id;
        }

        public static double GetHourValid()
        {
            double hours;
            do
            {
                Console.Write("Enter total worked hours: ");
                bool AcceptedNumber = double.TryParse(Console.ReadLine(), out hours);
                if (!AcceptedNumber || !Employee.HourValid(hours)) ;
                {
                    Console.WriteLine("Error: invalid number entered");
                }
            } while (!Employee.HourValid(hours));
            return hours;
        }


    }
}
