using AutoMapper;
using System;

// https://dotnettutorials.net/lesson/automapper-in-c-sharp/
namespace TestAutoMapper
{
    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class EmployeeDTO
    {
        public string FullName { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Dept { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Step1: Initialize the mapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>()
                    .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Dept, act => act.MapFrom(src => src.Department));

                cfg.CreateMap<EmployeeDTO, Employee>();
            });

            //Step2: Create the source object
            Employee emp = new Employee
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT"
            };

            //Step3: use the mapper to map the source and destination object
            var empDTO = Mapper.Map<Employee, EmployeeDTO>(emp);

            var emp1 = Mapper.Map<EmployeeDTO, Employee>(empDTO);
            //OR
            //var empDTO = Mapper.Map<EmployeeDTO>(emp);
            Console.WriteLine("Name:" + empDTO.FullName + ", Salary:" + empDTO.Salary + ", Address:" + empDTO.Address + ", Department:" + empDTO.Dept);
            Console.ReadLine();
        }
    }
}
