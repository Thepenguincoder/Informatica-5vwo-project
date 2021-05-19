using Informatica_5vwo_project.Models;
using Informatica_5vwo_project.Databases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Informatica_5vwo_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //string connectionString = "Server=172.16.160.21;Port=3306;Database=110411;Uid=110411;Pwd=inf2021sql;";
        string connectionString = "Server=informatica.st-maartenscollege.nl;Port=3306;Database=110411;Uid=110411;Pwd=inf2021sql;";


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }









        public List<string> GetNames()
        {
           

            // maak een lege lijst waar we de namen in gaan opslaan
            List<string> names = new List<string>();

            // verbinding maken met de database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                // verbinding openen
                conn.Open();

                // SQL query die we willen uitvoeren
                MySqlCommand cmd = new MySqlCommand("select * from films", conn);

                // resultaat van de query lezen
                using (var reader = cmd.ExecuteReader())
                {
                    // elke keer een regel (of eigenlijk: database rij) lezen
                    while (reader.Read())
                    {
                        // selecteer de kolommen die je wil lezen. In dit geval kiezen we de kolom "naam"
                        string Name = reader["beschrijving"].ToString();

                        // voeg de naam toe aan de lijst met namen
                        names.Add(Name);
                    }
                }
            }

            // return de lijst met namen
            return names;
        }








        public List<Films> GetFilmsOverzicht()
        {


            // maak een lege lijst waar we de namen in gaan opslaan
            List<Films> films = new List<Films>();

            // verbinding maken met de database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                // verbinding openen
                conn.Open();

                // SQL query die we willen uitvoeren
                MySqlCommand cmd = new MySqlCommand("select * from films", conn);

                // resultaat van de query lezen
                using (var reader = cmd.ExecuteReader())
                {
                    // elke keer een regel (of eigenlijk: database rij) lezen
                    while (reader.Read())
                    {
                        Films p = new Films
                        {
                            // selecteer de kolommen die je wil lezen. In dit geval kiezen we de kolom "naam"
                            Id = Convert.ToInt32(reader["Id"]),
                            Naam = reader["Naam"].ToString(),
                            Beschrijving = reader["Beschrijving"].ToString(),
                            Genres = reader["Genres"].ToString(),
                            Datum = reader["Datum"].ToString(),
                            Begintijd = reader["Begintijd"].ToString(),
                            Eindtijd = reader["Eindtijd"].ToString(),
                            Leeftijd = reader["Leeftijd"].ToString(),
                            Taal = reader["Taal"].ToString(),
                        };

                        // voeg de naam toe aan de lijst met namen
                        films.Add(p);
                    }
                }
            }

            // return de lijst met namen
            return films;
        }







        private Films GetFilmsDetails(string id)
        {
            
            List<Films> films = new List<Films>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // SQL query die we willen uitvoeren
                MySqlCommand cmd = new MySqlCommand($"select * from films where id = {id}", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Films p = new Films
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Naam = reader["Naam"].ToString(),
                            Beschrijving = reader["Beschrijving"].ToString(),
                        };

                        films.Add(p);
                    }
                }
            }

            return films[0];
        }



        [Route("")]
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("overzicht")]
        public IActionResult Overzicht()
        {
            var films = GetFilmsOverzicht();
            return View(films);
        }

        [Route("details/{naam}")]
        public IActionResult Films(string naam)
        {
            var model = GetFilmsDetails(naam);

            return View(model);
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }


        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("Gelukt")]
        [HttpPost]
        public IActionResult Gelukt(Person person)
        {
            if (ModelState.IsValid) {

                SavePerson(person);
                return View(person);
            }

            return View(person);
        }


        [Route("Login")]
        public IActionResult Login(string username, string password)
        {
            if (password == "geheim")
            {
                HttpContext.Session.SetString("User", username);
                ViewData["user"] = HttpContext.Session.GetString("User");
                HttpContext.Session.SetString("Password", password);
                ViewData["password"] = HttpContext.Session.GetString("Password");
                return View();
            }

            return View();
        }


        private void SavePerson(Person person)
        {          
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO filmklant(voornaam, achternaam, email) VALUE(?voornaam, ?achternaam, ?email)", conn);

                cmd.Parameters.Add("?voornaam", MySqlDbType.Text).Value = person.FirstName;
                cmd.Parameters.Add("?achternaam", MySqlDbType.Text).Value = person.LastName;
                cmd.Parameters.Add("?email", MySqlDbType.Text).Value = person.Email;
                cmd.ExecuteNonQuery();
            }
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error2()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class TelemetryClient
    {
        internal void TrackEvent(string v, Dictionary<string, string> dictionaries)
        {
            throw new NotImplementedException();
        }

        internal void TrackException(Exception error)
        {
            throw new NotImplementedException();
        }
    }
}

