using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using Microsoft.AspNetCore.Identity;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages
{
    public class BugReportUtility
    {
        public static NotFoundResult NotFoundAndReport(ApplicationUser user,string description,IBugReportRepository bugReportRepository)
        {
            BugReport BugReport = new BugReport();
            BugReport.User = user;
            BugReport.Description = description;
            BugReport.Origin = BugReportOrigin.Generated;
            BugReport.Date = DateTime.Now;
            _ = bugReportRepository.AddAsync(BugReport).Result;
            return new NotFoundResult();
        }
    }
}
