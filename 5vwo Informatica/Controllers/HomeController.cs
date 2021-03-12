using _5vwo_Informatica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;

namespace _5vwo_Informatica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }   

        public IActionResult Contact()
        {

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
           app.UseHsts();
        }   

        [Route("error")]
                public class ErrorController : Controller
                {
                    private readonly TelemetryClient _telemetryClient;

                    public ErrorController(TelemetryClient telemetryClient)
                    {
                        _telemetryClient = telemetryClient;
                    }

                    [Route("500")]
                    public IActionResult AppError()
                    {
                        var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                        _telemetryClient.TrackException(exceptionHandlerPathFeature.Error);
                        _telemetryClient.TrackEvent("Error.ServerError", new Dictionary<string, string>
                        {
                            ["originalPath"] = exceptionHandlerPathFeature.Path,
                            ["error"] = exceptionHandlerPathFeature.Error.Message
                        });
                        return View();
                    }

                    [Route("404")]
                    public IActionResult PageNotFound()
                    {
                        string originalPath = "unknown";
                        if (HttpContext.Items.ContainsKey("originalPath"))
                        {
                            originalPath = HttpContext.Items["originalPath"] as string;
                        }
                        _telemetryClient.TrackEvent("Error.PageNotFound", new Dictionary<string, string>
                        {
                            ["originalPath"] = originalPath
                        });
                        return View();
                    }
                }
        
    }
}

