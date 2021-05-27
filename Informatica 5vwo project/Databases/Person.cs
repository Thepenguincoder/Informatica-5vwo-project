using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Informatica_5vwo_project.Databases
{
    public class Person
    {
        [Required(ErrorMessage = "Het invullen van uw voornaam is verplicht")]
        public string voornaam { get; set; }
        [Required(ErrorMessage = "Het invullen van uw achternaam is verplicht")]
        public string achternaam { get; set; }
        [Required(ErrorMessage = "Het invullen van uw e-mailadress is verplicht")]
        public string email { get; set; }
        [Required(ErrorMessage = "Het kiezen van een wachtwoord is verplicht")]
        public string wachtwoord { get; set; }
    }
}

