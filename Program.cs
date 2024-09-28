
using Prac1;
using System.Formats.Tar;
using System.Runtime.CompilerServices;

List<Employee> EmployeeList = new List<Employee>();
//static void main(string[] args) {

var Worker1 = new Employee("Koby Rein", "A45", 35);
var Worker2 = new Employee("Franz Reid", "B47", 39);
var Worker3 = new Employee("John Green", "C98", 32);


EmployeeList.Add(Worker1);
EmployeeList.Add((Employee)Worker2);
EmployeeList.Add((Employee)Worker3);

/*Console.WriteLine(Emp.ToString);
GetValidName();
GetValidID();
GetHourValid();
Emp.TotalWage();*/

bool Prophet = true;

while (Prophet)
{
    Console.WriteLine("Hello, welcome to your employee manager");
    Console.WriteLine("Please select which option you want:");
    Console.WriteLine("1: Add a new employee");
    Console.WriteLine("2: Delete an employee's details");
    Console.WriteLine("3: Display current saved employees)");
    Console.WriteLine("4: Quit");
    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            addnewEmployee();
            break;
        case "2":
            removeEmployee();
            break;
        case "3":
            displaySavedEmployees();
            break;
        case "4":
            Prophet = false;
            break;
        default:
            Console.WriteLine("Error incorrect entry");
            break;


    }
}

static void addnewEmployee()
{
    string newEmployeeName = Employee.GetValidName();
    string newEmployeeId = Employee.GetValidID();
    double newEmployeeHours = Employee.GetHourValid();

    var NewEmployee = new Employee(newEmployeeName, newEmployeeId, newEmployeeHours);

    EmployeeList.Add(NewEmployee);

    Console.WriteLine($"Employee added: {NewEmployee.ToString}");
}
static void removeEmployee()
{
    displaySavedEmployees();
    if (EmployeeList.Count == 0)
    {
        Console.WriteLine("No Employees found within list");
        return;
    }
    int selected;
    Console.WriteLine($"Enter number allocated to employee you wish to delete 1 to {EmployeeList.Count}");
    while (!int.TryParse(Console.ReadLine(), out selected) || selected < 1 || selected > EmployeeList.Count) ;
    {
        Console.WriteLine($"Error, invalid input please choose from 1 to {EmployeeList.Count}");
    }
    int index = selected;
    Employee employToDel = EmployeeList[index];
    EmployeeList.RemoveAt(index);

    Console.WriteLine($"Employee {employToDel.EmployeeFullName}{employToDel.EmployeeID} has been removed");
}




static void displaySavedEmployees()
{
    Console.WriteLine("Current saved lsit of employees: ");
    int index = 1;
    foreach (Employee employee in EmployeeList)
    {
        Console.WriteLine($"{index}: {employee.ToString()}");
        Console.WriteLine($"Wage is: ${employee.TotalWage()}");
        index++;
    }

}



