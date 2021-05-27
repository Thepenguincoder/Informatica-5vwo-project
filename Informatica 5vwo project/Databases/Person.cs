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
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Het invullen van uw achternaam is verplichd")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Het invullen van uw e-mailadress is verplich")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Het kiezen van een wachtwoord is verplichd")]
        public string Password { get; set; }
    }
}

