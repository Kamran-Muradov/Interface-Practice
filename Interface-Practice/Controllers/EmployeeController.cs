using Interface_Practice.Services.Interfaces;
using Interface_Practice.Services;
using Interface_Practice.Models;
using Interface_Practice.Helpers.Constans;

namespace Interface_Practice.Controllers
{
    public class EmployeeController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }

        public void GetAll()
        {
            var employees = _employeeService.GetAll();

            foreach (var employee in employees)
            {
                string result = $"{employee.Name} {employee.Surname} {employee.Age} {employee.Address} {employee.Email} {employee.Birthday.ToString("MM/dd/yyyy")}";
                Console.WriteLine(result);
            }
        }

        public void GetById()
        {
            int? id = 100;

            var response = _employeeService.GetById(_employeeService.GetAll(), id);

            if (response.ErrorMessage is null)
            {
                string result = $"{response.Employee.Name} {response.Employee.Surname} {response.Employee.Age} {response.Employee.Address} {response.Employee.Email} {response.Employee.Birthday.ToString("MM/dd/yyyy")}";
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        public void SearchByNameOrSurname()
        {
            Console.WriteLine("Enter name or surname: ");
        Input: string text = Console.ReadLine();

            var response = _employeeService.SearchByNameOrSurname(_employeeService.GetAll(), text);

            if (response[0].ErrorMessage is null)
            {
                foreach (var item in response)
                {
                    string result = $"{item.Employee.Name} {item.Employee.Surname} {item.Employee.Age} {item.Employee.Address} {item.Employee.Email} {item.Employee.Birthday.ToString("MM/dd/yyyy")}";
                    Console.WriteLine(result);
                }
            }
            else if (response[0].ErrorMessage == EmployeeResponseMessages.InputNullOrEmpty)
            {
                Console.WriteLine(response[0].ErrorMessage + ". Please try again:");
                goto Input;
            }
            else
            {
                Console.WriteLine(response[0].ErrorMessage);
            }
        }
    }
}
