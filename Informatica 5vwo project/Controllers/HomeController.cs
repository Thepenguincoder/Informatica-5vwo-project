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
using System.Security.Cryptography;
using System.Text;

namespace Informatica_5vwo_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        //https://informatica.st-maartenscollege.nl/phpmyadmin/index.php

        //string connectionString = "Server=172.16.160.21;Port=3306;Database=110411;Uid=110411;Pwd=inf2021sql;"; //School
        string connectionString = "Server=informatica.st-maartenscollege.nl;Port=3306;Database=110411;Uid=110411;Pwd=inf2021sql;"; //Thuis


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
                            Genres = reader["Genres"].ToString(),
                            Leeftijd = reader["Leeftijd"].ToString(),
                            Taal = reader["Taal"].ToString(),
                            Poster = reader["poster"].ToString(),
                        };

                        films.Add(p);
                    }
                }
            }

            return films[0];
        }

        public List<Voorstellingen> GetVoorstelling(string id)
        {
            List<Voorstellingen> voorstellingen = new List<Voorstellingen>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))

            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"select * from voorstelling where film_id = {id}", conn); ;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Voorstellingen k = new Voorstellingen

                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Datum = Convert.ToDateTime(reader["Datum"].ToString()),
                            Begintijd = reader["Begintijd"].ToString(),
                            Eindtijd = reader["Eindtijd"].ToString(),
                            Beschikbaarheid = reader["Beschikbaarheid"].ToString(),
                            Zaal = reader["Zaal"].ToString(),
                        };
                        voorstellingen.Add(k);
                    }
                }
            }
            return voorstellingen;
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
                            Leeftijd = reader["Leeftijd"].ToString(),
                            Taal = reader["Taal"].ToString(),
                            Poster = reader["poster"].ToString(),
                        };

                        // voeg de naam toe aan de lijst met namen
                        films.Add(p);
                    }
                }
            }

            // return de lijst met namen
            return films;
        }

        


       
        private Klant GetKlant(string email)
        {
            List<Klant> klant = new List<Klant>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"select * from filmklant where email = '{email}'", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Klant p = new Klant
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Voornaam = reader["voornaam"].ToString(),
                            Achternaam = reader["achternaam"].ToString(),
                            Email = reader["email"].ToString(),
                            Wachtwoord = reader["wachtwoord"].ToString()

                        };
                        klant.Add(p);
                    }
                }
            }
            return klant[0];
        }



        private void SavePerson(Person person)
        {
            person.wachtwoord = ComputeSha256Hash(person.wachtwoord);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO filmklant(voornaam, achternaam, email, wachtwoord) VALUE(?voornaam, ?achternaam, ?email, ?wachtwoord)", conn);

                cmd.Parameters.Add("?voornaam", MySqlDbType.Text).Value = person.voornaam;
                cmd.Parameters.Add("?achternaam", MySqlDbType.Text).Value = person.achternaam;
                cmd.Parameters.Add("?email", MySqlDbType.Text).Value = person.email;
                cmd.Parameters.Add("?wachtwoord", MySqlDbType.Text).Value = person.wachtwoord;
                cmd.ExecuteNonQuery();
            }
        }

        private void SaveBericht(Contactform contactform)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO contactform(email, bericht) VALUE(?email, ?bericht)", conn);

                cmd.Parameters.Add("?email", MySqlDbType.Text).Value = contactform.Email;
                cmd.Parameters.Add("?bericht", MySqlDbType.Text).Value = contactform.Bericht;
                cmd.ExecuteNonQuery();
            }
        }


        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
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
        public IActionResult Details(string naam)
        {
            var film = GetFilmsDetails(naam);
            var voorstellingen = GetVoorstelling(naam);
            var model = new FilmViewModel();
            model.Film = film;
            model.Voorstellingen = voorstellingen;

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

        [Route("Betalen")]
        public IActionResult Betalen()
        {
            return View();
        }

        [Route("Contact")]
        [HttpPost]
        public IActionResult Contact(Contactform contactform)
        {
            if (ModelState.IsValid) 
            {
                SaveBericht(contactform);
                return Redirect("Succes");
            }

            return View(contactform);
        }

        [Route("Signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("Signup")]
        [HttpPost]
        public IActionResult Signup(Person person)
        {
            if (ModelState.IsValid)
            {
                SavePerson(person);
                return Redirect("Succes2");
            }

            return View(person);
        }

        
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string email, string wachtwoord)
        {
            var klant = GetKlant(email);

            if (klant.Wachtwoord == ComputeSha256Hash(wachtwoord))
            {
                HttpContext.Session.SetInt32("User", klant.Id);
                HttpContext.Session.SetString("UserName", klant.Voornaam);
                HttpContext.Session.SetString("UserLastName", klant.Achternaam);
                HttpContext.Session.SetString("UserEmail", klant.Email);
                return Redirect("Profiel");
            }

            return View();
        }
        
        [Route("Profiel")]
        public IActionResult Profiel()
        {
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["UserLastName"] = HttpContext.Session.GetString("UserLastName");
            ViewData["UserEmail"] = HttpContext.Session.GetString("UserEmail");
            return View();
        }

        [Route("Succes")]
        public IActionResult Succes()
        {
            return View();
        }

        [Route("Succes2")]
        public IActionResult Succes2()
        {
            return View();
        }

         




      


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error2()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

