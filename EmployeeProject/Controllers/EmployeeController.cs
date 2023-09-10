using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BusinessLogicLayer.DTO;
using EmployeeProject.Interfaces;
using EmployeeProject.Models;
using EmployeeProject.Repositories;
using EmployeeProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Globalization;

namespace EmployeeProject.Controllers
{
    

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper mapper;
        public EmployeeController(IEmployeeService _employee , IMapper mapper)
        {


            this._employeeService = _employee;
            this.mapper = mapper;

        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployees(null);
            //List<EmployeeViewModel> employeesvm = new List<EmployeeViewModel>();


            //foreach (var emp in employees)
            //{
            //    EmployeeViewModel empvm = new EmployeeViewModel
            //    {
            //        Id = emp.Id,
            //        Name = emp.Name,
            //        BasicSalary = emp.BasicSalary,
            //        Allowance = emp.Allowance,
            //        TotalSalary = emp.Allowance + emp.BasicSalary,
            //        HireDate = emp.HireDate.Value.ToShortDateString(),

            //    };
            //    employeesvm.Add(empvm);
            //}

            // Removed because of using DTOs

            EmployeeViewModel empvm = new EmployeeViewModel
			{                                                // mapping from dto to viewModel

				EmployeesList = employees
            };





            return View(empvm);


        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = ("Admin"))]

        public IActionResult Create(EmployeeViewModel employee)
        {

            //employee.employeeDto.Id = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(employee.employeeDto);
                return RedirectToAction("Index");
            }

            

            Console.WriteLine(ModelState.ToString());
            return View();
        }

        [HttpGet]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Update(Guid id)
        {
            var emp = await _employeeService.GetEmployeeById(id);
            EmployeeViewModel empvm = new EmployeeViewModel
            {
                employeeDto = new EmployeeDto()
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    BasicSalary = emp.BasicSalary,
                    Allowance = emp.Allowance,
                    HireDate = emp.HireDate
                }


            };

            return View(empvm);

        }

        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Update(Guid Id ,EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                //EmployeeDto emp = new EmployeeDto
                //{
                //    Id = Id,
                //    Name = employee.employeeDto.Name,
                //    BasicSalary = employee.employeeDto.BasicSalary,
                //    Allowance = employee.employeeDto.Allowance,
                //    HireDate = employee.employeeDto.HireDate,
                //    TotalSalary = employee.employeeDto.TotalSalary,
                //};


                _employeeService.UpdateEmployee(employee.employeeDto);
				TempData["Msg"] = "Employee Has Been Updated Successfully!";
				return RedirectToAction("Index");
			}
				
  

            return View();
        }

        [HttpGet]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Search()
        {

            var employees = await _employeeService.GetAllEmployees(null);

            EmployeeViewModel emp = new EmployeeViewModel // mapping from dto to viewModel
            { 
                EmployeesList = employees 
            };

            return View(emp);


        }

        [HttpPost]
        [Authorize(Roles = ("Admin"))]

        public async Task<JsonResult> Search(string Name)
        {
            var employeesfiltered = await _employeeService.GetAllEmployees(Name);

            EmployeeViewModel empvm = new EmployeeViewModel
            {
				EmployeesList = employeesfiltered

            };

            return Json(empvm);
        }

        [HttpGet]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> EnsureDelete(Guid id)
        {
            var emp = await _employeeService.GetEmployeeById(id);
            if (emp != null)
            {
                EmployeeViewModel empvm = new EmployeeViewModel
                
                { 
                    employeeDto = emp
                };


                return View(empvm);
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public async Task<IActionResult> Delete(Guid Id)
        {

            var x =  await _employeeService.DeleteEmployee(Id);

            return RedirectToAction("Index");


        }

    }
}
