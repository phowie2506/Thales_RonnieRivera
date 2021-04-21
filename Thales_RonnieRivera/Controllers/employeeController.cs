using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thales_RonnieRivera.Models;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Dynamic;

namespace Thales_RonnieRivera.Controllers
{
    public class employeeController : Controller
    {
        // GET: employee
        public ActionResult Index()
        {
            List<Employee> employee = new List<Employee>();
            _employeeViewModel Jsonemployees = GetEmployees();
            if (Jsonemployees.status == "success")
            {
                employee = Jsonemployees.data;
            }
            else{
                ModelState.AddModelError("Error", Jsonemployees.status);
                return View(employee);
            }

            return View(employee);
        }

        public ActionResult getAllEmployees()
        {
            List<Employee> employee = new List<Employee>();
            _employeeViewModel Jsonemployees = GetEmployees();
            if (Jsonemployees.status == "success")
            {
                employee = Jsonemployees.data;
            }
            else
            {
                ModelState.AddModelError("Error", Jsonemployees.status);
                return View(employee);
            }

            return View(employee);
        }

        public ActionResult Details(int id)
        {
            Employee employee = new Employee();
            string URL = "http://dummy.restapiexample.com/api/v1/employee/" + id;
            employeeViewModel Jsonemployees = GetEmployeeId(URL);
            if (Jsonemployees.status != "success")
            {
                ModelState.AddModelError("Error", Jsonemployees.status);
                return View(employee);
            }

            if (Jsonemployees.data == null) {
                ModelState.AddModelError("Error", "Employee not found");
                return View();
            }

            employee = Jsonemployees.data;
            return View(employee);
        }

        public ActionResult ById()
        {
            return View();
        }


        public _employeeViewModel GetEmployees()
        {
            string path = "http://dummy.restapiexample.com/api/v1/employees";
            try
            {
                WebRequest webRequest = WebRequest.Create(path);
                webRequest.Method = "GET";

                StreamReader sr = new StreamReader(webRequest.GetResponse().GetResponseStream());

                JObject result = JObject.Parse(sr.ReadToEnd());
                
                return JsonConvert.DeserializeObject<_employeeViewModel>(result.ToString());
            }
            catch (Exception ex) {
                _employeeViewModel erromodel = new _employeeViewModel() {
                    status = ex.Message.ToString()
                };
                return erromodel;
            }

            
        }

        public employeeViewModel GetEmployeeId(string path)
        {

            try
            {
                WebRequest webRequest = WebRequest.Create(path);
                webRequest.Method = "GET";

                StreamReader sr = new StreamReader(webRequest.GetResponse().GetResponseStream());

                JObject result = JObject.Parse(sr.ReadToEnd());

                return JsonConvert.DeserializeObject<employeeViewModel>(result.ToString());
            }
            catch (Exception ex)
            {
                employeeViewModel erromodel = new employeeViewModel()
                {
                    status = ex.Message.ToString()
                };
                return erromodel;
            }


        }

         
    }
}