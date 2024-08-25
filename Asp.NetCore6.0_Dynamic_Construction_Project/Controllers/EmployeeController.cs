﻿using Asp.NetCore6._0_Dynamic_Construction_Project.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Models.DTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore6._0_Dynamic_Construction_Project.Controllers
{
   
    public class EmployeeController : Controller
    {
        EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeRepository());
        public IActionResult Index()
        {
            var values = employeeManager.GetList();
            return View(values);
        }
        public IActionResult EmployeeList()
        {
          
            var values = employeeManager.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
         
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeImageAdd employeeImageAdd)
        {
            Employee employee = new Employee();
            if (employeeImageAdd.EmployeeImage != null)
            {
                var extension = Path.GetExtension(employeeImageAdd.EmployeeImage.FileName);
                var newimageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/EmployeeImageFolder/", newimageName);
                var stream = new FileStream(location, FileMode.Create);
                employeeImageAdd.EmployeeImage.CopyTo(stream);
                employee.EmployeeImage = "/EmployeeImageFolder/" + newimageName;
            }
            employee.EmployeeName = employeeImageAdd.EmployeeName;
            employee.EmployeeSurName = employeeImageAdd.EmployeeSurName;
            employee.EmployeeTwitter = employeeImageAdd.EmployeeTwitter;
            employee.EmployeeFacebook = employeeImageAdd.EmployeeFacebook;
            employee.EmployeeInstagram = employeeImageAdd.EmployeeInstagram;
            employee.EmployeeLinkedin = employeeImageAdd.EmployeeLinkedin;
            employee.EmployeeStatus = true;
            employeeManager.TAdd(employee);
            return RedirectToAction("EmployeeList", "Employee");
        }

        public IActionResult DeleteEmployee(int id)
        {
            var values = employeeManager.TGetByID(id);

            employeeManager.TDelete(values);

            return RedirectToAction("EmployeeList", "Employee");
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
          
            var values = employeeManager.TGetByID(id);
            ViewBag.v1 = values;
            return View(values);

        }

        [HttpPost]

        public IActionResult UpdateEmployee(Employee employee, IFormFile imagefile)
        {
            if (imagefile != null)
            {
                employee.EmployeeImage = AddImage.ImageAdd(imagefile, AddImage.StaticProfileImageLocation());
            }
            employee.EmployeeStatus = true;
            employeeManager.TUpdate(employee);
            return RedirectToAction("EmployeeList", "Employee");
        }
    }
}
