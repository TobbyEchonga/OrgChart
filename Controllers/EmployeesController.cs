using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OrgChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrgChart.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeesController(EmployeeDbContext context)
        {
            this._context = context;
        }
        public JsonResult Index()
        {
            //var date = "2021-05-23";
            //var dateParam = new SqlParameter("@asofdate", date);

            //var model = _context.Job_history
            //    .FromSqlRaw<XHR_Job_History>("Exec [XHR_ReportOrgan]")
            //    //.FromSqlRaw<XHR_Job_History>("Exec XHR_JobHistory_None @asofdate", dateParam)
            //    .ToList();
            var model = _context.Employees
              .FromSqlRaw<Employee>("Exec [XHR_ReportOrgan]")
              .ToList();

            return Json(model);
        }

    }
}
