﻿using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using multitenant_poc.Data;
using multitenant_poc.Data.Entities;
using multitenant_poc.Models;
using multitenant_poc.Data.Interfaces;

namespace multitenant_poc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITenant _currentTenant;
        private readonly IRepository<ApplicationDbContext> _repository;

        public HomeController(ILogger<HomeController> logger, ITenant currentTenant,
            IRepository<ApplicationDbContext> repository)
        {
            _logger = logger;
            _currentTenant = currentTenant;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalColleges = await _repository.GetCountAsync<College>();
            return View(this._currentTenant);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
